import socket

client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('localhost', 8089))


data = client.recv(2048)
print(data.decode('utf8'))
authorization_successful = False
authentication_successful = False
print('Starting authorization process')
while not authorization_successful:
    client.send(input('Input login: ').encode('utf8'))
    client.send(input('Input password: ').encode('utf8'))
    if client.recv(2048).decode('utf8') == 'Authorization success':
        authorization_successful = True
        print('Authorization successful')
    else:
        print('Authorization failed. Check login/password')
print('Starting authentication process')
while not authentication_successful:
    client.send(input("Input token: ").encode('utf8'))
    client.send('datetime.now()'.encode('utf8'))
    if client.recv(2048).decode('utf8') == 'Authentication success':
        print('Authentication successful!')
        authentication_successful = True
    else:
        print('Authentication failed')
print('You logged in!')
