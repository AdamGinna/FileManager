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

            FileManager.FileManager man = new FileManager.FileManager();
            man.GetDiskData();
            DriveInfo[] drives =  man.Drives;
            foreach(DriveInfo d in drives)
                this.listBox.Items.Add(d);

        }

        public void OnClick(object sender, RoutedEventArgs e)
        {
            //DriveInfo drive = this.listBox.SelectedItem;
            this.listBox.Items.Add(this.listBox.SelectedItem);
        }
    }
}
