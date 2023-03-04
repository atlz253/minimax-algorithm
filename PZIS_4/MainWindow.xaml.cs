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

        private const int circleRadius = 15; // Радиус круга дерев4а

        private const int nodesLevelMargin = 50; // Отступ между уровнями древа

        public MainWindow()
        {
            InitializeComponent();

            root = TreeFactory.BuildTree_2();

            DrawTree();
        }

        /// <summary>
        /// Печатает в консоль
        /// </summary>
        /// <param name="message">сообщение для печати</param>
        private void Log(string message) => log.Text = $"\t{DateTime.Now}: {message}\n{log.Text}";

        /// <summary>
        /// Рисует дерево в canvas
        /// </summary>
        private void DrawTree()
        {
            int treeDepth = GetTreeDepth(root);

            Log($"Глубина дерева: {treeDepth}");

            for(int i = 0; i < treeDepth; i++)
            {
                int nodesCount = GetNodeLevelCount(root, i);

                Log($"Количество узлов на уровне {i}: {nodesCount}");

                int nodesMargin = (windowWidth - circleRadius * 2 * nodesCount) / (nodesCount + 1);

                for (int j = 0; j < nodesCount; j++) 
                {
                    Ellipse ellipse = new()
                    {
                        Stroke = Brushes.Black,
                        Width = circleRadius * 2,
                        Height = circleRadius * 2
                    };

                    canvas.Children.Add(ellipse);

                    Canvas.SetLeft(ellipse, nodesMargin + nodesMargin * j + circleRadius * 2 * j);

                    Canvas.SetTop(ellipse, (circleRadius * 2 + nodesLevelMargin) * i);
                }
            }
        }

        /// <summary>
        /// Вычисляет глубину дерева
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <returns>Глубина дерева</returns>
        private int GetTreeDepth(Node root)
        {
            int count = 0;

            foreach(Node node in root.Childrens)
            {
                int c = GetTreeDepth(node);

                if (c > count) 
                { 
                    count = c;
                }
            }

            return count + 1;
        }

        /// <summary>
        /// Подсчитывает количество узлов на определенном уровне
        /// </summary>
        /// <param name="root">Узел</param>
        /// <param name="level">Уровень дерева</param>
        /// <returns>Количество найденных узлов</returns>
        private int GetNodeLevelCount(Node root, int level)
        {
            int count = 0;

            if (level == 0)
            {
                return 1;
            }

            foreach (Node node in root.Childrens)
            {
                count += GetNodeLevelCount(node, level - 1);
            }

            return count;
        }
    }
}
