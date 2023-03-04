using System.Collections.Generic;
using System.Security.Permissions;
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

        /// <summary>
        /// Рисует дерево на canvas
        /// </summary>
        /// <param name="canvas">Canvas для рисования</param>
        /// <param name="canvasWidth">Ширина canvas</param>
        /// <param name="root">Корень дерева</param>
        public static void Draw(Canvas canvas, int canvasWidth, Node root)
        {
            List<TreeCircle> treeCircles = DrawTreeCircles(canvas, canvasWidth, root);

            DrawLines(canvas, treeCircles);
        }

        /// <summary>
        /// Рисует узла дерева
        /// </summary>
        /// <param name="canvas">Canvas для рисования</param>
        /// <param name="canvasWidth">Ширина canvas</param>
        /// <param name="root">Корень дерева</param>
        /// <returns>Список представлений узлов дерева</returns>
        private static List<TreeCircle> DrawTreeCircles(Canvas canvas, int canvasWidth, Node root)
        {
            List<TreeCircle> treeCircles = new();

            int treeDepth = TreeAlgorithms.GetTreeDepth(root);

            Logger.Log($"Глубина дерева: {treeDepth}");

            for (int i = 0; i < treeDepth; i++)
            {
                List<Node> nodes = TreeAlgorithms.GetLevelNodes(root, i);

                Logger.Log($"Количество узлов на уровне {i}: {nodes.Count}");

                int nodesMargin = (canvasWidth - TreeCircle.CircleRadius * 2 * nodes.Count) / (nodes.Count + 1);

                for (int j = 0; j < nodes.Count; j++)
                {
                    TreeCircle treeCircle = new();

                    canvas.Children.Add(treeCircle);

                    treeCircle.Model = nodes[j];

                    treeCircle.Center = new(nodesMargin * (j + 1) + TreeCircle.CircleRadius * (2 * j + 1), nodesLevelMargin + TreeCircle.CircleRadius + (TreeCircle.CircleRadius * 2 + nodesLevelMargin) * i);

                    treeCircles.Add(treeCircle);

                    if (treeCircle.Model.Value == Node.UndifinedValue)
                    {
                        treeCircle.textBox.IsEnabled = false;
                    }
                    else
                    {
                        treeCircle.textBox.Text = treeCircle.Model.Value.ToString();
                    }
                }
            }

            return treeCircles;
        }

        /// <summary>
        /// Рисует линии между узлами дерева
        /// </summary>
        /// <param name="canvas">Canvas для рисования</param>
        /// <param name="treeCircles">Список представлений узлов дерева</param>
        private static void DrawLines(Canvas canvas, List<TreeCircle> treeCircles)
        {
            foreach (TreeCircle treeCircle in treeCircles) 
            { 
                if (treeCircle.Model == null)
                {
                    continue;
                }

                foreach (TreeCircle parentCircle in treeCircles) 
                { 
                    if (treeCircle.Model.Parent != parentCircle.Model)
                    {
                        continue;
                    }

                    Line line = new();

                    line.X1 = treeCircle.Center.X;
                    line.X2 = parentCircle.Center.X;

                    line.Y1 = treeCircle.Center.Y - TreeCircle.CircleRadius;
                    line.Y2 = parentCircle.Center.Y + TreeCircle.CircleRadius;

                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Black;

                    canvas.Children.Add(line);
                }
            }
        }
    }
}
