#include <iostream>
#include "./function/function.cpp"

using namespace std;

int main()
{
    double x, y, z;
    printf("Enter x: ");
    scanf("%lf", &x);
    printf("Enter y: ");
    scanf("%lf", &y);
    printf("Enter z: ");
    scanf("%lf", &z);
    double ans = my_function(x, y, z);
    printf("b = %6.2lf\n", ans);
    return 0;
}