import matplotlib.pyplot as plt
import numpy as np
from scipy.optimize import curve_fit

A_0 = 0.2
alpha_0 = 7
D_0 = 1e-7
betta_0 = 10
default_coeffs = [A_0, alpha_0, D_0, betta_0]

u_0 = 0
u_n = 0.7


def iu_f(u, A, alpha, D, betta):
    return A * u * np.exp(-alpha * u) + D * (np.exp(betta * u) - 1)


default_us = [0, 0.07, 0.14, 0.21, 0.28, 0.35, 0.42, 0.49, 0.56, 0.63, 0.7]
default_is = [0, 0.009, 0.0092, 0.0075, 0.0045, 0.003, 0.002, 0.0015, 0.0017, 0.003, 0.012]

k, s = curve_fit(iu_f, default_us, default_is, default_coeffs)
[A, alpha, D, betta] = k

print(k)
print(default_coeffs)

aus = np.arange(u_0, u_n, 0.001)
ais = list(map(lambda u: iu_f(u, A, alpha, D, betta), aus))


plt.plot(default_us, default_is, '*')
plt.plot(aus, ais)
plt.grid()
plt.show()