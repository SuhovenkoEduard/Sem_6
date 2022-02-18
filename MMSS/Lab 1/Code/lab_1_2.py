import numpy as np
import matplotlib.pyplot as plt

fi_1 = 1.75
fi_2 = 3.18
fi_3 = 5.22
a_1 = 8.2
a_2 = 6.0
omega_0 = 1.256
v = 0.675

b_1 = (2 * np.pi) / fi_1
b_2 = (2 * np.pi) / (fi_3 - fi_2)

t_1 = (2 * np.pi) / (b_1 * omega_0)
t_2 = fi_2 / omega_0
t_3 = t_2 + ((2 * np.pi) / (b_2 * omega_0))


def getS11(t):
    res = []
    for ti in t:
        if 0 <= ti < t_1:
            res.append(a_1 * np.sin(b_1 * omega_0 * ti))
        elif t_1 <= ti < t_2:
            res.append(0)
        elif t_2 <= ti < t_3:
            res.append(a_2 * np.sin(b_2 * omega_0 * ti))
        else:
            res.append(0)
    return res


def myInter(a, t, s11):  # 0: 0-0, 1: 0-1, 2: 0-2, i: 0-i
    ret = []
    for i in range(len(t)):
        x = []
        y = []

        for j in range(i):
            x.append(s11[j])
            y.append(t[j])

        ret.append(np.trapz(x, y))

    print(ret)
    return ret


# Нахождение функции
lim = int((2 * np.pi) / omega_0)
t = np.arange(0, lim, 0.01)

S11 = getS11(t)

plt.plot(t, S11)
# plt.axis([0, lim, -10, 10])
plt.grid()
plt.show()

F = []
for si in S11:
    F.append((omega_0 ** 2) * si)

S1 = myInter(0, t, S11)

plt.plot(t, S1)
# plt.axis([0, lim, -10, 10])
plt.grid()
plt.show()

###################

S = myInter(0, t, S1)

plt.plot(t, S)
# plt.axis([0, lim, -10, 10])
plt.grid()
plt.show()

R1 = S1 / np.tan(v)
R0 = np.min(R1)

R = R0 + S

X = R * np.sin(omega_0 * t)
Y = R * np.cos(omega_0 * t)

plt.plot(X, Y)
# plt.axis([-4, 4, -4, 4])
plt.grid()
plt.show()

plt.show()
