import socket

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind(('127.0.0.1', 5555))
server.listen(5)
print('Server running . . .')

while True:
    conn, addr = server.accept()
    conn.send('Connected successfully!'.encode('utf8'))
    print(f'Connection {addr} successful!')
    while True:
        print(f'Message: {conn.recv(2048).decode("utf8")}')
