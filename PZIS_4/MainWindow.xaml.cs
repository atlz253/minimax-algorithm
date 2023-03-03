using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PZIS_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Node root;

        private const int windowHeight = 720;
        private const int windowWidth = 1280;

        public MainWindow()
        {
            InitializeComponent();

            root = InitTree();

            DrawTree();
        }

        private Node InitTree()
        {
            Node root = new();

            root.Add(new());
            root.Add(new());
            root.Add(new());

            return root;
        }

        private void Log(string message) => log.Text = $"\t{DateTime.Now}: {message}\n{log.Text}";

        private void DrawTree()
        {
            Ellipse ellipse = new()
            {
                Stroke = Brushes.Black,
                Width = 30,
                Height = 30
            };

            canvas.Children.Add(ellipse);

            Canvas.SetLeft(ellipse, windowWidth / 2 - ellipse.Width / 2);
        }
    }
}
