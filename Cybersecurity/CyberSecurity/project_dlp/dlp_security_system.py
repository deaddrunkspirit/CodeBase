import os.path
import socket


def diff(list1, list2):
    list_difference = [item for item in list1 if item not in list2]
    return list_difference


client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client.connect(('127.0.0.1', 5555))
data = client.recv(2048)
print(data.decode('utf8'))

drive_names = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
drives = [f'{d}:' for d in drive_names if os.path.exists(f'{d}:')]
print(drives)
while True:
    unchecked_drives = [f'{d}:' for d in drive_names if os.path.exists(f'{d}:')]
    x = diff(unchecked_drives, drives)
    if x:
        print(f'Warning!!! Unknown device: {x}')
        client.send(f'Unknown device detected: {x}'.encode('utf8'))
    x = diff(drives, unchecked_drives)
    if x:
        print(f'Removed drives: {x}')
        client.send(f'Device disconnected: {x}'.encode('utf8'))
    drives = [f'{d}:' for d in drive_names if os.path.exists(f'{d}:')]

