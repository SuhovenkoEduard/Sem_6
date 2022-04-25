from control.matlab import *
import matplotlib.pyplot as plt


def typical_task1():
    # integral
    k = 1
    w = tf([k], [1, 0])  # k / s
    y, x = step(w)
    plt.plot(x, y)
    plt.grid()
    plt.show()

    # diff
    k = 1
    w = tf([k, 0], [1, 1])  # k * s / (s + 1)
    y, x = step(w)
    plt.plot(x, y)
    plt.grid()
    plt.show()

    # aperiodic
    K = 1
    T1 = 1.6
    T2 = 5
    ro = T2 / (2 * T1)
    w = tf([K], [T1 ** 2, 2 * ro * T1, 1])  # k / (t1 ** 2 * s ** 2 + 2 * ro * t1 * s + 1)
    y, x = step(w)
    plt.plot(x, y)
    plt.grid()
    plt.show()

    # colebatic
    k = 1
    t1 = 5
    t2 = 1.6
    g = t2 / (2 * t1)
    w = tf([k], [t1 ** 2, 2 * g * t1, 1]) # k / (t1 ** 2 * s ** 2 + 2 * g * t1 * s + 1)
    y, x = step(w)
    plt.plot(x, y)
    plt.grid()
    plt.show()
