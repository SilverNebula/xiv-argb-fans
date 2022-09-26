using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using System.Diagnostics;
using System.Windows.Forms;
using light_ctl.sys;
using System.Drawing.Imaging;
using System.Text;

namespace light_ctl
{
    public partial class MainForm : Form
    {
        public const int WM_KEYDOWN = 0x100;
        SerialCtrl serialCtrl;
        Listener listener;
        string lastButton = "0";
        public MainForm()
        {
            InitializeComponent();
            listener = new Listener();
            listener.handler += this.handleSocket;
            this.consoleBox.AppendText("Start"+ System.Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.serialCtrl = new SerialCtrl();
            this.serialCtrl.LinkArduino("COM27", AddText);
        }
        /*
        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Debug.WriteLine(msg);
            this.consoleBox.Text = (msg.ToString() + System.Environment.NewLine);
            if (msg == WM_KEYDOWN)
            {
                MainWindow1_KeyDown(this, new KeyEventArgs(Keyboard.PrimaryDevice,
                    PresentationSource.FromVisual(this), 0, (Key)wParam));
            }
            else
            {
                handled = false;
            }
            return IntPtr.Zero;
        }
        */

        private void AddText(object sender, string msg)
        {

            BeginInvoke(new MethodInvoker(() =>
            {
                this.consoleBox.AppendText(msg + System.Environment.NewLine);
            }));
            return;
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Style0");
            lastButton = "SS";
            byte[] c = new byte[5] { 0x0F, 1, 2, 3, 4 };
            serialCtrl.SendMessage(c, 0, 5);
        }

        private void button_style1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Style1");
            lastButton = "A1";
            byte[] c =new byte[5] { 0x1F,0,0,0,0};
            serialCtrl.SendMessage(c,0,5);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                button_reset_Click(this, new EventArgs());
                e.Handled = true;
            }
            if (e.KeyCode == Keys.W)
            {
                button_style1_Click(this, new EventArgs());
                e.Handled = true;
            }
        }
        private void handleSocket(object sender,string msg)
        {
            try
            {


                Debug.WriteLine("get message:" + msg);
                this.AddText(this, "get message:" + msg);
                if (msg == "B01")
                {
                    button_style1_Click(this, new EventArgs());
                }
                if (msg == "B00")
                {
                    button_reset_Click(this, new EventArgs());
                }
                if (msg[0] == 'T') //detail order
                {
                    byte[] c = new byte[(msg.Length - 1) / 2];
                    Debug.WriteLine(c.Length);
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i] = Convert.ToByte(msg.Substring(i * 2 +1, 2), 16);
                        Debug.WriteLine(c[i]);
                    }
                    serialCtrl.SendMessage(c, 0, c.Length);
                }
            }
            catch(Exception e)
            {
                this.AddText(this, e.ToString());
            }
            return;
        }
        
    }
}