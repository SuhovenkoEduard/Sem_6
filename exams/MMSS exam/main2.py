import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt
from scipy.signal import find_peaks
from control.matlab import *


def create_model(y0, t, m, b, k):
    def y1_der(y1, y2):
        return y2

    def y2_der(y1, y2, ft):
        return 1. / m * (ft - b * y2 - k * y1)

    def pend(y, t):
        if t < 0:
            cur_f = 0
        else:
            cur_f = 1

        y1, y2 = y
        return [
            y1_der(y1, y2),
            y2_der(y1, y2, cur_f)
        ]

    return scipy.integrate.odeint(pend, y0, t)


def main():
    m = 5
    b = 0.21
    k = 0.5

    t = np.linspace(0, 250, 3000)
    y0 = [0, 0]

    model = create_model(y0, t, m, b, k)

    plt.plot(t, model[:, 0], c='blue')
    plt.legend('m(t)')
    plt.show()


if __name__ == '__main__':
    main()
