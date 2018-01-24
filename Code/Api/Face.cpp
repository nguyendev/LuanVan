#include "Face.h"

void Face::Create()
{
}
void Face::LoadCascadeClassifier()
{
	haar_cascade.load(_fn_haar);
}
void Face::Train(vector<Mat> &Images, vector<int> &labels)
{
	model->train(Images, labels);
}

Face::Face()
{
}


Face::~Face()
{
}
