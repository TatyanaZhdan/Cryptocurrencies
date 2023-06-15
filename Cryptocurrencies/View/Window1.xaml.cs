using CryptoCurrencies.Model;
using CryptoCurrencies.ViewModel;
using CryptoLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CryptoCurrencies.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Currency currency;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(Currency currency)
        {
            InitializeComponent();
            this.currency= currency;
            this.DataContext = new ShowCurrency(currency);
            Loaded += MainWindow_Loaded;
        }
        
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCurrency showCurrency = (ShowCurrency)DataContext;

            DrawChart(showCurrency.Histories);
        }

        private void DrawChart(ObservableCollection<History> dataPoints)
        {
            double canvasWidth = canvas.ActualWidth;
            double canvasHeight = canvas.ActualHeight;

            double minTime = dataPoints.Min(p => p.Time);
            double maxTime = dataPoints.Max(p => p.Time);
            double minPrice = dataPoints.Min(p => p.Price);
            double maxPrice = dataPoints.Max(p => p.Price);

            Polyline polyline = new Polyline();
            polyline.Stroke = Brushes.Blue;
            polyline.StrokeThickness = 1;

            for (int i = 0; i < dataPoints.Count; i++)
            {
                History point = dataPoints[i];

                double x = (point.Time - minTime) / (maxTime - minTime) * canvasWidth;
                double y = canvasHeight - (point.Price - minPrice) / (maxPrice - minPrice) * canvasHeight;

                polyline.Points.Add(new Point(x, y));
            }

            canvas.Children.Add(polyline);
            TextBlock xAxisLabel = new TextBlock();

            xAxisLabel.FontSize = 12;
            Canvas.SetLeft(xAxisLabel, canvasWidth - 30);
            Canvas.SetTop(xAxisLabel, canvasHeight - 20);
            canvas.Children.Add(xAxisLabel);


        }
    }
}
