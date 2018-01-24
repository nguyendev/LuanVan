#include "Eyes.h"



Eyes::Eyes()
{
}

void Eyes::LoadCascadeClassifier()
{
	haar_cascade.load(_fn_haar);
}
Eyes::~Eyes()
{
}
void Eyes::DetectEye(Mat face, vector<cv::Rect> &eyes, Mat &frame)
{

	/*haar_cascade.detectMultiScale(face, eyes, 1.1, 2, 0 | CV_HAAR_SCALE_IMAGE, cv::Size(20, 20));

	for (size_t j = 0; j < eyes.size(); j++)
	{
		Point center(face.x + eyes[j].x + eyes[j].width*0.5, face.y + eyes[j].y + eyes[j].height*0.5);
		int radius = cvRound((eyes[j].width + eyes[j].height)*0.25);
		circle(frame, center, radius, Scalar(255, 0, 0), 4, 8, 0);
	}*/
}
