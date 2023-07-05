number = int(input())
n1 = number % 10
n2 = (number // 10) % 10
n3 = (number // 100) % 10
n4 = number // 1000
if n1 == n4 and n2 == n3:
    print(1)
else:
    print(0)
