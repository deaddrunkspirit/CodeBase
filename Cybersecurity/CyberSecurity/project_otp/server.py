import socket
import pyotp


def preparation():
    with open("credentials.txt") as file:
        lines = file.readlines()
        lines = [line.rstrip() for line in lines]
    acc = [(x[0], x[1]) for x in [line.split(' ') for line in lines]]
    return acc


server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('localhost', 8089))
server.listen(5)
print('Server running . . .')
accounts = preparation()

while True:
    connection, address = server.accept()
    connection.send('Connected successfully!'.encode('utf8'))
    print(f'Connection {address} successful!')
    authorization_successful = False
    authentication_successful = False
    print(f'Starting authorization process for {address}')
    while not authorization_successful:
        login = connection.recv(2048).decode('utf8')
        password = connection.recv(2048).decode('utf8')
        if (login, password) in accounts:
            authorization_successful = True
            connection.send('Authorization success'.encode('utf8'))
            print(f'{address} authorized')
        else:
            connection.send('Authorization failed'.encode('utf8'))
            print(f'Failed to authorize {address}')
    print(f'Starting authentication process for {address}')
    while not authentication_successful:
        totp = pyotp.TOTP('base32secret3232')
        received_token = connection.recv(2048).decode('utf8')
        valid_token = totp.now()
        print(f'Current token: {totp.now()}')
        print(f'Received token: {received_token}')
        if received_token == valid_token:
            authentication_successful = True
            connection.send('Authentication success'.encode('utf8'))
            print(f'Authentication complete for {address}')
        else:
            connection.send('Authentication failed'.encode('utf8'))
            print(f'Authentication failed for {address}')
