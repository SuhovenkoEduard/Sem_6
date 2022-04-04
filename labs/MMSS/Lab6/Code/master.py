import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt


def create_model(y0, t, K, Kt, L, R, Ke, u, C, J):
    def y1_der(y1, y2, y3):
        return y2

    def y2_der(y1, y2, y3):
        return 1. / J * (-C * y2 - K * y1 + Kt * y3)

    def y3_der_u(u):
        return lambda y1, y2, y3: 1. / L * (u - R * y3 - Ke * y2)

    def pend(y, t):
        cur_u = 0
        if t > 2:
            cur_u = u

        y1, y2, y3 = y
        return [
            y1_der(y1, y2, y3),
            y2_der(y1, y2, y3),
            y3_der_u(cur_u)(y1, y2, y3)
        ]

    return scipy.integrate.odeint(pend, y0, t)


def main():
    K = 35  # Nm
    Kt = 0.4  # Nm/A
    L = 0.01  # G
    R = 0.56  # Om
    Ke = 0.4  # Nm/(Vs)
    u = 3  # V
    C = 0.3  # Farad
    J = 0.8  # N/m

    t = np.linspace(0, 20, 3000)
    y0 = [0, 0, 0]

    model = create_model(y0, t, K, Kt, L, R, Ke, u, C, J)
    plt.plot(t, model[:, 0], c='blue')
    plt.legend(['tetta(t)'])

    xs = model[:, 0]
    lastX = xs[-1]
    lastY = t[len(xs) - 1]

    upY = lastX + 0.05 * lastX
    downY = lastX - 0.05 * lastX
    print(lastX, lastY)

    plt.plot(t, [upY] * len(t))
    plt.plot(t, [downY] * len(t))

    plt.grid()
    plt.show()
    # plt.plot(model[:, 1], c='red')
    # plt.legend(['tetta\'(t)'])
    # plt.show()
    #
    # plt.plot(model[:, 2], c='orange')
    # plt.legend(['i(t)'])
    # plt.show()


if __name__ == '__main__':
    main()
