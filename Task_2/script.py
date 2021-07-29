import os
import hashlib

files = os.listdir()

for i in range(len(files)):
    try:
        file = open(f"{files[i]}", "r").read()
        info = hashlib.sha3_256()
        info.update(f"{file}".encode('utf-8'))
        print(files[i], info.hexdigest())
    except Exception: pass
