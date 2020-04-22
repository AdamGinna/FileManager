using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForms = System.Windows.Forms;
using FileManager;
using System.Threading.Tasks;

namespace IntefaceFileManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy ChoosePath.xaml
    /// </summary>
    public partial class ChoosePath : UserControl
    {
        string path = @"c:/";

        bool NewData = false;

        public ChoosePath()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WinForms.FolderBrowserDialog();
            WinForms.DialogResult result = dialog.ShowDialog();
            
            if (result == WinForms.DialogResult.OK)
            {
                this.labelPath.Text = dialog.SelectedPath;
                path = dialog.SelectedPath;
            }
        }

        private async Task MakeFolderDataAsync(string path)
        {
            FileManager.FileManager managerFolder = new FileManager.FileManager();
            managerFolder.Path = path;
            FileManager.FilesData data = await managerFolder.GetAllData(path);
            MainWindow.DataFolder = data;
            NewData = true;
            //MainWindow.FolderCharts(data);
        }

            private void Check_Click(object sender, RoutedEventArgs e)
        {
            buttonCheck.IsEnabled = false;
            Task.Run(() => MakeFolderDataAsync(path));
            while (true)
            {
                if (NewData)
                {
                    UpdateChart();
                    NewData = false;
                    break;
                }
            }
            buttonCheck.IsEnabled = true;

        }

        private void UpdateChart()
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.FolderCharts();
        }
    }
}
