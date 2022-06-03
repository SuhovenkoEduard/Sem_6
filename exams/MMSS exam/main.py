import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt
from scipy.signal import find_peaks
from control.matlab import *


def create_model(y0, t, m, n, k):
    def f(t):
        return np.sin(t)

    def y1_der(y1, y2):
        return y2

    def y2_der(y1, y2, ft):
        return 1. / m * (ft - n * y2 - k * y1)

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
    m = 1.34
    n = 0.35
    k = 3.7

    t = np.linspace(0, 50, 3000)
    y0 = [0, 0]

    model = create_model(y0, t, m, n, k)
    ys = model[:, 0]
    establishedY = ys[-1]
    lastX = t[len(ys) - 1]

    upY = establishedY + 0.05 * establishedY
    downY = establishedY - 0.05 * establishedY
    print('establishedPoint:', lastX, establishedY, '[s, rad]')

    peaksMaxima, _ = find_peaks(ys, height=downY)
    peaksMinima, _ = find_peaks(-1 * ys, height=-upY)
    decrementOfFluctuations = ((ys[peaksMaxima[0]] - establishedY) / (establishedY - ys[peaksMinima[0]]))
    print("decrementOfFluctuations: ", decrementOfFluctuations)

    eps = 1e-5
    idXs = []
    idYs = []
    idIs = []
    for i in range(len(t)):
        time = t[i]
        yi = ys[i]
        if np.abs(yi - upY) < eps or np.abs(yi - downY) < eps:
            idXs.append(time)
            idYs.append(yi)
            idIs.append(i)

    lastIntersectionX = idXs[-1]

    print('timeOfProcess', lastIntersectionX)
    plt.plot(idXs[-1], idYs[-1], '*', c='red')

    K = 1
    A, B, C = [m, n, k] # [1.34, 5, 3.7]
    W = tf([K], [A, B, C])
    yws, xws = step(W)

    print('Roots: ', pole(W))

    plt.plot(t, [upY] * len(t), linestyle='--')
    plt.plot(t, [downY] * len(t), linestyle='--')

    plt.plot(xws, yws, c='green')
    plt.show()
    # # plt.legend('m(t)')

    # plt.plot(t, model[:, 0], c='blue')
    # plt.legend('m(t)')
    # plt.show()


if __name__ == '__main__':
    main()
