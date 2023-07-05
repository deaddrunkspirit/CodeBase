x1 = int(input())
y1 = int(input())
x2 = int(input())
y2 = int(input())
white1 = (x1 + y1) % 2 == 0
white2 = (x2 + y2) % 2 == 0
no_back_move = y2 > y1
diag_limit = abs(x2 - x1) <= y2 - y1
possible_moves = white1 * white2 * no_back_move * diag_limit
print('YES' * possible_moves + 'NO' * (not possible_moves))
