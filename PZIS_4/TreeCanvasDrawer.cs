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
        private const int nodesLevelMargin = 50; // Отступ между уровнями древа

        public static void Draw(Canvas canvas, int canvasWidth, Node root)
        {
            int treeDepth = TreeAlgorithms.GetTreeDepth(root);

            Logger.Log($"Глубина дерева: {treeDepth}");

            for (int i = 0; i < treeDepth; i++)
            {
                int nodesCount = TreeAlgorithms.GetNodeLevelCount(root, i);

                Logger.Log($"Количество узлов на уровне {i}: {nodesCount}");

                int nodesMargin = (canvasWidth - TreeCircle.CircleRadius * 2 * nodesCount) / (nodesCount + 1);

                for (int j = 0; j < nodesCount; j++)
                {
                    TreeCircle treeCircle = new();

                    canvas.Children.Add(treeCircle);

                    treeCircle.Center = new(nodesMargin * (j + 1) + TreeCircle.CircleRadius * (2 * j + 1), nodesLevelMargin + TreeCircle.CircleRadius + (TreeCircle.CircleRadius * 2 + nodesLevelMargin) * i);
                }
            }
        }
    }
}
