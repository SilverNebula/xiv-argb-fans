from time import sleep
import win32gui
import serial

offset = 0x400


port_name="COM27"
baud_rate=4800
time_out=2
port = serial.Serial(port_name,baud_rate,timeout=time_out)

def ctrl_light(number):
    print('in')
    msg =''
    if number==0:
        msg='SSss'
    if number==1:
        msg='A1ss'
    if port.isOpen():
        port.write(msg.encode('utf-8'))
    sleep(1)
    if port.isOpen() and port.readable():
        readIn=port.readlines()
        print(readIn)
    return

ctrl_light(0)

def WndProc(hwnd,msg,wParam,lParam):
    if msg == WM_PAINT:
        hdc,ps = win32gui.BeginPaint(hwnd)
        rect = win32gui.GetClientRect(hwnd)
        win32gui.DrawText(hdc,'GUI Python',len('GUI Python'),rect,DT_SINGLELINE|DT_CENTER|DT_VCENTER)
        win32gui.EndPaint(hwnd,ps)
    if msg == WM_DESTROY:
        win32gui.PostQuitMessage(0)
    print(msg)
    if msg == offset+1:
        ctrl_light(0)
    if msg == offset+2:
        # print(msg)
        ctrl_light(1)
    return win32gui.DefWindowProc(hwnd,msg,wParam,lParam)


if __name__ == '__main__':
    from win32con import *
    wc = win32gui.WNDCLASS()
    wc.hbrBackground = COLOR_BTNFACE + 1
    wc.hCursor = win32gui.LoadCursor(0,IDI_APPLICATION)
    wc.lpszClassName = "Python no Windows"
    wc.lpfnWndProc = WndProc
    reg = win32gui.RegisterClass(wc)
    hwnd = win32gui.CreateWindow(reg,'RGB_console2',WS_OVERLAPPEDWINDOW,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,0,0,0,None)
    win32gui.ShowWindow(hwnd,SW_SHOWNORMAL)
    win32gui.UpdateWindow(hwnd)
    win32gui.PumpMessages()