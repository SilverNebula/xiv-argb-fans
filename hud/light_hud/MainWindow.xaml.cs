using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using light_hud.sys;
using NHotkey.Wpf;
namespace light_hud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialCtrl serialCtrl;

        public static readonly DependencyProperty _lastButton= 
            DependencyProperty.Register("lastButton", typeof(string),typeof(MainWindow));
        public string lastButton
        {
            get { return (string)GetValue(_lastButton); }
            set
            {
                SetValue(_lastButton,"Last: "+ value);
            }
        }
        public MainWindow()
        {
            lastButton = "none";
            InitializeComponent();
            this.SourceInitialized += new EventHandler(MainwindowSourceInitialized);
            this.serialCtrl = new SerialCtrl();
            this.serialCtrl.LinkArduino("COM27", AddText);
            return;
        }
        public const int WM_KEYDOWN = 0x100;
        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Debug.WriteLine(msg);
            this.consoleInfo1.Text=(msg.ToString() + System.Environment.NewLine);
            if (msg == WM_KEYDOWN){
                MainWindow1_KeyDown(this, new KeyEventArgs(Keyboard.PrimaryDevice,
                    PresentationSource.FromVisual(this),0, (Key)wParam));
            }
            else
            {
                handled = false;
            }
            return IntPtr.Zero;
        }

        protected void MainwindowSourceInitialized(object sender,EventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
        }

        private void style0_Click(object sender, RoutedEventArgs e)
        {
            //this.serialCtrl.SendMessage(sys.Action.Default.ToString());
            System.Diagnostics.Debug.WriteLine("Style0");
            lastButton = "0";
        }
        private void style1_Click(object sender, RoutedEventArgs e)
        {
            //this.serialCtrl.SendMessage(sys.Action.Active.ToString());
            System.Diagnostics.Debug.WriteLine("Style1");
            lastButton = "1";
        }
        private void AddText(object sender,string msg)
        {
            consoleInfo1.AppendText(msg + System.Environment.NewLine);
            return;
        }

        private void MainWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Q)
            {
                style0_Click(this, new RoutedEventArgs());
                
                e.Handled = true;
            }
            if(e.Key == Key.W)
            {
                style1_Click(this, new RoutedEventArgs());
                
                e.Handled = true;
            }
        }
    }
}
