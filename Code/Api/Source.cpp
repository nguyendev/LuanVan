///*
//* Copyright (c) 2011. Philipp Wagner <bytefish[at]gmx[dot]de>.
//* Released to public domain under terms of the BSD Simplified license.
//*
//* Redistribution and use in source and binary forms, with or without
//* modification, are permitted provided that the following conditions are met:
//*   * Redistributions of source code must retain the above copyright
//*     notice, this list of conditions and the following disclaimer.
//*   * Redistributions in binary form must reproduce the above copyright
//*     notice, this list of conditions and the following disclaimer in the
//*     documentation and/or other materials provided with the distribution.
//*   * Neither the name of the organization nor the names of its contributors
//*     may be used to endorse or promote products derived from this software
//*     without specific prior written permission.
//*
//*   See <http://www.opensource.org/licenses/bsd-license>
//*/
//
//#define _CRT_SECURE_NO_WARNINGS
//#include <opencv2/core.hpp>
//#include <opencv2/face.hpp>
//#include <opencv2/highgui.hpp>
//#include <opencv2/imgproc.hpp>
//#include <opencv2/objdetect.hpp>
//#include <iostream>
//#include "OpenCVApi.h"
//#include <Windows.h>
//
//#include <fstream>
//#include <sstream>
//using namespace cv;
//using namespace cv::face;
//using namespace std;
//static Mat norm_0_255(InputArray _src) {
//	Mat src = _src.getMat();
//	// Create and return normalized image:
//	Mat dst;
//	switch (src.channels()) {
//	case 1:
//		cv::normalize(_src, dst, 0, 255, NORM_MINMAX, CV_8UC1);
//		break;
//	case 3:
//		cv::normalize(_src, dst, 0, 255, NORM_MINMAX, CV_8UC3);
//		break;
//	default:
//		src.copyTo(dst);
//		break;
//	}
//	return dst;
//}
//static void read_csv(const string& filename, vector<Mat>& images, vector<int>& labels, char separator = ';') {
//	std::ifstream file(filename.c_str(), ifstream::in);
//	if (!file) {
//		string error_message = "No valid input file was given, please check the given filename.";
//		CV_Error(Error::StsBadArg, error_message);
//	}
//	string line, path, classlabel;
//	while (getline(file, line)) {
//		stringstream liness(line);
//		getline(liness, path, separator);
//		getline(liness, classlabel);
//		if (!path.empty() && !classlabel.empty()) {
//			images.push_back(imread(path, 0));
//			labels.push_back(atoi(classlabel.c_str()));
//		}
//	}
//
//
//}
//
//int main(int argc, const char *argv[]) {
//	vector<Mat> StoredImages;
//	vector<int> labels;
//	OpenCVApi* openCV = new OpenCVApi();
//	openCV->_loadImages.Create("D://GitHub/DATN3/Api/s1/", 1);
//	openCV->_loadImages.Handling(StoredImages, labels);
//
//	openCV->_face.Create();
//	openCV->_face.SetFnHaar("E:\\opencv\\sources\\data\\haarcascades\\haarcascade_frontalface_default.xml");
//	openCV->_face.Train(StoredImages,labels);
//	
//	openCV->_eyes.SetFnHaar("E:\\opencv\\sources\\data\\haarcascades\\haarcascade_eye_tree_eyeglasses.xml.xml");
//	if (StoredImages.size() <= 0) {
//		string error_message = "This demo needs at least 2 images to work. Please add more images to your data set!";
//		CV_Error(Error::StsError, error_message);
//	}
//	// Get the height from the first image. We'll need this
//	// later in code to reshape the images to their original
//	// size:
//	int im_width = StoredImages[0].cols;
//	int im_height = StoredImages[0].rows;
//
//	openCV->_face.LoadCascadeClassifier();
//	if (openCV->_face.haar_cascade.empty())
//		return 0;
//	openCV->_eyes.LoadCascadeClassifier();
//	if (openCV->_eyes.haar_cascade.empty())
//		return 0;
//
//
//	// Get a handle to the Video device:
//	VideoCapture cap(0);
//	// Check if we can use this device at all:
//	if (!cap.isOpened()) {
//		cerr << "Capture Device ID cannot be opened." << endl;
//		return -1;
//	}
//	// Set video to 320x240
//	cap.set(CV_CAP_PROP_FRAME_WIDTH, 320);
//	cap.set(CV_CAP_PROP_FRAME_HEIGHT, 240);
//
//	// Holds the current frame from the Video device:
//	Mat frame;
//	for (;;) {
//		cap >> frame;
//		
//
//		// Clone the current frame:
//		Mat original = frame.clone();
//		//resize(frame, original, cv::Size(350, 300));
//		// Convert the current frame to grayscale:
//		Mat gray;
//		cvtColor(original, gray, COLOR_BGR2GRAY);
//		// Find the faces in the frame:
//		vector< Rect_<int> > faces;
//		vector<cv::Rect> eyes;
//		openCV->_face.haar_cascade.detectMultiScale(gray, faces, 1.4,10);
//		openCV->_eyes.haar_cascade.detectMultiScale(gray, faces, 1.4, 10);
//
//		// At this point you have the position of the faces in
//		// faces. Now we'll get the faces, make a prediction and
//		// annotate it in the video. Cool or what?
//
//
//
//		for (size_t i = 0; i < faces.size(); i++) {
//			// Process face by face:
//			Rect face_i = faces[i];
//			// Crop the face from the image. So simple with OpenCV C++:
//			Mat face = gray(face_i);
//
//			/*openCV->_eyes.DetectEye(faces[i], eyes, frame);*/
//			// Resizing the face is necessary for Eigenfaces and Fisherfaces. You can easily
//			// verify this, by reading through the face recognition tutorial coming with OpenCV.
//			// Resizing IS NOT NEEDED for Local Binary Patterns Histograms, so preparing the
//			// input data really depends on the algorithm used.
//			//
//			// I strongly encourage you to play around with the algorithms. See which work best
//			// in your scenario, LBPH should always be a contender for robust face recognition.
//			//
//			// Since I am showing the Fisherfaces algorithm here, I also show how to resize the
//			// face you have just found:
//			Mat face_resized;
//			cv::resize(face, face_resized, Size(im_width, im_height), 1.0, 1.0, INTER_CUBIC);
//			//openCV->_face.model->train(face_resized, 1000);
//			// Now perform the prediction, see how easy that is:
//			int prediction = openCV->_face.model->predict(face_resized);
//			// And finally write all we've found out to the original image!
//			// First of all draw a green rectangle around the detected face:
//			rectangle(original, face_i, Scalar(0, 255, 0), 1);
//			// Create the text we will annotate the box with:
//			string box_text = format("Prediction = %d", prediction);
//			// Calculate the position for annotated text (make sure we don't
//			// put illegal values in there):
//			int pos_x = max(face_i.tl().x - 10, 0);
//			int pos_y = max(face_i.tl().y - 10, 0);
//			// And now put it into the image:
//			putText(original, box_text, Point(pos_x, pos_y), FONT_HERSHEY_PLAIN, 1.0, Scalar(0, 255, 0), 2);
//		}
//		// Show the result:
//		imshow("face_recognizer", original);
//		// And display it:
//		char key = (char)waitKey(20);
//		// Exit this loop on escape:
//		if (key == 27)
//			break;
//	}
//	return 0;
//}
