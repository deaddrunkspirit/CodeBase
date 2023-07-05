import numpy as np
from PIL import Image
import math
from scipy.fft import dct, idct
import jpegio as jio
import random
import matplotlib
import matplotlib.pyplot as plt
 
# CONSTS #
T = 125
Z = 2
Th = 80
K = 12
eps = 0.00001
arnold_iters = 10
dwm_sz = 32
block_size = 8
 
# CAPACITY #
ec = 0
capacity = 0
 
def quant(jpeg):
    for i in range(0, jpeg.coef_arrays[0].shape[0], block_size):
        for j in range(0, jpeg.coef_arrays[0].shape[1], block_size):
                jpeg.coef_arrays[0][i:i+8, j:j+8] //= jpeg.quant_tables[0]
 
def unquant(jpeg):
    for i in range(0, jpeg.coef_arrays[0].shape[0], block_size):
        for j in range(0, jpeg.coef_arrays[0].shape[1], block_size):
                jpeg.coef_arrays[0][i:i+8, j:j+8] *= jpeg.quant_tables[0]
 
 
def jsteg_embed(jpeg, secret_bits=''):
    global ec, capacity
    ind = -1
    embedded_bits = ''
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            if abs(jpeg.coef_arrays[0][i][j]) <= 1:
                continue
 
            ind += 1
 
            cur_bit = None
            if secret_bits == '':
                cur_bit = str(random.randint(0, 1))
                embedded_bits += cur_bit
            else:
                if ind >= len(secret_bits):
                    continue
                cur_bit = secret_bits[ind]
            
            if int(cur_bit) != (abs(jpeg.coef_arrays[0][i][j]) % 2):
                if jpeg.coef_arrays[0][i][j] > 0:
                    jpeg.coef_arrays[0][i][j] ^= 1
                else:
                    jpeg.coef_arrays[0][i][j] = -(abs(jpeg.coef_arrays[0][i][j]) ^ 1)
    if secret_bits == '':
        ec = 1
        print(f'Applied {ind + 1} bit:')
        print(embedded_bits[:50], '...', sep='')
    else:
        print(f'Applied {len(secret_bits)} bit.')
        ec = len(secret_bits) / (ind + 1)
    capacity = ind + 1
 
 
def jsteg_extract(jpeg, secret_len):
    ans = ''
    ind = -1
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            if abs(jpeg.coef_arrays[0][i][j]) <= 1:
                continue
            
            ind += 1
            if ind == secret_len:
                return ans
            
            if (abs(jpeg.coef_arrays[0][i][j]) & 1):
                ans += '1'
            else:
                ans += '0'
    return ans
 
 
def f3_embed(jpeg, secret_bits=''):
    global ec, capacity
    ind = -1
    embedded_bits = ''
    bad_embedding_flag = False
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            if not bad_embedding_flag:
                ind += 1
 
                cur_bit = None
                if secret_bits == '':
                    cur_bit = str(random.randint(0, 1))
                    embedded_bits += cur_bit
                else:
                    if ind >= len(secret_bits):
                        continue
                    cur_bit = secret_bits[ind]
            
            if int(cur_bit) != (abs(jpeg.coef_arrays[0][i][j]) % 2):
                if jpeg.coef_arrays[0][i][j] > 0:
                    jpeg.coef_arrays[0][i][j] -= 1
                else:
                    jpeg.coef_arrays[0][i][j] = -(abs(jpeg.coef_arrays[0][i][j]) - 1)
            
            if jpeg.coef_arrays[0][i][j] == 0:
                bad_embedding_flag = True
            else:
                bad_embedding_flag = False
 
    if secret_bits == '':
        ec = 1
        print(f'Applied {ind + 1 - int(bad_embedding_flag)} bit:')
        print(embedded_bits[:50], '...', sep='')
    else:
        print(f'Applied {len(secret_bits)} bit.')
        ec = len(secret_bits) / (ind + 1)
    capacity = ind + 1 - int(bad_embedding_flag)
 
 
def f3_extract(jpeg, secret_len):
    ans = ''
    ind = -1
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            ind += 1
            if ind == secret_len:
                return ans
            
            if (abs(jpeg.coef_arrays[0][i][j]) & 1):
                ans += '1'
            else:
                ans += '0'
    return ans
 
 
