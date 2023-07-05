x = int(input())
y = int(input())
if x == 1 or y % (y - x + 1) == 0:
    print('YES')
else:
    print('NO')
