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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        String[] tags = { "enemy", "hero", "treasure" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CreateCircle(e);
        }

        private void CreateCircle(MouseButtonEventArgs e)
        {
            byte red = (byte)random.Next(0, 256);
            byte green = (byte)random.Next(0, 256);
            byte blue = (byte)random.Next(0, 256);
            double radius = random.Next(10, 100);
            string tag = tags[random.Next(tags.Count())];

            Ellipse circle = new Ellipse();
            circle.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
            circle.Width = circle.Height = 2*radius;
            circle.Tag = tag;
            circle.MouseLeftButtonDown += Circle_MouseLeftButtonDown;

            Canvas.SetTop(circle, e.GetPosition(canvas).Y - radius);
            Canvas.SetLeft(circle, e.GetPosition(canvas).X - radius);

            canvas.Children.Add(circle);
        }

        private void Circle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse circle = sender as Ellipse;
            if (circle != null)
                MessageBox.Show("Tag: " + circle.Tag.ToString());
        }
    }
}
