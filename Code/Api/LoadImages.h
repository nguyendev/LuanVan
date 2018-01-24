#pragma once
#include "opencv2\highgui.hpp"
#include "opencv2\imgproc.hpp"
#include <vector>
#include <fstream>
#include <stdio.h>
#include <iostream>
#include <Windows.h>
#include <opencv2/imgproc.hpp>
#include <iomanip>
#include <opencv2/core.hpp>
#include <opencv2/highgui.hpp>
using namespace std;
using namespace cv;

class LoadImages
{
private:
	string _folder; //url or folder
	int _type; //type = 1 folder, type =2 url
public:
	LoadImages();
	LoadImages(string folder, int type);
	~LoadImages();
	vector<string> getNamesOfFileLocal(string folderPath);
	string GetFolder(){ return _folder; }
	// Find images in folder or url
	void Create(string folder, int type) { _folder = folder; _type = type; }
	int GetType() { return _type; }
	void SetType(int type) { _type = type; }
	// Load all images and display
	void Handling(vector<Mat> &Images,	vector<int> &labels); 
};

