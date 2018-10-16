using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using iTOS3D.NET;

namespace iTOS3D
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Closed += MainWindow_Closed;
            
        }

        private void StartSever()
        {
            try
            {
                Server server = new Server("192.168.0.177", 41500);
                server.Start();
            }
            catch(Exception ex)
            {
                unityhost.ShowMessage(ex.ToString());
            }
        }

        private void MainWindow_Load(object sender,EventArgs e)
        {

        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            unityhost.Form1_FormClosed();
        }
    }
}
