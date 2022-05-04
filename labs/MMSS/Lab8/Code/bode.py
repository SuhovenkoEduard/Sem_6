import numpy as np
from control.matlab import *
import matplotlib.pyplot as plt


def bodeFunc():
    num = [0., 1.]
    den = [1., 2., 10.]
    w = tf(num, den)
    mag, phase, omega = bode(w)
    plt.plot()
    plt.show()
    plt.figure(3)

    mx = np.max(mag)
    mxi = 0
    for i in range(len(mag)):
        if mx == mag[i]:
            mxi = i

    # print(mxi, mx, omega[mxi])
    print('Omega: ', omega[mxi])
    print('Max frequency: ', mx)

    plt.plot(omega, mag)
    plt.plot(omega[mxi], mx, '*')
    plt.show()