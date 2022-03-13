// function.c
#include <stdio.h>
#include <math.h>
#include <string.h>

double my_function(double x, double y, double z)
{
    return exp(fabs(x - y)) * pow(tan(z) * tan(z) + 1, x);
}