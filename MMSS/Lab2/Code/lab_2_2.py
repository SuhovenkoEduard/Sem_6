import numpy as np
import matplotlib.pyplot as plt
import math

alpha = 3.2
betta = 109 * math.pi / 180
k1 = 0.314
k2 = 0.122
v = 1.3


def psi(phi):
    return k1 * np.sin(phi) + k2


phi_m = 2 * math.pi
phi1 = 0.25 * phi_m
phi2 = 0.75 * phi_m
phi3 = phi_m

coeffs = [
    [np.cos(phi1 + alpha), np.cos(psi(phi1) + betta), 1],
    [np.cos(phi2 + alpha), np.cos(psi(phi2) + betta), 1],
    [np.cos(phi3 + alpha), np.cos(psi(phi3) + betta), 1]
]

right = [
    np.cos(phi1 + alpha - psi(phi1) - betta),
    np.cos(phi2 + alpha - psi(phi2) - betta),
    np.cos(phi3 + alpha - psi(phi3) - betta)
]

ps = np.linalg.solve(coeffs, right)
a = 1 / ps[1]
c = -1 / ps[0]
b = np.sqrt(a ** 2 + c ** 2 + 1 - 2 * c * a * ps[2])


def vu(phi):
    one_square = a ** 2 + 1 - 2 * a * np.cos(phi)
    return np.arcsin((b ** 2 + c ** 2 - one_square) / (2 * b * c))


def f0(phi):
    return np.cos(phi + alpha)


def f1(phi):
    return np.cos(psi(phi) + betta)


def f2(phi):
    return 1


def big_f(phi):
    return np.cos(phi + alpha - psi(phi) - betta)


def delta_q(phi):
    return -2 * a * c * (ps[0] * f0(phi) + ps[1] * f1(phi) + ps[2] * f2(phi) - big_f(phi))


def delta_psi(phi):
    return delta_q(phi) / (2 * b * c * np.cos(vu(phi)))

# exist because vu(0) < 1.38
print(a, b, c)
phis = np.arange(0, 2 * np.pi, 0.01)
psis = []
delta_psis = []

mx_phi = 0
mx_i = 0
mx_delt = -1e9

for i in range(len(phis)):
    phi = phis[i]
    psis.append(psi(phi))
    delta_psis.append(psi(phi) + delta_psi(phi))
    delta = np.abs(psis[len(psis) - 1] - delta_psis[len(delta_psis) - 1])
    if mx_delt < delta:
        mx_delt = delta
        mx_phi = phi
        mx_i = i

print(mx_phi, mx_delt)

plt.plot(phis, psis)
plt.plot(phis, delta_psis)

plt.scatter(mx_phi, psis[mx_i])
plt.scatter(mx_phi, delta_psis[mx_i])

plt.show()