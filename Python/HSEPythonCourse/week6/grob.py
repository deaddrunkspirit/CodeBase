n1 = int(input())
villages = map(int, input().split())
n2 = int(input())
safe_zone = list(map(int, input().split()))
for i in range(len(safe_zone)):
    safe_zone[i] = [i + 1, safe_zone[i]]
safe_zone.sort(key=lambda x: x[1])


def find_value(x):
    if (x < safe_zone[0][1]):
        return safe_zone[0][0]
    if (x > safe_zone[-1][1]):
        return safe_zone[-1][0]
    l = 0
    r = len(safe_zone) - 1
    while (r - l > 1):
        n2 = (r + l) >> 1
        if (safe_zone[n2][1] < x):
            l = n2
        else:
            r = n2
    if (x - safe_zone[l][1] < safe_zone[r][1] - x):
        return safe_zone[l][0]
    else:
        return safe_zone[r][0]


print(*[find_value(v) for v in villages])
