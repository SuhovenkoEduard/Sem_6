#include <iostream>
#include "functionality.h"

#include "add_item.cpp"
#include "change_value_by_id.cpp"
#include "get_forwards_lst_size.cpp"
#include "get_item_by_id.cpp"
#include "hoara_sort.cpp"
#include "my_fun.cpp"
#include "remove_item_by_id.cpp"
#include "show_flist.cpp"
#include "sort_by_bubble.cpp"


int main()
{
    forward_list<int> numbers({1, 100, 1, 6, 5, 4, 3, 2, 1});
    bool flag = true;
    while (flag)
    {
        printf("\033c");
        cout << "1. Show elements." << endl;
        cout << "2. Add an element in front." << endl;
        cout << "3. Remove an element by id." << endl;
        cout << "4. Sort elements." << endl;
        cout << "5. Use my function." << endl;
        cout << "6. Exit." << endl;
        int choice;
        cin >> choice;
        switch (choice)
        {
        case 1:
            show_flst(numbers);
            break;
        case 2:
            int elem;
            cout << "Enter new value: ";
            cin >> elem;
            numbers = add_item(numbers, elem);
            break;
        case 3:
            int id;
            cout << "Enter id: ";
            cin >> id;
            numbers = remove_item_by_id(numbers, id);
            break;
        case 4:
            // cout << "Sort by bubble ----> " << endl;
            // numbers = sort_by_bubble(numbers);
            cout << "Quick sort (Hoara) ----> " << endl;
            hoara_sort(numbers, 0, get_forwards_lst_size(numbers) - 1);
            break;
        case 5:
            my_fun(numbers);
            break;
        case 6:
            flag = false;
            break;
        default:
            cout << "Wrong data. Try again." << endl;
            break;
        }
        cout << "Press any key to continue..." << endl;
        char key;
        cin >> key;
    }
    return 0;
}