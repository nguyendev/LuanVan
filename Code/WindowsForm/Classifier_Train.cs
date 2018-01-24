﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

using System.IO;
using System.Xml;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Drawing.Imaging;
using System.Drawing;
using Emgu.CV.Face;

/// <summary>
/// Desingned to remove the training a EigenObjectRecognizer code from the main form
/// </summary>
class Classifier_Train : IDisposable
{

    #region Variables

    //Eigen
    //EigenObjectRecognizer recognizer;
    FaceRecognizer recognizer;

    //training variables
    List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();//Images
    //TODO: see if this can be combined in Ditionary format this will remove support for old data
    List<string> Names_List = new List<string>(); //labels
    List<int> Names_List_ID = new List<int>();
    int ContTrain, NumLabels;
    float Fisher_Distance = 0;
    string Fisher_label;
    int Fisher_threshold = 2000;

    //Class Variables
    string Error;
    bool _IsTrained = false;

    #endregion

    #region Constructors
    /// <summary>
    /// Default Constructor, Looks in (Application.StartupPath + "\\TrainedFaces") for traing data.
    /// </summary>
    public Classifier_Train()
    {
        _IsTrained = LoadTrainingData(Application.StartupPath + "\\TrainedFaces");
    }

    /// <summary>
    /// Takes String input to a different location for training data
    /// </summary>
    /// <param name="Training_Folder"></param>
    public Classifier_Train(string Training_Folder)
    {
        _IsTrained = LoadTrainingData(Training_Folder);
    }
    #endregion

    #region Public
    /// <summary>
    /// Retrains the recognizer witout resetting variables like recognizer type.
    /// </summary>
    /// <returns></returns>
    public bool Retrain()
    {
        return _IsTrained = LoadTrainingData(Application.StartupPath + "\\TrainedFaces");
    }
    /// <summary>
    /// Retrains the recognizer witout resetting variables like recognizer type.
    /// Takes String input to a different location for training data.
    /// </summary>
    /// <returns></returns>
    public bool Retrain(string Training_Folder)
    {
        return _IsTrained = LoadTrainingData(Training_Folder);
    }

    /// <summary>
    /// <para>Return(True): If Training data has been located and Eigen Recogniser has been trained</para>
    /// <para>Return(False): If NO Training data has been located of error in training has occured</para>
    /// </summary>
    public bool IsTrained
    {
        get { return _IsTrained; }
    }
    public float Get_Fisher_Distance
    {
        get
        {
            //get eigenDistance
            return Fisher_Distance;
        }
    }
    /// <summary>
    /// Recognise a Grayscale Image using the trained Eigen Recogniser
    /// </summary>
    /// <param name="Input_image"></param>
    /// <returns></returns>
    public string Recognise(Image<Gray, byte> Input_image, int Eigen_Thresh = -1)
    {
        if (_IsTrained)
        {
            FaceRecognizer.PredictionResult ER = recognizer.Predict(Input_image);

            if (ER.Label == -1)
            {
                Fisher_label = "Unknown";
                Fisher_Distance = 0;
                return Fisher_label;
            }
            else
            {
                Fisher_label = Names_List[ER.Label];
                Fisher_Distance = (float)ER.Distance;
                return Fisher_label; //the threshold set in training controls unknowns
            }
        }
        else return "";
    }

    public string Get_Error
    {
        get { return Error; }
    }

