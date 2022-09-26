using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace light_hud.sys
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
                serialPort.PortName = portName;
                serialPort.BaudRate = 4800;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
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
            byte[] result = new byte[serialPort.BytesToRead];
            serialPort.Read(result, 0, serialPort.BytesToRead);
            string res = "";
            if (result != null)
            {
                res = result.ToString();
            }
            act?.Invoke(this, res);
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
            serialPort.Write(msg);
        }
    }
}
