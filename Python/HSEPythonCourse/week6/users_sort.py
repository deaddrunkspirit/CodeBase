#data_input = open('input.txt', 'r', encoding='utf8')
#data_output = open('output.txt', 'w', encoding='utf8')
#data = data_input.readlines()
data = ['Bob Marley 13 37', 'Good Boy 14 88']
pupils = []
for line in data:
    pupils.append(tuple(map(str, line.split())))
print(pupils)