    /// <summary>
    /// Saves the trained Eigen Recogniser to specified location
    /// </summary>
    /// <param name="filename"></param>
    public void Save_Fisher_Recogniser(string filename)
    {
        recognizer.Write(filename);

        //save label data as this isn't saved with the network
        string direct = Path.GetDirectoryName(filename);
        FileStream Label_Data = File.OpenWrite(direct + "/Labels.xml");
        using (XmlWriter writer = XmlWriter.Create(Label_Data))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Labels_For_Recognizer_sequential");
            for (int i = 0; i < Names_List.Count; i++)
            {
                writer.WriteStartElement("LABEL");
                writer.WriteElementString("POS", i.ToString());
                writer.WriteElementString("NAME", Names_List[i]);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        Label_Data.Close();
    }

    /// <summary>
    /// Loads the trained Eigen Recogniser from specified location
    /// </summary>
    /// <param name="filename"></param>
    public void Load_Fisher_Recogniser(string filename)
    {
        //Lets get the recogniser type from the file extension
        string ext = Path.GetExtension(filename);
        recognizer = new FisherFaceRecognizer(0, 3500);//4000

        //introduce error checking
        recognizer.Read(filename);

        //Now load the labels
        string direct = Path.GetDirectoryName(filename);
        Names_List.Clear();
        if (File.Exists(direct + "/Labels.xml"))
        {
            FileStream filestream = File.OpenRead(direct + "/Labels.xml");
            long filelength = filestream.Length;
            byte[] xmlBytes = new byte[filelength];
            filestream.Read(xmlBytes, 0, (int)filelength);
            filestream.Close();

            MemoryStream xmlStream = new MemoryStream(xmlBytes);

            using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
            {
                while (xmlreader.Read())
                {
                    if (xmlreader.IsStartElement())
                    {
                        switch (xmlreader.Name)
                        {
                            case "NAME":
                                if (xmlreader.Read())
                                {
                                    Names_List.Add(xmlreader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
            ContTrain = NumLabels;
        }
        _IsTrained = true;

    }

    /// <summary>
    /// Dispose of Class call Garbage Collector
    /// </summary>
    public void Dispose()
    {
        recognizer = null;
        trainingImages = null;
        Names_List = null;
        Error = null;
        GC.Collect();
    }

    #endregion

    #region Private
    /// <summary>
    /// Loads the traing data given a (string) folder location
    /// </summary>
    /// <param name="Folder_location"></param>
    /// <returns></returns>
    private bool LoadTrainingData(string Folder_location)
    {
        if (File.Exists(Folder_location + "\\TrainedLabels.xml"))
        {
            try
            {
                //message_bar.Text = "";
                Names_List.Clear();
                Names_List_ID.Clear();
                trainingImages.Clear();
                FileStream filestream = File.OpenRead(Folder_location + "\\TrainedLabels.xml");
                long filelength = filestream.Length;
                byte[] xmlBytes = new byte[filelength];
                filestream.Read(xmlBytes, 0, (int)filelength);
                filestream.Close();

                MemoryStream xmlStream = new MemoryStream(xmlBytes);

                using (XmlReader xmlreader = XmlTextReader.Create(xmlStream))
                {
                    while (xmlreader.Read())
                    {
                        if (xmlreader.IsStartElement())
                        {
                            switch (xmlreader.Name)
                            {
                                case "NAME":
                                    if (xmlreader.Read())
                                    {
                                        Names_List_ID.Add(Names_List.Count); //0, 1, 2, 3....
                                        Names_List.Add(xmlreader.Value.Trim());
                                        NumLabels += 1;
                                    }
                                    break;
                                case "FILE":
                                    if (xmlreader.Read())
                                    {
                                        //PROBLEM HERE IF TRAININGG MOVED
                                        trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "\\TrainedFaces\\" + xmlreader.Value.Trim()));
                                    }
                                    break;
                            }
                        }
                    }
                }
                ContTrain = NumLabels;

                if (trainingImages.ToArray().Length != 0)
                {

                    //Eigen face recognizer
                    //Parameters:	
                    //      num_components – The number of components (read: Eigenfaces) kept for this Prinicpal 
                    //          Component Analysis. As a hint: There’s no rule how many components (read: Eigenfaces) 
                    //          should be kept for good reconstruction capabilities. It is based on your input data, 
                    //          so experiment with the number. Keeping 80 components should almost always be sufficient.
                    //
                    //      threshold – The threshold applied in the prediciton. This still has issues as it work inversly to LBH and Fisher Methods.
                    //          if you use 0.0 recognizer.Predict will always return -1 or unknown if you use 5000 for example unknow won't be reconised.
                    //          As in previous versions I ignore the built in threhold methods and allow a match to be found i.e. double.PositiveInfinity
                    //          and then use the eigen distance threshold that is return to elliminate unknowns. 
                    //
                    //NOTE: The following causes the confusion, sinc two rules are used. 
                    //--------------------------------------------------------------------------------------------------------------------------------------
                    //Eigen Uses
                    //          0 - X = unknown
                    //          > X = Recognised
                    //
                    //Fisher and LBPH Use
                    //          0 - X = Recognised
                    //          > X = Unknown
                    //
                    // Where X = Threshold value


                    recognizer = new FisherFaceRecognizer(0, 3500);//4000

                    recognizer.Train(trainingImages.ToArray(), Names_List_ID.ToArray());

                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return false;
            }
        }
        else return false;
    }
    #endregion
}

