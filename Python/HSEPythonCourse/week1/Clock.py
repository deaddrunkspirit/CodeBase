def format_clock(value):
    if value < 10:
        return '0' + str(value)
    else:
        return str(value)


total_sec = int(input())
cur_sec = total_sec % 60
total_min = total_sec // 60
cur_min = total_min % 60
total_hours = total_min // 60
cur_hours = total_hours % 24
print(f'{cur_hours}:{format_clock(cur_min)}:{format_clock(cur_sec)}')
