import sys
import argparse
import matplotlib.pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import numpy as np
import math

def createParser ():
    parser = argparse.ArgumentParser()
    parser.add_argument ('-A', '--A', default=-3)
    parser.add_argument ('-B', '--B', default=1)
    parser.add_argument ('-C', '--C', default=-5)
    parser.add_argument ('-Xn', '--Xn', default=-40)
    parser.add_argument ('-Xk', '--Xk', default=40)
    parser.add_argument ('-Yn', '--Yn', default=-80)    
    parser.add_argument ('-Yk', '--Yk', default=80)
    parser.add_argument ('-step', '--step', default=0.5)
    return parser
 
if __name__ == '__main__':
    parser = createParser()
    namespace = parser.parse_args(sys.argv[1:])

    x = np.arange(namespace.Xn, namespace.Xk, namespace.step)
    y = np.arange(namespace.Yn, namespace.Yk, namespace.step)
    X, Y = np.meshgrid(x, y)

    Z = namespace.A * X + namespace.B * Y + namespace.C * np.sin(X) * np.cos(Y)

    fig = plt.figure()
    ax = fig.add_subplot(111, projection='3d')

    ax.plot_surface(X, Y, Z)

    ax.set_xlabel('X')
    ax.set_ylabel('Y')
    ax.set_zlabel('Z')

    plt.show()


