#include <iostream>
#include "section.h"

using namespace std;

int main()
{	
	double f_x1, f_x2, f_y1, f_y2;
	double s_x1, s_x2, s_y1, s_y2;
	
	setlocale(0,"");
	
	cout << "Enter x1 for first section: ";
	cin >> f_x1;
	cout << "Enter x2 for first section: ";
	cin >> f_x2;
	cout << "Enter y1 for first section: ";
	cin >> f_y1;
	cout << "Enter y2 for first section: ";
	cin >> f_y2;
	
	cout << "Enter x1 for second section: ";
	cin >> s_x1;
	cout << "Enter x2 for second section: ";
	cin >> s_x2;
	cout << "Enter y1 for second section: ";
	cin >> s_y1;
	cout << "Enter y2 for second section: ";
	cin >> s_y2;

	Section first(f_x1, f_x2, f_y1, f_y2);
	Section second(s_x1, s_x2, s_y1, s_y2);

	if (first._GetLength() > second._GetLength())
	{
		cout << "First section is longer";
	} else if (first._GetLength() < second._GetLength())
	{
		cout << "Second section is longer";
	} else {
		cout << "Length of both sections is equal.";
	}
	
	if (first._IsParallelToOX == true) {
		cout << "First section is parallel to OX axis.";
	}
	
	if (second._IsParallelToOX == true) {
		cout << "Second section is parallel to OX axis.";
	}
	
	if (first._IsParallelToOX != true && second._IsParallelToOX != true)
	{
		cout << "Both sections are not parallel to OX axis.";
	}
	
	return 0;
}
