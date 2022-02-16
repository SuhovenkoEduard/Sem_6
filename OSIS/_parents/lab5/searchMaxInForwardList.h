#include <forward_list>
#include <iostream>

using namespace std;

int getMaxValue(forward_list<int> fl);
void print(forward_list<int> list);
void swap(forward_list<int>::iterator first, forward_list<int>::iterator second);
int size(forward_list<int> list);
void sort(forward_list<int> *list, int left, int right);
int get(forward_list<int> list, int index);
void swap(forward_list<int> *list, int x, int y);