def f4_embed(jpeg, secret_bits=''):
    global ec, capacity
    ind = -1
    embedded_bits = ''
    bad_embedding_flag = False
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            # if dc coef the continue
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            if not bad_embedding_flag:
                ind += 1
 
                cur_bit = None
                if secret_bits == '':
                    cur_bit = str(random.randint(0, 1))
                    embedded_bits += cur_bit
                else:
                    if ind >= len(secret_bits):
                        continue
                    cur_bit = secret_bits[ind]
            
            if jpeg.coef_arrays[0][i][j] < 0 and ((abs(jpeg.coef_arrays[0][i][j]) % 2 != 0 and cur_bit == '1') or (abs(jpeg.coef_arrays[0][i][j]) % 2 == 0 and cur_bit == '0')):
                jpeg.coef_arrays[0][i][j] += 1
            elif jpeg.coef_arrays[0][i][j] > 0 and ((abs(jpeg.coef_arrays[0][i][j]) % 2 != 0 and cur_bit == '0') or (abs(jpeg.coef_arrays[0][i][j]) % 2 == 0 and cur_bit == '1')):
                jpeg.coef_arrays[0][i][j] -= 1
 
            if jpeg.coef_arrays[0][i][j] == 0:
                bad_embedding_flag = True
            else:
                bad_embedding_flag = False
 
    if secret_bits == '':
        ec = 1
        print(f'Applied {ind + 1 - int(bad_embedding_flag)} bit:')
        print(embedded_bits[:50], '...', sep='')
    else:
        print(f'Applied {len(secret_bits)} bit.')
        ec = len(secret_bits) / (ind + 1)
    capacity = ind + 1 - int(bad_embedding_flag)
 
 
def f4_extract(jpeg, secret_len):
    ans = ''
    ind = -1
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            # if dc coef the continue
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            # if 0 then continue
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            ind += 1
            if ind == secret_len:
                return ans
            
            if (jpeg.coef_arrays[0][i][j] > 0 and abs(jpeg.coef_arrays[0][i][j]) % 2 != 0) or (jpeg.coef_arrays[0][i][j] < 0 and abs(jpeg.coef_arrays[0][i][j]) % 2 == 0):
                ans += '1'
            elif (jpeg.coef_arrays[0][i][j] > 0 and abs(jpeg.coef_arrays[0][i][j]) % 2 == 0) or (jpeg.coef_arrays[0][i][j] < 0 and abs(jpeg.coef_arrays[0][i][j]) % 2 != 0):
                ans += '0'
    return ans
 
 
def get_by_ind(jpeg, buf, index):
    return abs(jpeg.coef_arrays[0][buf[index][0]][buf[index][1]])
 
 
def xor_1(value):
    if value > 0:
        return (value ^ 1)
    return -(abs(value) ^ 1)
 
 
