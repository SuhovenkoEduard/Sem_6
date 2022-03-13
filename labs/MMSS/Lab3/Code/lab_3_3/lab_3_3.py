import matplotlib.pyplot as plt
import numpy as np
import sympy as sm

ys = np.loadtxt('./res/tan1.dat', dtype=np.float64, delimiter='\r\n')
xs = np.linspace(0, 10, len(ys))

mx_i = 0
mn_i = 0

for i in range(len(xs)):
    if ys[mx_i] < ys[i]:
        mx_i = i
    if ys[mn_i] > ys[i]:
        mn_i = i

interest_xs = xs[mx_i:mn_i][::100]
interest_ys = ys[mx_i:mn_i][::100]

axs = np.arange(xs[mx_i], xs[mn_i], 0.001)
k = np.polyfit(interest_xs, interest_ys, 3)
polynom = np.poly1d(k)
ays = list(map(np.poly1d(k), axs))

x = sm.symbols('x')
sym_f = k[0] * x ** 3 + k[1] * x ** 2 + k[2] * x + k[3]

derivative_f = sm.diff(sym_f, x)
num_f = sm.lambdify([x], derivative_f, modules='numpy')
print(sym_f)
print(derivative_f)

plt.plot(interest_xs, interest_ys, '*')
plt.plot(axs, ays)
plt.grid()
plt.show()

plt.plot(axs, list(map(num_f, axs)))
plt.grid()
plt.show()