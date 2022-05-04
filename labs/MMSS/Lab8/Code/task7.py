from control.matlab import *
import matplotlib.pyplot as plt


def task7():
    K = 1
    A1 = 15
    B1 = 39
    C1 = 100

    # 39 / 2 * sqrt(15) = 5.03 >= 1 - апериодическое

    A2 = 30
    B2 = 75
    C2 = 15

    # 75 / (2 * sqrt(30)) = 6.84 >= 1 - апериодическое

    A3 = 5000
    B3 = -10
    C3 = 2

    # -10 / (2 * sqrt(5000)) = -0.07 < 1 - колебательный

    A4 = 40
    B4 = -85
    C4 = 21

    # -85 / (2 * sqrt(40)) = -6.71 < 1 - колебательный

    W1 = tf([K], [A1, B1, C1])
    W2 = tf([K], [A2, B2, C2])
    W3 = tf([K], [A3, B3, C3])
    W4 = tf([K], [A4, B4, C4])
    print('Устойчива с колебаниями', pole(W1))
    print('Устойчива без колебаний', pole(W2))
    print('Неустойчива с колебаниями', pole(W3))
    print('Неустойчива без колебаний', pole(W4))

    y1, x1 = step(W1)
    y2, x2 = step(W2)
    y3, x3 = step(W3)
    y4, x4 = step(W4)

    fig, axs = plt.subplots(2, 2)

    axs[0, 0].plot(x1, y1)
    axs[0, 0].set_title('Устойчива с колебаниями')
    # plt.plot(x1, y1)
    # plt.show()

    axs[0, 1].plot(x2, y2, 'tab:orange')
    axs[0, 1].set_title('Устойчива без колебаний')
    # plt.plot(x2, y2)
    # plt.show()

    axs[1, 0].plot(x3, y3, 'tab:green')
    axs[1, 0].set_title('Неустойчива с колебаниями')
    # plt.plot(x3, y3)
    # plt.show()

    axs[1, 1].plot(x4, y4, 'tab:red')
    axs[1, 1].set_title('Неустойчива без колебаний')
    # plt.plot(x4, y4)
    # plt.show()

    for ax in axs.flat:
        ax.set(xlabel='Время', ylabel='Переходная характеристика')

    for ax in axs.flat:
        ax.label_outer()
    plt.grid()
    plt.show()
