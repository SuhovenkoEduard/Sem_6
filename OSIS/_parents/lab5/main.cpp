#include <iostream>
#include <forward_list>
#include <iterator>
#include "searchMaxInForwardList.h"

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");
	forward_list<int> numbers = { 1, -10, 2, 3,-15, 5,-1, -3, 4, -3, 5 };

	print(numbers);

	int max = getMaxValue(numbers);

	if (max == INT32_MIN) {
		cout << "Нет отрицательных чисел" << endl;
	}
	else {
		cout << "Максимальное число из отрицательных чисел = " << max << endl;
	}

	sort(&numbers, 0, size(numbers) - 1);

	print(numbers);

	system("pause");
	return 0;
}