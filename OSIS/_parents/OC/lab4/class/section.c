#include "Section.h"
#include <math.h>

Section::Section(double X1, double X2, double Y1, double Y2)

{
	x1 = X1;
	x2 = X2;
	y1 = Y1;
	y2 = Y2;
}

bool Section::_IsParallelToOX()
{
	return (y1 == y2);
}

double Section::_GetLength()
{
	return sqrt( (pow(x1 - x2), 2) + (pow(y1 - y2), 2) );
}

