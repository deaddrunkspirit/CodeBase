hours_start = int(input())
min_start = int(input())
sec_start = int(input())
hours_end = int(input())
min_end = int(input())
sec_end = int(input())
hours = (hours_end - hours_start) * 3600
minuites = (min_end - min_start) * 60
seconds = (sec_end - sec_start)
print(hours + minuites + seconds)
