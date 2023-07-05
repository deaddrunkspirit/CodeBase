import re

file_path = 'regex_sum_776633.txt'
result = 0
handler = open(file_path, 'r')
lines = handler.read()
res = re.findall('[0-9]+', lines)
for num in res:
    result += float(num)
print(result)
