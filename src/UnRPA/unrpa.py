# UnRPA Copyright (c) X@MPP 2012
#
# This Tool is Granted to you AS IS, without any implied support or warranty
# The Author of this tool is not Responsible for any misuse or loss of information
# that may be caused by this tool, use at your own discretion
#
# This Tool is For Personal Use only, You Hear By Agree that you will not distribute, 
# Nor Modify and redistribute Extracted content without Prior consent from the Owner of said content.
#
# If you Do not Agree to these Terms, Do not Download this Tool

# 
# Usage: python unrpa.py /path/to/data.rpa
#

import os.path
from pickle import loads
from cStringIO import StringIO
import sys
import types
import time

## == Vars == ##
Path = ""
Map = { }

def print_timing(func):
	def wrapper(*arg):
		t1 = time.time()
		res = func(*arg)
		t2 = time.time()
		print '[*] It took %0.3f ms to UnRPA' % (func.func_name, (t2-t1)*1000.0)
		return res
	return wrapper
@print_timing
def UnRPA(_Path,_Dest):
	Map.clear()
	Map[_Path.lower()] = _Path
	fn = transfn(_Path)
	try:
		fn = transfn(_Path)
		fi = file(fn, "rb")
		line = fi.readline()
		if line.startswith("RPA-3.0"):
			print "[*] File Archive is a RenPy 3.0 RPA"
			print "[*] %s" % line
			print "[*] Getting Offset"
			Offset = int(line[8:24], 16)
			print "[*] Offset: %s" % Offset
			print "[*] Getting Key "
			Key = int(line[25:33], 16)
			print "[*] Key: %s " % Key
			print "[*] Seeking Offset"
			fi.seek(Offset)
			print "[*] Loading Index"
			index = loads(fi.read().decode("zlib"))
			print "[*] Deobfuscateing Index..."
			keys_ = 0
			for _key in index.keys():
				if len(index[_key][0]) == 2:
					index[_key] = [(Offset^Key, dlen^Key) for Offset, dlen in index[_key]]
				else:
					index[_key] = [(Offset^Key, dlen^Key,Start) for Offset,dlen,Start in index[_key]]
				keys_ += 1
			print "[*] %s Index Keys Proccessed" % keys_
			print "[*] Cloasing File"
			fi.close()
		if line.startswith("RPA-2.0"):
			print "[*] File Archive is a RenPy 2.0 RPA"
			print "[*] %s" % line
			print "[*] Getting Offset"
			Offset = int(line[8:],16)
			print "[*] Offset: %s" % Offset
			print "[*] Seeking Offset"
			fi.seek(Offset)
			print "[*] Loading Index"
			index = loads(fi.read().decode("zlib"))
			print "[*] Closing File"
			fi.close()
		print "[*] Riping Files"
		if not os.path.exists(_Dest):
			print "[*] Output directory does not exsist, Creating"
			os.mkdir(_Dest)
		f = file(transfn(_Path), "rb")
		datlen = 0
		for name in index:
			print "[*] Reading %s " % name.replace('/','_')
			data = [ ]
			if len(index[name]) == 1:
				t = index[name][0]
				if len(t) == 2:
					offset, dlen = t
					datlen = dlen
					start = ''
				else:
					offset, dlen, start = t
					datlen = dlen
					rv = SubFile(f, offset, dlen, start)
			else:
				for offset, dlen in index[name]:           
					f.seek(offset)
					data.append(f.read(dlen))
					rv = StringIO(''.join(data))
			print "[*] Creating %s" % _Dest+"/"+name.replace('/','_')
			fi = open(_Dest+"/"+name.replace('/','_'), 'w')
			print "[*] Writing File To disk"
			fi.write(rv.read(datlen))
			print "[*] Done Writing %s" % name.replace('/','_')
			fi.close()
		f.close()
		print "[*] Done!"
	except:
		print "[*] Failure, Check the Stack trace..."
		raise
def transfn(name):
    name = Map.get(name.lower(), name) 
    if isinstance(name, unicode):
        name = name.encode("utf-8")
    fn = os.path.join(name)
    if os.path.exists(fn):
        return fn
    raise Exception("Couldn't find file '%s'." % name)
def main():
	print "[*] UnRPA Version 0.1"
	if len(sys.argv) < 2:
		print "[*] Usage: %s /path/to/data.rpa" % sys.argv[0]
		sys.exit()
	else:
		Path = sys.argv[1]
		if os.path.isfile(Path):
			print "[*] all good, UnRPAing to same directory"
			UnRPA(Path,"./UnRPA")
		else:
			print "[*] '%s' Needs to be a file " % Path
			print "[*] Usage: %s /path/to/data.rpa" % sys.argv[0]
			sys.exit()

## == Start RenPy loader.py SubFile Class == ##			
class SubFile(object):

    def __init__(self, f, base, length, start):
        self.f = f
        self.base = base
        self.offset = 0
        self.length = length
        self.start = start

        if start is None:
            self.name = self.f.name
        else:
            self.name = None
            
        self.f.seek(self.base)

    def read(self, length=None):

        maxlength = self.length - self.offset

        if length is not None:
            length = min(length, maxlength)
        else:
            length = maxlength

        rv1 = self.start[self.offset:self.offset + length]
        length -= len(rv1)
        self.offset += len(rv1)

        if length:
            rv2 = self.f.read(length)        
            self.offset += len(rv2)
        else:
            rv2 = ""

        return (rv1 + rv2)

    def readline(self, length=None):

        maxlength = self.length - self.offset
        if length is not None:
            length = min(length, maxlength)
        else:
            length = maxlength

        # If we're in the start, then read the line ourselves.
        if self.offset < len(self.start):
            rv = ''

            while length:
                c = self.read(1)
                rv += c
                if c == '\n':
                    break
                length -= 1

            return rv
                
        # Otherwise, let the system read the line all at once.
        rv = self.f.readline(length)

        self.offset += len(rv)

        return rv

    def readlines(self, length=None):
        rv = [ ]

        while True:
            l = self.readline(length)

            if not l:
                break

            if length is not None:
                length -= len(l)
                if l < 0:
                    break

            rv.append(l)

        return rv

    def xreadlines(self):
        return self

    def __iter__(self):
        return self

    def next(self): #@ReservedAssignment
        rv = self.readline()

        if not rv:
            raise StopIteration()

        return rv
    
    def flush(self):
        return

    
    def seek(self, offset, whence=0):

        if whence == 0:
            offset = offset
        elif whence == 1:
            offset = self.offset + offset
        elif whence == 2:
            offset = self.length + offset

        if offset > self.length:
            offset = self.length

        self.offset = offset
            
        offset = offset - len(self.start)
        if offset < 0:
            offset = 0
            
        self.f.seek(offset + self.base)

    def tell(self):
        return self.offset

    def close(self):
        self.f.close()

    def write(self, s):
        raise Exception("Write not supported by SubFile")
## == END RenPy loader.py SubFile Class == ##
if __name__ == "__main__":
	main()