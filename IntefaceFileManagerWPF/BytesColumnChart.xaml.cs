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
using LiveCharts;
using LiveCharts.Wpf;

namespace IntefaceFileManagerWPF
{
    /// <summary>
    /// Logika interakcji dla klasy BytesColumnChart.xaml
    /// </summary>
    public partial class BytesColumnChart : UserControl
    {
        public BytesColumnChart()
        {
            InitializeComponent();

            BrushConverter bc = new BrushConverter();

            SeriesCollection = new SeriesCollection {

            new ColumnSeries
                {
                    Title = "Image",
                    Values = new ChartValues<double> {6},
                },
                new ColumnSeries
                {
                    Title = "Film",
                    Values = new ChartValues<double> {4},
                },
                new ColumnSeries
                {
                    Title = "Audio",
                    Values = new ChartValues<double> {9},
                },
                new ColumnSeries
                {
                    Fill = (Brush)bc.ConvertFrom("DeepPink"),
                    Title = "Document",
                    Values = new ChartValues<double> {7},
                },
                new ColumnSeries
                {
                    Fill = (Brush)bc.ConvertFrom("LimeGreen"),
                    Title = "Archive",
                    Values = new ChartValues<double> {7},
                },
                new ColumnSeries
                {
                    Fill = (Brush)bc.ConvertFrom("SlateGray"),
                    Title = "Rest",
                    Values = new ChartValues<double> {7},
                }

        };
            Formatter = value => value + " Bytes";

            
            DataContext = this;

        }

        public void UpdateChart(FileManager.FilesData data)
        {

            foreach (ColumnSeries s in SeriesCollection)
            {
                if (s.Title == "Image")
                {
                    s.Values = new ChartValues<long>() { (long)data.ImageBytes };
                }
                else if (s.Title == "Audio")
                {
                    s.Values = new ChartValues<long>() { (long)data.AudioBytes };
                }
                else if (s.Title == "Film")
                {
                    s.Values = new ChartValues<long>() { (long)data.FilmBytes };
                }
                else if (s.Title == "Document")
                {
                    s.Values = new ChartValues<long>() { (long)data.DocumentBytes };
                }
                else if (s.Title == "Archive")
                {
                    s.Values = new ChartValues<long>() { (long)data.ArchBytes };
                }
                else if (s.Title == "Rest")
                {
                    s.Values = new ChartValues<long>() { (long)data.RestBytes };
                }
            }
        }





        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
