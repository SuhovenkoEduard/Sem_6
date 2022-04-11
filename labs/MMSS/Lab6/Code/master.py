import numpy as np
import scipy.integrate
import matplotlib.pyplot as plt
from scipy.signal import find_peaks


def create_model(y0, t, K, Kt, L, R, Ke, u, C, J, heavysideTime):
    def y1_der(y1, y2, y3):
        return y2

    def y2_der(y1, y2, y3):
        return 1. / J * (-C * y2 - K * y1 + Kt * y3)

    def y3_der_u(u):
        return lambda y1, y2, y3: 1. / L * (u - R * y3 - Ke * y2)

    def pend(y, t):
        cur_u = 0
        if t > heavysideTime:
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
    heavysideTime = 2

    model = create_model(y0, t, K, Kt, L, R, Ke, u, C, J, heavysideTime)
    plt.plot(t, model[:, 0], c='blue')
    plt.legend(['tetta(t)'])

    ys = model[:, 0]
    establishedY = ys[-1]
    lastX = t[len(ys) - 1]

    upY = establishedY + 0.05 * establishedY
    downY = establishedY - 0.05 * establishedY
    print('establishedPoint:', lastX, establishedY, '[s, rad]')

    plt.plot(t, [upY] * len(t), linestyle='--')
    plt.plot(t, [downY] * len(t), linestyle='--')

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
    lastIndexX = idIs[-1]

    stabilizationCorridor = [downY, upY]
    timeOfProcess = lastIntersectionX - heavysideTime
    aMax = np.max(ys) - establishedY
    dynamicCoefficient = 1 + aMax / establishedY

    # decrement
    peaksMaxima, _ = find_peaks(ys, height=downY)
    peaksMinima, _ = find_peaks(-1 * ys, height=-upY)
    decrementOfFluctuations = ((ys[peaksMaxima[0]] - establishedY) / (establishedY - ys[peaksMinima[0]]))

    print('stabilizationCorridor: ', stabilizationCorridor, '[rad, rad]')
    print('establishedY:', establishedY, 'rad')
    print('timeOfProcess:', timeOfProcess, 's')
    print('aMax:', aMax, 'rad')
    print('dynamicCoefficient:', dynamicCoefficient)
    print("decrementOfFluctuations: ", decrementOfFluctuations)

    pMax, _ = find_peaks(ys[:lastIndexX], height=upY)
    pMin, _ = find_peaks(-1 * ys[:lastIndexX], height=-downY)
    print('Oscillation:', len(pMin) + len(pMax))
    plt.plot(t[pMax], list(map(lambda i: ys[i], pMax)), 'x')
    plt.plot(t[pMin], list(map(lambda i: ys[i], pMin)), 'x')
    plt.plot(idXs[-1], idYs[-1], '*', c='red')
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
