import usb.core
import usb.util

dev = usb.core.find(idVendor = 0x1352, idProduct = 0x0121)
if dev == None:
    raise ValueError("Device Not Found.")

print("Device Found!!")
