#include "Func.h"

void Task(list<int> &list)
{
	auto min = list.begin();
	for ( auto i = list.begin(); i != list.end(); i++)
	{
		if(*min > *i)
			min = i;
	}
	cout << "Minimal number:" << *min;
}
