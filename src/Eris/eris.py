import os
import optparse
import sys
import pickle
import tarfile
from Crypto.Cipher import DES


class Eris:
	Verbose = None
	Directory = None
	KeySize = None
	def __init__(self, Directory, verbosity=0, keySize=4096):
		self.Verbose = verbosity
		if Directory:
			self.Directory = os.path.abspath(Directory)
		else:
			self.Directory = os.getcwd()
		self.KeySize = keySize
	
	def mkArchive(Garbage,Name):
		File = open("garbage.eris","w")
		File.write(Garbage)
		File.close()
		tar = tarfile.open(Name+".tar","w")
		tar.add("garbage.eris")
		tar.close()
		return Name+".tar"

	def GenGarbageString(length=16):
		return base64.urlsafe_b64encode(os.urandom(length))
	
	def GenGarbage(length=258):
		nbits = length * 6 + 1
    	bits = random.getrandbits(nbits)
    	uc = u"%0x" % bits
    	newlen = int(len(uc) / 2) * 2
    	return bytearray.fromhex(uc[:newlen])

    def Trash():
    	return DES.new(GenGarbageString(self.KeySize), DES.MODE_ECB).encrypt(base64.urlsafe_b64encode(GenGarbage())

    def SafeEncode(ToEncode):
    	return base64.urlsafe_b64encode(ToEncode)

	
if __name__ == "__main__":
	parser = optparse.OptionParser(usage = "usage: %prog [options] pathname", version="%prog 0.1")
	parser.add_option("-v", "--verbose", action="count", dest="Verbose", help="Shows Output of Current Operations")
	parser.add_option("-d", "--directory", action="store", type="string", dest="Directory", default=None, help="")
	(options, args) = parser.parse_args()