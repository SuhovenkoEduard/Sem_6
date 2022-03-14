import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt

K = 35 # Nm
Kt = 0.4 # Nm/A
L = 0.01 # G
R = 0.56 # Om
Ke = 0.4 # Nm/(Vs)
u = 3 # V
C = 0.3 # Farad
J = 0.8 # N/m

t = np.linspace(-6, 6, 3000)
y0 = [0.05, 0, 0]


def y1_der(y1, y2, y3):
    return y2


def y2_der(y1, y2, y3):
    return 1. / J * (-C * y2 - K * y1 + Kt * y3)


def y3_der(y1, y2, y3):
    return 1. / L * (u - R * y3 - Ke * y2)


def pend(y, t):
    y1, y2, y3 = y
    return [
        y1_der(y1, y2, y3),
        y2_der(y1, y2, y3),
        y1_der(y1, y2, y3)
    ]


def main():
    Y = scipy.integrate.odeint(pend, y0, t)
    plt.plot(Y[:, 0], c='green')
    plt.plot(Y[:, 1], c='red')
    plt.plot(Y[:, 2], c='orange')
    plt.show()


if __name__ == '__main__':
    main()