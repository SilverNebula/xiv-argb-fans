from http.server import HTTPServer, BaseHTTPRequestHandler
from time import sleep
import serial


now_mid = None

class RHandler(BaseHTTPRequestHandler):

    def do_GET(self):
        self.send_response(200)
        self.send_header("Content-type","text/html")  #设置服务器响应头
        self.end_headers()
        context = 'Middleware Running'
        self.wfile.write(context.encode())
 
    def do_POST(self):
        path = self.path
        print(path)
        datas = self.rfile.read(int(self.headers['content-length']))
        now_mid.handle(datas)
        self.send_response(200)
        self.send_header("Content-type","text/html")
        self.end_headers()
        context = 'receive'
        self.wfile.write(context.encode())

class Mid():
    def __init__(self,host,com) -> None:
        baud_rate = 4800
        time_out = 2
        try:
            self.port = serial.Serial(com,baud_rate,timeout=time_out)
        except Exception as e:
            print(str(e))
        self.host = host
        pass

    def listen(self):
        self.server = HTTPServer(self.host,RHandler)
        self.server.serve_forever()
        pass

    def listen_arduino(self):
        raise NotImplementedError
    
    def handle(self,data:bytes):
        data = data.decode('ascii')
        if data[0]=='T':
            data=data[1:]
            order = []
            i = 0
            while(i+1<data.__len__()):
                order.append(int(data[i:i+2],16))
                i+=2
            print('send:{}'.format(order))
            if self.port.isOpen():
                self.port.write(order)
        return

if __name__ == '__main__':
    host = ('localhost',7197)
    serial_port = "COM27"
    m = Mid(host,serial_port)
    now_mid = m
    try:
        m.listen()
    except Exception as e:
        print(str(e))
    pass