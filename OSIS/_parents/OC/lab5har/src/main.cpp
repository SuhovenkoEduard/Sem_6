#include <iostream>
#include "Sorts.h"
#include "Func.h"
using namespace std;
int main() 
{

	int size = 6;
	int arr[size] = { -5, -12, 12, 9,-10, 0,};

	
	cout << "Task: " << Task(arr,size)  << endl;
	cout << "Array" << endl;
	for(int i=0;i<size;i++)
		cout <<arr[i] << endl;
	cout <<endl<< "ArrayAfterSort" << endl;
	Pyzirok(arr,size);
	for(int i=0;i<size;i++)
		cout <<arr[i] << endl;
}