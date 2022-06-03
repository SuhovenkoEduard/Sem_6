import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt

a, b, c = [1.7, 0.2, 2.3]

def u(t):
    if 0 <= t <= 4:
        return 2.7
    elif 4 < t < 17:
        return 3 * np.sin(t)
    else:
        return 0.65 * t


def y1_der(y1, y2):
    return y2


def y2_der(y1, y2, t):
    return 1. / a * (u(t) - b * y2 - c * y1)


def pend(y, t):
    y1, y2 = y
    return [
        y1_der(y1, y2),
        y2_der(y1, y2, t)
    ]


def main():
    ts = np.linspace(0, 100, 3000)
    y0 = [0, 0]

    model = scipy.integrate.odeint(pend, y0, ts)

    plt.plot(ts, model[:, 0], c='blue')
    plt.legend('m(t)')
    plt.show()

    plt.plot(ts, model[:, 1], c='blue')
    plt.show()


if __name__ == '__main__':
    main()
