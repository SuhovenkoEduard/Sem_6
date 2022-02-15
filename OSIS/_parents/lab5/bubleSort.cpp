#include "searchMaxInForwardList.h"

void sort(forward_list<int> *list, int left, int right) // сортировка пузырьком
{
	cout << "Buble" << endl;
	int temp = 0; // временная переменная для хранения элемента массива
	bool exit = false; // болевая переменная для выхода из цикла, если массив отсортирован
	int i = 0;
	while (!exit) // пока массив не отсортирован
	{
		exit = true;
		auto begin = list->begin();
		auto end = list->end();
		while (begin != end) {
			auto next = begin;
			next++;
			if (next !=end && *begin > *next) // сравниваем два соседних элемента
			{
				// выполняем перестановку элементов массива
				swap(begin, next);
				exit = false; // на очередной итерации была произведена перестановка элементов
			}
			i++;
			begin++;
		}
	}
}