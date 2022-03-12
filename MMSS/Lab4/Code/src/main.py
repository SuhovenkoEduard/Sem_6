from src.constants.constants import average_ms, xs, count_experiments, index_arrays
from src.table.table import to_table
import numpy as np


def get_b_array(num, x_arr, y_arr):
    def get_multiple_b(indexes):
        return sum([np.prod([x_arr[i][index] for index in indexes]) * y_arr[i] for i in
                    range(count_experiments)]) / count_experiments

    return [get_multiple_b(index_array) for index_array in index_arrays[:num]]


def get_y(b_arr, x_arr):
    res = []
    for i in range(count_experiments):
        cur_y = 0
        for j in range(len(b_arr)):
            cur_y += b_arr[j] * np.prod([x_arr[i][index] for index in index_arrays[j]])
        res.append(cur_y)
    return np.array(res)


def calc_error(y_arr_left, y_arr_right):
    return np.abs(y_arr_left - y_arr_right)


def main():
    print('\nAverage expert: ', average_ms, end='\n\n')
    count_person = len(average_ms)
    for b_index in range(4, 9):
        cur_bs = []
        cur_ys = []
        cur_errors = []
        for i in range(count_person):
            b_array = get_b_array(b_index, xs, average_ms[i])
            y_array = get_y(b_array, xs)

            cur_bs.append(b_array)
            cur_ys.append(y_array)
            cur_errors.append(calc_error(y_array, average_ms))
        average_errors = np.array(list(map(lambda row: np.average(cur_errors), cur_errors)))
        average_error = np.average(average_errors)
        print(f'Current model, step({b_index - 4}), average error: ', average_error)
        print(to_table(cur_ys))
        print('Coefficients: ')
        print(to_table(cur_bs), end='\n\n')


if __name__ == '__main__':
    main()
