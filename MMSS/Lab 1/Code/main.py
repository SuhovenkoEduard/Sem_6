import numpy as np
import matplotlib.pyplot as plt
import matplotlib.animation as animation
from prettytable import PrettyTable

fig = plt.figure(facecolor='white')

ax = plt.axes(xlim=(-1, 2), ylim=(0, 1.5))
line, = ax.plot([], [], lw=3)
lin1, = ax.plot([], [])
lin2, = ax.plot([], [])
lin3, = ax.plot([], [])
ax.grid(True)

AB = 0.91
OA = 0.80
AC = 0.52
S0 = 1.185
Vb = 0.862
YY0 = 0.551
omega = 2.247

t = np.linspace(0, 1.2, 100)
S1 = S0 - Vb * t
YY = YY0 + omega * t
Fi = np.arccos(((-AB ** 2) + (S1 ** 2) + (OA ** 2)) / (2 * OA * S1))

XA = OA * np.cos(Fi)
YA = OA * np.sin(Fi)

XC = XA - AC * np.cos(Fi - YY)
YC = YA - AC * np.sin(Fi - YY)

# table
my_table = PrettyTable()
my_table.field_names = ["№", "t", "fi", "ax", "ay", "cx", "cy"]
for i in range(len(t)):
    my_table.add_row((i, t[i], Fi[i], XA[i], YA[i], XC[i], YC[i]))
print(my_table)

ymax = np.max(YC)
ind = np.where(YC == ymax)
xmax = XC[ind]

print('y max = ', ymax)
print('x max = ', xmax)
print('t = ', t[ind])


def redraw(i):
    x = XC[i]
    y = YC[i]
    x1 = XA[i]
    y1 = YA[i]
    x2 = S1[i]
    lin1.set_data([x, x1], [y, y1])
    lin2.set_data([0, x1], [0, y1])
    lin3.set_data([x2, x1], [0, y1])
    return lin1, lin2, lin3


plt.plot(XC, YC)
anim = animation.FuncAnimation(fig, redraw, frames=100, interval=50)
plt.show()