#include <iostream>
#include <list>
#include "func.h"

using namespace std;

void Sort(list<int> &list)
{
	for ( auto i = list.begin(); i != list.end();)
	{
		int value = *i;
		i = list.erase(i);
		auto place = list.begin();
		for( auto j = list.begin(); j != i; j++)
		{
			if(value > *j)
			{
				place = j;
				place++;
			}
		}
		list.insert(place, value);
	}
}