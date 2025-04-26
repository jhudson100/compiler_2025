import time
import subprocess

start = time.time()
subprocess.run(["./out.exe"])
end = time.time()
print(end-start,"seconds")
