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
using FileManager;
using LiveCharts;
using LiveCharts.Wpf;

namespace IntefaceFileManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy FilePieChart.xaml
    /// </summary>
    public partial class FilePieChart : UserControl
    {
        public FilePieChart()
        {
            InitializeComponent();

            PointLabel = chartPoint =>
               chartPoint.Y != 0 ? string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation) : "";

            DataContext = this;
        }

        public Func<ChartPoint, string> PointLabel { get; set; }

        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }


        public void UpdateChart(FileManager.FilesData data)
        {

            foreach (PieSeries s in PieChart.Series)
            {
                if (s.Title == "Image")
                {
                    s.Values = new ChartValues<long>() { (long)data.ImageFiles };
                }
                else if (s.Title == "Audio")
                {
                    s.Values = new ChartValues<long>() { (long)data.AudioFiles };
                }
                else if (s.Title == "Film")
                {
                    s.Values = new ChartValues<long>() { (long)data.FilmFiles };
                }
                else if (s.Title == "Document")
                {
                    s.Values = new ChartValues<long>() { (long)data.DocumentFiles };
                }
                else if (s.Title == "Archive")
                {
                    s.Values = new ChartValues<long>() { (long)data.ArchFiles };
                }
                else if (s.Title == "Rest")
                {
                    s.Values = new ChartValues<long>() { (long)data.RestFiles };
                }
            }

        }
    }

    

}
