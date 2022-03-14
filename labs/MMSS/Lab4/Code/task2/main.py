import numpy as np
import matplotlib.pyplot as plt

# 1
xs = [0.1, 2.89, 8.77, 5.25, 12.34, 2.61, 10.65, 4.55, 1.37, 2.2, 14.82, 1.78, 0.13, 7.97, 9.02, 2.49, 6.76, 0.85,
      11.74, 7.79]
ys = [2.72, 4.92, 7.53, 5.41, 7.17, 10.25, 7.49, 6.78, 2.21, 6.66, 2.91, 7.25, 7.01, 5.93, 8.88, 7.44, 9.65, 6.91,
      10.93, 8.73]

# 12
# xs = [18.99, 1.92, 15.60, 19.01, 6.44, 14.181, 18.23, 19.18, 20.07, 9.68, 7.78, 9.40, 0.01, 17.01, 1.97, 15.04, 3.38, 1.06, 0.40]
# ys = [9.71, 2.61, 4.12, 12.58, 5.56, 3.48, 3.474, 14.56, 0.34, 2.27, 0.13, 9.65, 6.21, 1.36, 10.48, 9.86, 8.03, 0.80, 3.89]

average_x = np.sum(xs) / len(xs)
average_y = np.sum(ys) / len(ys)

r = np.sum([(xs[i] - average_x) * (ys[i] - average_y) for i in range(len(xs))]) \
    / (np.sqrt(np.sum([(x - average_x) ** 2 for x in xs])) * np.sqrt(np.sum([(y - average_y) ** 2 for y in ys])))

print(f'The correlation coefficient: {r}')
print('The connection is ', end='')
if r < 0.3:
    print('Weak', end='')
elif r < 0.5:
    print('Normal', end='')
elif r < 0.7:
    print('Good', end='')
elif r < 0.9:
    print('Powerful', end='')
elif r <= 1:
    print('Very strong', end='')
print('.')

plt.scatter(xs, ys)
plt.grid()
plt.show()
