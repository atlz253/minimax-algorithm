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

            Logger.TextBlock = log;

            root = TreeFactory.BuildTree_2();

            TreeCanvasDrawer.Draw(canvas, windowWidth, root);
        }
    }
}
