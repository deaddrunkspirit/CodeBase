import time
import pyotp


while True:
    totp = pyotp.TOTP('base32secret3232')
    print(f'Your code: {totp.now()}')
    time.sleep(5)
