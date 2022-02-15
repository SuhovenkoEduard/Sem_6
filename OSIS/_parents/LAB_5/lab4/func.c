#include "func.h"
#include <math.h>
double func(double x, double y, double z)
{
	return (pow(exp(sin(x)), 1/3) * cos(y) / (pow(z, 2) + 1));
}
