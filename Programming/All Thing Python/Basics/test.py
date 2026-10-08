import numpy as np

temps_f = np.array([32, 68, 100, 212])
temps_c = (temps_f - 32) * 5/9
print(temps_c)