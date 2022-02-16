#include "func.h"
int main()
{
	setlocale(0, "");
	double x, y, z;
	cout << "Enter x: ";
	cin >> x;
	cout << "Enter y: ";
	cin >> y;
	cout << "Enter z: ";
	cin >> z;
	double b = func(x, y, z);
	cout << "\nb = " << b << endl;
	return 1;
}
