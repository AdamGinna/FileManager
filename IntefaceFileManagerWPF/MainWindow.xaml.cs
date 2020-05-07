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
            InitializeComponent();
            
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            AllCharts();
            this.DrivesColumnChart.Visibility = Visibility.Visible;
            this.ChooseDrive.Visibility = Visibility.Hidden;
            this.ChoosePath.Visibility = Visibility.Hidden;
        }

        private void Drives_Click(object sender, RoutedEventArgs e)
        {
            DrivesCharts();
            this.DrivesColumnChart.Visibility = Visibility.Hidden;
            this.ChooseDrive.Visibility = Visibility.Visible;
            this.ChoosePath.Visibility = Visibility.Hidden;
        }

        private void Folder_Click(object sender, RoutedEventArgs e)
        {
            FolderCharts();
            this.DrivesColumnChart.Visibility = Visibility.Hidden;
            this.ChooseDrive.Visibility = Visibility.Hidden;
            this.ChoosePath.Visibility = Visibility.Visible;
        }

        public void AllCharts()
        {

            this.FilePieChart.UpdateChart(DataAll);
            this.BytesPieChart.UpdateChart(DataAll);
            this.BytesColumnChart.UpdateChart(DataAll);
            // get data from service and show on chart
        }

        public static void DrivesCharts()
        {
            // get data from service and show on chart
        }

        public void FolderCharts(FileManager.FilesData data)
        {
            DataFolder = data;
            this.FilePieChart.UpdateChart(data);
            this.BytesPieChart.UpdateChart(data);
            this.BytesColumnChart.UpdateChart(data);
            // create data and show on chart
        }

        public void FolderCharts()
        {
            FolderCharts(DataFolder);
            
            // create data and show on chart
        }

        public static FileManager.FilesData DataFolder { get; set; }
        public static List<FileManager.FilesData> DataDrives = new List<FileManager.FilesData>();
        public static FileManager.FilesData DataAll { get; set; }
    }

}
