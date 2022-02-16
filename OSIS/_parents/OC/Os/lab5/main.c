#include <iostream>
#include <list>
#include "func.h"

using namespace std;

int main()
{
	int n;
	setlocale(0,"");
	cout << "Enter List size: ";
	cin >> n;
	list<int> list;
	
	for (int i = 0; i < n; i++)
	{
		cout << "Enter" << i << " element: " << endl;
		int element;
		cin >> element;
		list.push_back(element);
	}
	
	cout << "List: ";
	for ( auto i = list.begin(); i != list.end(); i++)
		cout << *i << " ";
	cout << endl;
	Task(list);
	Sort(list);
	cout << endl << "Sorted list: ";
	
	for ( auto i = list.begin(); i != list.end(); i++)
		cout << *i << " ";
	cout << endl;
	
	return 0;
} 


