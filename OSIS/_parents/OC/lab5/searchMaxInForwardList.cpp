#include "searchMaxInForwardList.h"

int getMaxValue(forward_list<int> fl) {
	int max = INT32_MIN;

	for (int n : fl)
		if (n < 0 && n > max) {
			max = n;
		}
	return max;
}