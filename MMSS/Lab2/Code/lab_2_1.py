import numpy as np
import matplotlib.pyplot as plt
import math

FI1 = 45 * math.pi / 180
FI2 = 22.5 * math.pi / 180
FI3 = 67.5 * math.pi / 180
S1 = 1.2
S2 = 1.4
S3 = .95
A4 = .1
BETA = 100


def is_exist(a1, a2, a3):
    if a1 < a2 - a3:
        return True
    return False


def find_parameters(f, s):
    matrix = []
    vector = []

    for i in range(len(f)):
        matrix.append([s[i] * math.cos(f[i]),  math.sin(f[i]), - 1])
        vector.append([s[i] ** 2])

    K = np.linalg.solve(matrix, vector)

    return K


def s_f(i, A1, A2, A3, H):
    return A1 * math.cos(i) + math.sqrt(A2 ** 2 - (A3 * H - A1 * math.sin(i)) ** 2)


if __name__ == '__main__':
    K = find_parameters([FI1, FI2, FI3], [S1, S2, S3])
    print(K)

    A1 = K[0] / 2
    A3 = K[1] / (2 * A1)
    A2 = math.sqrt(A1 ** 2 + A3 ** 2 - K[2])
    print(A1, A2, A3)

    if A3 > 0:
        H = 1
    else:
        H = -1
    print(H)
    print(is_exist(A1, A2, A3))

    FI = np.arange(0, 2 * np.pi, 0.01)

    S = []
    for i in FI:
        value = s_f(i, A1, A2, A3, H)
        S.append(value[0])
    print(S)

    yy_i = 0
    res = []
    while yy_i < len(FI):
        eps = 1e-2
        if np.abs(S[yy_i] - 1.2) < eps:
            res.append(FI[yy_i])
            yy_i += 100
        yy_i += 1

    plt.plot(FI, S)
    plt.scatter(res[0], 1.2, color='orange', s=40, marker='*')
    plt.scatter(res[1], 1.2, color='orange', s=40, marker='*')
    plt.grid()
    plt.show()




