import numpy as np
import scipy.misc
from matplotlib import pyplot as plt
from scipy.optimize import curve_fit
from scipy import integrate

xs = [3, 3.3, 3.4, 3.6, 3.85, 4, 4.2]
ys = [-4, -2, 2, 8, 17, 29, 45]


def y_f(x, a, b):
    return a * np.exp(x) + b * x ** 2

def main():
    k, s = curve_fit(y_f, xs, ys)
    [a, b] = k
    axs = np.arange(xs[0], xs[-1], 0.01)
    ays = list(map(lambda x: y_f(x, a, b), axs))

    get_delt = lambda a, b: np.abs(a - b)

    # mx_i = 0
    # mx_delt = get_delt(ys[mx_i], ays[mx_i])
    #
    # for i in range(len(xs)):
    #     cur_delt = get_delt(ys[i], ays[i])
    #     if mx_delt < cur_delt:
    #         mx_delt = cur_delt
    #         mx_i = i

    # print('Max delt: ', mx_delt)
    # print('(x, y): ', xs[mx_i], ys[mx_i])
    # print('(ax, ay): ', xs[mx_i], ays[mx_i])

    def len_f(x):
        return np.sqrt(1 + scipy.misc.derivative(lambda x: y_f(x, a, b), x, dx=1.0, n=1) ** 2)

    full_dist = integrate.quad(len_f, xs[0], xs[-1])
    print('Full distance: ', full_dist)
    print(xs[0], xs[-1])

    plt.plot(axs, ays)
    plt.plot(xs, ys, '*')
    # plt.scatter(xs[mx_i], ys[mx_i])
    # plt.scatter(xs[mx_i], ays[mx_i])
    plt.grid()
    plt.show()


if __name__ == '__main__':
    main()
