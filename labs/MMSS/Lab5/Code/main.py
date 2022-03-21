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
        y1, y2, y3 = y
        return [
            y1_der(y1, y2, y3),
            y2_der(y1, y2, y3),
            y3_der_u(u)(y1, y2, y3)
        ]

    return scipy.integrate.odeint(pend, y0, t)


def main():
    K = 35  # Nm
    Kt = 0.4  # Nm/A
    L = 1  # G
    R = 0.56  # Om
    Ke = 0.4  # Nm/(Vs)
    u = 3  # V
    C = 0.3  # Farad
    J = 0.8  # N/m

    t = np.linspace(0, 10, 3000)
    y0 = [0, 0, 0]

    ls = [0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1]
    mxh = []
    for _l in ls:
        model = create_model(y0, t, K, Kt, _l, R, Ke, u, C, J)
        ys_t = model[:, 0]
        mxh.append(np.max(ys_t))
        plt.plot(ys_t, linewidth=1, linestyle='-.')
    plt.show()

    min_n = 4
    max_n = 4
    for n in range(min_n, max_n + 1):
        k = np.polyfit(ls, mxh, n)
        print('Power of polynom: ', n)
        print('Coeff approx: ', k)
        approx_fun = np.poly1d(k)
        _ls = np.linspace(0, 1, 100)
        plt.plot(_ls, list(map(lambda t: approx_fun(t), _ls)),
                 linewidth=1,
                 linestyle='--')
    plt.plot(ls, mxh, '*', c='red')
    plt.grid()
    plt.show()

    # plt.plot(Y[:, 1], c='red')
    # plt.legend(['tetta\'(t)'])
    # plt.show()
    #
    # plt.plot(Y[:, 2], c='orange')
    # plt.legend(['i(t)'])
    # plt.show()


if __name__ == '__main__':
    main()
