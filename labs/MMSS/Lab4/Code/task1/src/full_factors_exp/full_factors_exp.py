def to_binary_array(num):
    res = []
    while num:
        res.append(num % 2)
        num //= 2
    while len(res) < 3:
        res.append(0)
    return res


def to_factors_array(binary_array):
    return [(-1 if i == 0 else 1) for i in binary_array]


def get_full_factors_exp(factor_number):
    res = []
    max_value = 2 ** factor_number
    for i in range(0, max_value):
        binary_array = to_binary_array(i)
        factors_array = to_factors_array(binary_array)
        res.append(factors_array)
    return res