#include "searchMaxInForwardList.h"

void sort(forward_list<int> *list, int left, int right) // ���������� ���������
{
	cout << "Buble" << endl;
	int temp = 0; // ��������� ���������� ��� �������� �������� �������
	bool exit = false; // ������� ���������� ��� ������ �� �����, ���� ������ ������������
	int i = 0;
	while (!exit) // ���� ������ �� ������������
	{
		exit = true;
		auto begin = list->begin();
		auto end = list->end();
		while (begin != end) {
			auto next = begin;
			next++;
			if (next !=end && *begin > *next) // ���������� ��� �������� ��������
			{
				// ��������� ������������ ��������� �������
				swap(begin, next);
				exit = false; // �� ��������� �������� ���� ����������� ������������ ���������
			}
			i++;
			begin++;
		}
	}
}