height = int(input())
width = int(input())
wedges = int(input())
if wedges < height * width and (wedges % height == 0 or wedges % width == 0):
    print('YES')
else:
    print("NO")
