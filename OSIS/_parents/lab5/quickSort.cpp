#include "searchMaxInForwardList.h"

void sort(forward_list<int> *list, int left, int right) {

	int i = left, j = right;
	int tmp;
	int pivot = get(*list,(left + right) / 2);

	/* partition */
	while (i <= j) {
		while (get(*list,i) < pivot)
			i++;
		while (get(*list, j) > pivot)
			j--;
		if (i <= j) {
			swap(list, i, j);
			i++;
			j--;
		}
	};
	/* recursion */

	if (left < j)
		sort(list, left, j);
	if (i < right)
		sort(list, i, right);

}