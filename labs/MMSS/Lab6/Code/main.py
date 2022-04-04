import matplotlib.pyplot as plt
import math as mt
import numpy as np
from scipy.integrate import odeint

m = 10
c = 2
k = 11
k_dop = 9


def system_of_equations_first(y, x):
    if x > 10:
        temp = 1
    else:
        temp = 0

    y0 = y[0]
    y1 = y[1]
    y2 = ((-c * y1 - k * y0 - k_dop * y0 ** 3) / m) + temp
    return y1, y2


def Task1():
    init = 0, 0
    x = np.linspace(0, 80, 1000)

    sol = odeint(system_of_equations_first, init, x)
    plt.plot(x, sol[:, 0], color='b')

    return sol


sol = Task1()

xx = np.linspace(0, 80, 1000)
mass_x = sol[:, 0]
point = mass_x[len(mass_x) - 1]
point_first = point + 0.05 * point
point_second = point - 0.05 * point

x1 = 0, 80
y1 = point_first, point_first
y2 = point_second, point_second

plt.plot(x1, y1)
plt.plot(x1, y2)

lastY = sol[1][0]
for i in range(1, 1000):
    el = sol[i][0]
    eli = sol[i - 1][0]
    if el >= point_second > eli:
        lastY = sol[i][0]
    elif sol[i][1] <= point_first < sol[i - 1][0]:
        lastY = sol[i][0]

index = 0
for i in range(1, 1000):
    if sol[i][0] == lastY:
        index = i

lastX = xx[index]

countKoleb = 0
koleb = np.linspace(1, 1000)
for i in range(1, 1000):
    if (xx[i] >= lastX):
        break
    if sol[i][0] < sol[i + 1][0] and sol[i + 1][0] > sol[i + 2][0]:
        koleb[countKoleb + 1] = mt.fabs(sol[i][0])
        countKoleb = countKoleb + 1
    elif sol[i][0] > sol[i + 1][0] and sol[i + 1][0] < sol[i + 2][0]:
        koleb[countKoleb + 1] = mt.fabs(sol[i][0])
        countKoleb = countKoleb + 1

Amax = koleb[1]
decr = koleb[1] / koleb[2]

plt.plot(lastX, lastY, '*')
plt.show()

print("Время переходного процесса", xx[index] - 1)

print(Amax, "Максимальное амплитуда отклонения")
KoefD = 1 + Amax
print(KoefD, "Коэффициент динамичности")
print(decr, "Декремент")
print(countKoleb, "Колебательность")

maxValY = Amax
pereregulir = (maxValY)
print(pereregulir, "Перерегулирование")
