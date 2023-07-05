a = int(input())
b = int(input())
isDivisible = a % b == 0
print('YES' * int(isDivisible) + 'NO' * (1 - int(isDivisible)))
