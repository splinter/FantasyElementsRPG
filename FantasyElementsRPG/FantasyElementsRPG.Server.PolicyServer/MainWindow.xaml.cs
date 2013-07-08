using FantasyElementsRPG.Server.PolicyServer.Logger;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FantasyElementsRPG.Server.PolicyServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PolicyServerLogger.PolicyServerLog.SetTextBox(txtUpdates);
            PolicyServer ps = new PolicyServer("PolicyFile.xml");
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
