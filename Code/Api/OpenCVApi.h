#pragma once
#include "LoadImages.h"
#include "Face.h"
#include "Eyes.h"
class OpenCVApi
{
public:
	LoadImages _loadImages;
	Face _face;
	Eyes _eyes;
	OpenCVApi();
	~OpenCVApi();
};

