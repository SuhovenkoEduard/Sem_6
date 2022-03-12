import numpy as np
from src.full_factors_exp.full_factors_exp import get_full_factors_exp

count_factors = 3
ms_t = np.array([
    [1.983, 1.951, 1.969, 1.981, 1.935],
    [3.004, 3.024, 2.984, 2.983, 3.007],
    [2.435, 2.415, 2.428, 2.394, 2.438],
    [3.767, 3.794, 3.784, 3.783, 3.803],
    [2.788, 2.823, 2.815, 2.777, 2.773],
    [4.491, 4.467, 4.492, 4.473, 4.460],
    [3.485, 3.510, 3.515, 3.524, 3.475],
    [5.883, 5.879, 5.863, 5.870, 5.877]
])

average_ms_t = np.array([np.average(measures_of_persons) for measures_of_persons in ms_t])

average_ms = np.array([average_ms_t.transpose()])
xs = np.array(get_full_factors_exp(count_factors))
count_experiments = 2 ** count_factors

index_arrays = [
    [],
    [0],
    [1],
    [2],
    [0, 1],
    [0, 2],
    [1, 2],
    [0, 1, 2]
]
