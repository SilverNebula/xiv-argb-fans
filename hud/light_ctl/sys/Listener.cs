using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace light_ctl.sys
{
    public delegate void SocketEventHandler(object sender, string msg);
    public class Listener
    {
        public HttpListener listener;
        public event SocketEventHandler handler;
        public Listener()
        {
            this.start();
        }
        ~Listener()
        {
            this.StopListener();
        }
        private void start()
        {
            try
            {
                HttpListener listener = new HttpListener();
                listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                listener.Prefixes.Add("http://localhost:7197/");
                listener.Start();
                Debug.WriteLine("Start Listening");
                listener.BeginGetContext(ListenerHandle, listener);
            }
            catch (Exception err)
            {
                Debug.WriteLine("程序异常，请重新打开程序：" + err.Message);
            }
        }
        private void ListenerHandle(IAsyncResult result)
        {
            try
            {
                listener = result.AsyncState as HttpListener;
                if (listener == null) return;
                if (listener.IsListening)
                {
                    listener.BeginGetContext(ListenerHandle, listener); //继续监听
                    HttpListenerContext context = listener.EndGetContext(result);
                    //解析Request请求
                    HttpListenerRequest request = context.Request;
                    string content = "";
                    Debug.WriteLine("in");
                    switch (request.HttpMethod)
                    {
                        case "POST":
                            {
                                Stream stream = context.Request.InputStream;
                                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                                content = reader.ReadToEnd();
                            }
                            break;
                        case "GET":
                            {
                                //这里接收到GET链接后面的参数
                                var data = request.QueryString;
                                //Console.WriteLine($"GET:{data["123"]}");
                            }
                            break;
                    }
                    Debug.WriteLine("收到数据：" + content);
                    this.handler(this, content);
                    //构造Response响应
                    HttpListenerResponse response = context.Response;
                    response.StatusCode = 200;
                    response.ContentType = "text/html;";
                    response.ContentEncoding = Encoding.UTF8;

                    using (StreamWriter writer = new StreamWriter(response.OutputStream, Encoding.UTF8))
                    {
                        writer.Write("{\"class\":\"写入给请求响应的数据\"}");
                        writer.Close();
                        response.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常:{ex.StackTrace}");
            }
        }
        //停止HTTP请求监听
        private void StopListener()
        {
            if (listener != null)
            {
                listener.Close();
                Console.WriteLine("停止数据监听");
            }
        }
    }
}
