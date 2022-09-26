using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;

namespace light_ctl.sys
{
    public delegate void AlarmEventHandler(object sender, string e);
    class SerialCtrl
    {
        SerialPort serialPort;
        AlarmEventHandler? act;
        public SerialCtrl()
        {
            serialPort = new SerialPort();
            act = null;
        }
        public string[] GetSerialInfo()
        {
            string[] portList = SerialPort.GetPortNames();
            return portList;
        }
        public bool LinkArduino(string portName, AlarmEventHandler callBack)
        {
            try
            {
                serialPort = new SerialPort(portName,4800);
                serialPort.BaudRate = 4800;
                serialPort.Encoding = Encoding.ASCII;
                serialPort.DataReceived += ReceiveDataMethod;
                act = callBack;
                serialPort.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }
        private void ReceiveDataMethod(object sender, SerialDataReceivedEventArgs e)
        {
            Debug.WriteLine("receive");
            string result=serialPort.ReadLine();
            act?.Invoke(this, result);
        }
        public void Close()
        {
            serialPort.Close();
        }
        public void ReOpen()
        {
            serialPort.Open();
        }
        public void SendMessage(string msg)
        {
            if (!serialPort.IsOpen)
            {
                this.ReOpen();
            }
            serialPort.WriteLine(msg);
            Debug.WriteLine("write:" + msg);
        }
        public void SendMessage(byte[] msg,int offset,int count)
        {
            try
            {
            if (!serialPort.IsOpen)
            {
                this.ReOpen();
            }
            serialPort.Write(msg,offset,count);
            Debug.WriteLine("write:" + msg);

            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