def f5_embed(jpeg, secret_bits=''):
    global ec, capacity
    ind = -1
    embedded_bits = ''
    bad_embedding_flag = False
    coefs_buffer = []
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            # if dc coef the continue
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            # if 0 then continue
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            if not bad_embedding_flag and len(coefs_buffer) == 0:
 
                cur_bit1 = cur_bit2 = None
                if secret_bits == '':
                    cur_bit1 = str(random.randint(0, 1))
                    embedded_bits += cur_bit1
                    cur_bit2 = str(random.randint(0, 1))
                    embedded_bits += cur_bit2
                    ind += 2
                else:
                    ind += 1
                    if ind >= len(secret_bits):
                        continue
                    if ind == len(secret_bits) - 1:
                        ind += 1
                    else:
                        cur_bit1 = secret_bits[ind]
                        ind += 1
                        cur_bit2 = secret_bits[ind]
            
            coefs_buffer.append((i, j))
 
            if len(coefs_buffer) == 3:
                
                if cur_bit1 is None:
                    bad_embedding_flag = True
                    coefs_buffer = []
                    continue
                
                if int(cur_bit1) != ((get_by_ind(jpeg, coefs_buffer, 0) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1) and int(cur_bit2) == ((get_by_ind(jpeg, coefs_buffer, 1) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1):
                    jpeg.coef_arrays[0][coefs_buffer[0][0]][coefs_buffer[0][1]] = xor_1(jpeg.coef_arrays[0][coefs_buffer[0][0]][coefs_buffer[0][1]])
                elif int(cur_bit1) == ((get_by_ind(jpeg, coefs_buffer, 0) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1) and int(cur_bit2) != ((get_by_ind(jpeg, coefs_buffer, 1) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1):
                    jpeg.coef_arrays[0][coefs_buffer[1][0]][coefs_buffer[1][1]] = xor_1(jpeg.coef_arrays[0][coefs_buffer[1][0]][coefs_buffer[1][1]])
                elif int(cur_bit1) != ((get_by_ind(jpeg, coefs_buffer, 0) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1) and int(cur_bit2) != ((get_by_ind(jpeg, coefs_buffer, 1) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1):
                    jpeg.coef_arrays[0][coefs_buffer[2][0]][coefs_buffer[2][1]] = xor_1(jpeg.coef_arrays[0][coefs_buffer[2][0]][coefs_buffer[2][1]])
                
                bad_embedding_flag = False
                for elem in coefs_buffer:
                    if jpeg.coef_arrays[0][elem[0]][elem[1]] == 0:
                        bad_embedding_flag = True
                if bad_embedding_flag:
                    for elem in coefs_buffer:
                        jpeg.coef_arrays[0][elem[0]][elem[1]] = 0
                coefs_buffer = []
 
    if secret_bits == '':
        ec = 1
        print(f'Applied {ind + 1 - int(bad_embedding_flag) * 2} bit:')
        print(embedded_bits[:50], '...', sep='')
    else:
        print(f'Applied {len(secret_bits) - (len(secret_bits) % 2)} bit.')
        ec = len(secret_bits) / (ind + 1)
    capacity = ind + 1 - int(bad_embedding_flag) * 2
 
 
def f5_extract(jpeg, secret_len):
    ans = ''
    ind = -1
    coefs_buffer = []
    for i in range(0, jpeg.coef_arrays[0].shape[0]):
        for j in range(0, jpeg.coef_arrays[0].shape[1]):
            # if dc coef the continue
            if i % 8 == 0 and j % 8 == 0:
                continue
 
            # if 0 then continue
            if jpeg.coef_arrays[0][i][j] == 0:
                continue
            
            if len(coefs_buffer) == 0:
                ind += 2
            if ind >= secret_len:
                return ans
            
            coefs_buffer.append((i, j))
 
            if len(coefs_buffer) == 3:
                ans += chr(ord('0') + ((get_by_ind(jpeg, coefs_buffer, 0) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1))
                ans += chr(ord('0') + ((get_by_ind(jpeg, coefs_buffer, 1) ^ get_by_ind(jpeg, coefs_buffer, 2)) & 1))
                coefs_buffer = []
 
    return ans
 
 
random.seed(31)
s = input('Enter 1 to apply watermark or 2 to extract: ')
algo = int(input('Choose algorithm: 1 - JSTEG, 2 - F3, 3 - F4, 4 - F5: '))
if s == '1':
    secret_bits = input('Enter binary watermark representation: ')
    container_image_name = input('Enter .jpg image filepath: ')
    jpeg = jio.read(container_image_name)
    #quant(jpeg)
    data = []
    for i in range(jpeg.coef_arrays[0].shape[0]):
        for j in range(jpeg.coef_arrays[0].shape[1]):
            if i % 8 == 0 and j % 8 == 0:
                continue
            data.append(jpeg.coef_arrays[0][i][j])
    # plt.hist(data, bins=25)
    # plt.yscale('log')
    # plt.show()
    mse = 0
    if algo == 1:
        jsteg_embed(jpeg, secret_bits)
    if algo == 2:
        f3_embed(jpeg, secret_bits)
    if algo == 3:
        f4_embed(jpeg, secret_bits)
    if algo == 4:
        f5_embed(jpeg, secret_bits)
    # plt.hist(data, bins=25)
    # plt.yscale('log')
    # plt.show()
    #unquant(jpeg)
    jio.write(jpeg, "image_modified.jpg")
    new_jpeg = jio.read("image_modified.jpg")
    image = np.array(Image.open(container_image_name))
    stegoimage = np.array(Image.open("image_modified.jpg"))
    for i in range(image.shape[0]):
        for j in range(image.shape[1]):
            for k in range(image.shape[2]):
                mse += (image[i][j][k] - float(stegoimage[i][j][k]))**2
    mse /= (image.shape[0] * image.shape[1] * image.shape[2])
    psnr = 10.0 * math.log10(255 * 255 / mse)
    print('Capacity of image: ', capacity, 'bit')
    print('MSE =', mse)
    print('PSNR(dB) =', psnr)
    print('EC(bpp) =', ec)
    print('Image now under the name: image_modified.jpg')
else:
    container_image_name = input('Enter filepath to image with watermark: ')
    # image = np.array(Image.open(container_image_name))
    jpeg = jio.read(container_image_name)
    #quant(jpeg)
    ber = 0
    max_len = int(input('Enter bit size of needed info to extract: '))
    orig_dwm = ''.join([str(random.randint(0, 1)) for i in range(max_len)])
    secret_bits = ''
    # Algorithm itself
    if algo == 1:
        secret_bits = jsteg_extract(jpeg, max_len)
    if algo == 2:
        secret_bits = f3_extract(jpeg, max_len)
    if algo == 3:
        secret_bits = f4_extract(jpeg, max_len)
    if algo == 4:
        secret_bits = f5_extract(jpeg, max_len)
    ss = secret_bits
    ncc_1 = ncc_2 = ncc_3 = 0
    for i in range(min(max_len, len(ss))):
        if ss[i] != orig_dwm[i]:
            ber += 1
        p1 = ord(ss[i]) - ord('0')
        p2 = ord(orig_dwm[i]) - ord('0')
        ncc_1 += (p1 * p2)
        ncc_2 += (p1 ** 2)
        ncc_3 += (p2 ** 2)
    print('NCC =', (ncc_1 / (math.sqrt(ncc_2) * math.sqrt(ncc_3))))
    print('BER =', ber / max_len)
    print('Extracted info:')
    if len(secret_bits) <= 50:
        print(secret_bits)
    else:
        print(secret_bits[:50], '...', sep='')