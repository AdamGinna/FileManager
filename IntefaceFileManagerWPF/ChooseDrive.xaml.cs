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
using IntefaceFileManagerWPF;
using FileManager;
using System.IO;
using SaveData;

namespace IntefaceFileManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseDrive.xaml
    /// </summary>
    public partial class ChooseDrive : UserControl
    {
        public ChooseDrive()
        {
            InitializeComponent();


            if(MainWindow.DataSetDrives != null)
            {
                foreach(DataSet ds in MainWindow.DataSetDrives)
                {
                    this.listBox.Items.Add(ds.Name);
                }
            }

        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Window.GetWindow(this);
            main.DrivesCharts( MainWindow.DataDrives[this.listBox.SelectedIndex] );
        }
    }
}
