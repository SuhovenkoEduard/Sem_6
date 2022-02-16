#include <iostream>
#include <list>
#include "func.h"
using namespace std;

void Sort(list<int> &list)
{
	for (auto i = list.begin(); i != list.end(); i++)
	{
		auto min = i;
		for(auto j = i; j != list.end(); j++)
		{
			if(*min > *j)
				min = j;
		}
		int value = *i;
		*i = *min;
		*min = value;
	}
}