#!/usr/bin/env python3

import subprocess
import os.path
import sys

if len(sys.argv) > 1:
    args = sys.argv[1:]
else:
    args = [os.path.join(".","out.exe")]
P = subprocess.run( args )
print("Process exited with code",P.returncode)
input("Press enter to quit ")
