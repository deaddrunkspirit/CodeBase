import os

open_data = open((os.path.dirname(os.path.abspath(__file__)) + '/test.txt'), "r")
data = open_data.read().split()
n = 0
result = {}
for i in data:
    if n % 4 == 0:
        result[data[n]] = (data[n + 1], data[n + 3])
    n += 1
for j in sorted(result.keys()):
    print
    ' '.join(map(str, (j, ' '.join(map(str, result[j])))))