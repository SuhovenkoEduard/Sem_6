#pragma once
#include <forward_list>
#include <list>
#include <algorithm>
#include <stdlib.h>

using namespace std;

void show_flst(forward_list<int> numbers);
int get_forwards_lst_size(forward_list<int> numbers);
int get_item_by_id(forward_list<int> numbers, int id);
forward_list<int> change_value_by_id(forward_list<int> numbers, int id, int new_value);
forward_list<int> add_item(forward_list<int> numbers, int new_item);
forward_list<int> remove_item_by_id(forward_list<int> numbers, int id);
forward_list<int> sort_by_bubble(forward_list<int> numbers);
void hoara_sort(forward_list<int> &numbers, int left, int right);
void my_fun(forward_list<int> numbers);