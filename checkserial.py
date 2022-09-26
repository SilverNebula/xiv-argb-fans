import serial 
import serial.tools.list_ports

#get serialport list
port_list = list(serial.tools.list_ports.comports())
print(port_list)
if len(port_list) == 0:
   print('none')
else:
    for i in range(0,len(port_list)):
        print(port_list[i])

try:#set serialport parameters
  portName="COM1"
  baudRate=115200
  timeOut=3
  ser=serial.Serial(portName,baudRate,timeout=timeOut)

  # write in serialport
  if ser.isOpen():
    writeIn=ser.write("Welcome to pySerial".encode("utf-8"))
    print(writeIn,"bits has been written")
    ser.close()
except Exception as e:
    print("erros occured:",e)
