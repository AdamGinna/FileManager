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
using LiveCharts;
using LiveCharts.Wpf;

namespace IntefaceFileManagerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Mode = "";
            InitializeComponent();
            
        }
        public string Mode { get; set; }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            this.DrivesColumnChart.Visibility = Visibility.Visible;
            this.ChooseDrive.Visibility = Visibility.Hidden;
            this.ChoosePath.Visibility = Visibility.Hidden;
        }

        private void Drives_Click(object sender, RoutedEventArgs e)
        {
            this.DrivesColumnChart.Visibility = Visibility.Hidden;
            this.ChooseDrive.Visibility = Visibility.Visible;
            this.ChoosePath.Visibility = Visibility.Hidden;
        }

        private void Folder_Click(object sender, RoutedEventArgs e)
        {
            this.DrivesColumnChart.Visibility = Visibility.Hidden;
            this.ChooseDrive.Visibility = Visibility.Hidden;
            this.ChoosePath.Visibility = Visibility.Visible;
        }

        public static void AllCharts()
        {
            // get data from service and show on chart
        }

        public static void DrivesCharts()
        {
            // get data from service and show on chart
        }

        public static void FolderCharts()
        {
            // create data and show on chart
        }

        public static FileManager.FileManager managerFolder = new FileManager.FileManager();
        public static List<FileManager.FileManager> managerDrives = new List<FileManager.FileManager>();
        public static FileManager.FileManager managerAll = new FileManager.FileManager();
    }

}
