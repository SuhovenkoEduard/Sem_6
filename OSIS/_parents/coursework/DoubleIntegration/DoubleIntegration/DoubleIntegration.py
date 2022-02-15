import sys
import argparse
import math
from scipy import integrate

def createParser ():
    parser = argparse.ArgumentParser()
    parser.add_argument ('-A', '--A', default=-3)
    parser.add_argument ('-B', '--B', default=1)
    parser.add_argument ('-C', '--C', default=-5)
    parser.add_argument ('-Xn', '--Xn', default=-40)
    parser.add_argument ('-Xk', '--Xk', default=40)
    parser.add_argument ('-Yn', '--Yn', default=-80)
    parser.add_argument ('-Yk', '--Yk', default=80)
    return parser
 
if __name__ == '__main__':
    parser = createParser()
    namespace = parser.parse_args(sys.argv[1:])
    A = namespace.A
    B = namespace.B
    C = namespace.C
    Xn = namespace.Xn
    Xk = namespace.Xk
    Yn = namespace.Yn
    Yk = namespace.Yk

    f = lambda y, x: math.sqrt(1 + (A + C * math.cos(y) * math.cos(x))**2 + (B - C * math.sin(x) * math.sin(y))**2)
    
    value = integrate.dblquad(f, Xn, Xk, lambda x: Yn, lambda x: Yk)

    with open("value.txt", "w") as file:
        file.write(value)


