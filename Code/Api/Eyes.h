#pragma once
#include <iostream>
#include <opencv2/face.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/objdetect.hpp>
#include <opencv2/core.hpp>
#include <fstream>
#include <sstream>
using namespace std;
using namespace cv;
using namespace cv::face;
class Eyes
{
private:
	string _fn_haar;
public:
	CascadeClassifier haar_cascade;
	string SetFnHaar(string fn_haar) { return _fn_haar = fn_haar; }
	void LoadCascadeClassifier();
	void DetectEye(Mat face, vector<cv::Rect> &eyes, Mat &frame);
	Eyes();
	~Eyes();

};

