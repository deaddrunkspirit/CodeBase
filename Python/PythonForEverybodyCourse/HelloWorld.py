import re

y = re.findall("\S+?@\S+", "From stephen.marquard@uct.ac.za Sat Jan  5 09:14:16 2008")
print(y)
