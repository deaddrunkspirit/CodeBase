from bs4 import BeautifulSoup
import urllib.request
import ssl

ctx = ssl.create_default_context()
ctx.check_hostname = False
ctx.verify_mode = ssl.CERT_NONE


def next_url():
    current_position = 1
    for tag in tags:
        if current_position == position:
            return tag.get('href', None), tag.contents[0]
        current_position += 1


url = input('Enter - ')
count = int(input('Count - '))
position = int(input('Position - '))
answer = None

for i in range(count):
    html = urllib.request.urlopen(url, context=ctx).read()
    soup = BeautifulSoup(html, 'html.parser')
    tags = soup('a')
    url, answer = next_url()

print(answer)
