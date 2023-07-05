import math as mt

p = int(input())
x = int(input())
y = int(input())
k = int(input())
total = x * 100 + y
while k != 0:
    total += int(total * p / 100)
    k -= 1

print(f'{int(total // 100)} {int(total % 100)}')
