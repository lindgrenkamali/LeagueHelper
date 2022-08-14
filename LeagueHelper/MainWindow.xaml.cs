using LeagueHelper.Backend;
using LeagueHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LeagueHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();

            GetClientSummoner gcs = new();
            
            main = this;
            Thread t = new Thread(() => gcs.Run());
            RunAsync();
            t.Start();
        }

        public async void RunAsync()
        {
            API.DataDragon dd = new();
           await dd.GetLatestVersion();
        }
    }
}
