using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PZIS_4
{
    /// <summary>
    /// Отвечает за отрисовку деревьев на canvas
    /// </summary>
    internal static class TreeCanvasDrawer
    {
        private const int circleRadius = 15; // Радиус круга дерева

        private const int nodesLevelMargin = 50; // Отступ между уровнями древа

        public static void Draw(Canvas canvas, int canvasWidth, Node root)
        {
            int treeDepth = TreeAlgorithms.GetTreeDepth(root);

            Logger.Log($"Глубина дерева: {treeDepth}");

            for (int i = 0; i < treeDepth; i++)
            {
                int nodesCount = TreeAlgorithms.GetNodeLevelCount(root, i);

                Logger.Log($"Количество узлов на уровне {i}: {nodesCount}");

                int nodesMargin = (canvasWidth - circleRadius * 2 * nodesCount) / (nodesCount + 1);

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
    }
}
