from control.matlab import *


def task8():
    K1 = 0.1
    K2 = 10
    K3 = 1
    T1 = 1
    T2 = 1
    T3 = 1
    T4 = 1
    W1 = tf([K1], [T1, 1])
    W2 = tf([K2], [1, 0])
    W3 = tf([K3 * T3, K3 * 1], [T4, 1])
    W4 = feedback(W1, W2)
    W5 = W4 * W3
    W6 = W1 + W2
    W7 = feedback(W5, W6)
    print(W7)

    y, x = step(W7)
    p = pole(W7)
    for i in p:
        print(i)
        if i == 0.:
            print("Система нейтральна")
            break

        if isinstance(i, complex):
            if i.real < 0:
                print("Система устойчива с колебаниями")
                break
            if i.real > 0:
                print("Система неустойчива с колебаниями")
                break
        else:
            if i < 0:
                print("Система устойчива без колебаний")
                break
            if i > 0:
                print("Система неустойчива без колебаний")
                break
    print(p)
