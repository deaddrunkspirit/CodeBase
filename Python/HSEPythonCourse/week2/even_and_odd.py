def isEven(a, b, c):
    if a % 2 == 0 or b % 2 == 0 or c % 2 == 0:
        return 1
    else:
        return 0


def isOdd(a, b, c):
    if a % 2 == 1 or b % 2 == 1 or c % 2 == 1:
        return 1
    else:
        return 0


n1 = int(input())
n2 = int(input())
n3 = int(input())
if isEven(n1, n2, n3) == 1 and isOdd(n1, n2, n3) == 1:
    print('YES')
else:
    print('NO')
