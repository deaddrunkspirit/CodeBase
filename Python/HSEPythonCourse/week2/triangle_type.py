import math


def change(a, b):
    a += b
    b = a - b
    a -= b
    return a, b


a = int(input())
b = int(input())
c = int(input())
if a + b <= c or a + c <= b or b + c <= a or a + b + c <= 0:
    print('impossible')
else:
    if b < c:
        b, c = change(b, c)
    if a < b:
        a, b = change(a, b)
    if b < c:
        b, c = change(b, c)
    if a < b:
        a, b = change(a, b)
    if a ** 2 == b ** 2 + c ** 2:
        print('rectangular')
    else:
        alpha = math.acos((b * b + c * c - a * a) / (2 * b * c))
        if alpha < math.pi / 2:
            print('acute')
        else:
            print('obtuse')
