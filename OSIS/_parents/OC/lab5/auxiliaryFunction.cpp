#include "searchMaxInForwardList.h"

void print(forward_list<int> list) {
	auto begin = list.begin();
	auto end = list.end();
	while (begin != end)
	{
		cout << *begin << " ";
		begin++;
	}
	cout << endl;
}

int size(forward_list<int> list) {
	int count = 0;
	auto begin = list.begin();
	auto end = list.end();
	while (begin != end)
	{
		begin++;
		count++;
	}
	return count;
}

void swap(forward_list<int>::iterator first, forward_list<int>::iterator second) {
	if (first != second) {
		int temp = *first;
		*first = *second;
		*second = temp;
	}

}

int get(forward_list<int> list, int index) {
	int i = 0;
	auto begin = list.begin();
	auto end = list.end();
	while (begin != end && i != index)
	{
		begin++;
		i++;
	}
	return *begin;
}

void swap(forward_list<int> *list, int x, int y) {
	auto begin = list->begin();
	auto end = list->end();
	forward_list<int>::iterator first = begin;
	forward_list<int>::iterator second = begin;
	int i = 0;
	while (begin != end)
	{
		if (i == x) {
			first = begin;
		}
		if (i == y) {
			second = begin;
		}
		begin++;
		i++;
	}
	if (first != second) {
		int temp = *first;
		*first = *second;
		*second = temp;
	}

}