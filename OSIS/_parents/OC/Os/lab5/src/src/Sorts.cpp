#include "Sorts.h"

void Sort1(list<int> &list)
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

void Sort2(list<int> &list)
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
