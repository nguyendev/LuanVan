#include "LoadImages.h"

LoadImages::LoadImages()
{
}


LoadImages::~LoadImages()
{
}

LoadImages::LoadImages(string folder, int type)
{
	folder = _folder;
	type = _type;
}
void LoadImages::Handling(vector<Mat> &Images, vector<int> &labels)
{
	vector<string> names_ofFiles = getNamesOfFileLocal(_folder);
	for (int i = 0; i < names_ofFiles.size() - 1; ++i)
	{
		// Path "C://NegativeSample/" + i th "Filename.jpg"

		String cesta = _folder + names_ofFiles[i];
		// Read image into Mat container
		Mat img = imread(cesta, IMREAD_COLOR);
		// Store images in vector you can use later for example in own ML training
		Images.push_back(img);

		// Display single image
		//namedWindow("Display", WINDOW_AUTOSIZE);
		//imshow("Display", img);
		int key1 = waitKey(10);
		// Increase number of positive samples in StoredImages
		// Later we push into same vector negative samples
		// and we need to know, where the boundary is
		labels.push_back(i);
	}
}

vector<string> LoadImages::getNamesOfFileLocal(string folderPath)
{
	// vector of names of file within a folder 
	vector<string> names_ofFiles;

	char search[200];
	// convert your string search path into char array
	sprintf(search, "%s*.*", folderPath.c_str());

	//  WIN32_FIND_DATA is a structure
	// Contains information about the file that is found by the FindFirstFile 
	WIN32_FIND_DATA Info;
	// Find first file inside search path
	HANDLE Find = ::FindFirstFile(search, &Info);

	// If  FindFirstFile(search, &fd); fails return INVALID_HANDLE_VALUE,
	// If Find is not equal to INVALID_HANDLE_VALUE do the loop inside the
	// IF condition

	if (Find != INVALID_HANDLE_VALUE) {
		do {

			// DWORD dwFileAttributes , FILE_ATTRIBUTE_DIRECTORY ident a directory
			// If condition is fine lets push file mane into string vector
			if (!(Info.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)) {
				// Fill vector of names
				names_ofFiles.push_back(Info.cFileName);

			}

			// do - while there is next file
			//::FindNextFile the function succeeds, the return value is nonzero and the Info contain //information about next file

		} while (::FindNextFile(Find, &Info));
		::FindClose(Find);
	}

	// Return result
	return names_ofFiles;
}
