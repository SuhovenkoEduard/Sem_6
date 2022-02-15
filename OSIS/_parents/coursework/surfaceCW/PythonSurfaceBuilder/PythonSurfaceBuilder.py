import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np
import math

Xn = -40
Xk = 40
Yn = -80
Yk = 80

x = np.arange(Xn, Xk, 0.5)
y = np.arange(Yn, Yk, 0.5 )
X, Y = np.meshgrid(x, y)


A = -3
B = 1
C = -5

Z = A*X+B*Y+C*np.sin(X)*np.cos(Y)

fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')

ax.plot_surface(X, Y, Z)

ax.set_xlabel('X')
ax.set_ylabel('Y')
ax.set_zlabel('Z')

plt.show()
