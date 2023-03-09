using System.Collections.Generic;
using System.Linq;

namespace PZIS_4
{
    /// <summary>
    /// Предоставляет доступ к алгоритмам для работы с деревьями
    /// </summary>
    internal static class TreeAlgorithms
    {
        /// <summary>
        /// Подсчитывает количество узлов на определенном уровне
        /// </summary>
        /// <param name="root">Узел</param>
        /// <param name="level">Уровень дерева</param>
        /// <returns>Количество найденных узлов</returns>
        public static List<Node> GetLevelNodes(Node root, int level)
        {
            List<Node> nodes = new();

            if (level == 0)
            {
                nodes.Add(root);

                return nodes;
            }

            foreach (Node node in root.Childrens)
            {
                nodes.AddRange(GetLevelNodes(node, level - 1));
            }

            return nodes;
        }

        /// <summary>
        /// Вычисляет глубину дерева
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <returns>Глубина дерева</returns>
        public static int GetTreeDepth(Node root)
        {
            int count = 0;

            foreach (Node node in root.Childrens)
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
        /// Минимакс алгоритм
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="IsMax">Минимум или максимум ищется на уровне</param>
        /// <returns>Значение узла</returns>
        public static double MinMaxAlgoritm(Node root, bool IsMax, bool direction)
        {
            root.IsSkiped = false;

            double min = double.MaxValue;
            double max = double.MinValue;

            if (root.Childrens.Count == 0)
            {
                return root.Value;
            }

            foreach (Node node in (direction) ? root.Childrens : root.Childrens.Reverse())
            {
                double value = MinMaxAlgoritm(node, !IsMax, direction);

                if (IsMax)
                {
                    if (max < value)
                    {
                        max = value;
                    }
                }
                else
                {
                    if (min > value)
                    {
                        min = value;
                    }
                }
            }

            if (IsMax)
            {
                root.Value = max;
            }
            else
            {
                root.Value = min;
            }

            return root.Value;
        }

        /// <summary>
        /// Изменяет цвет узла, в зависимости от того, входит ли тот в решение
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="value">Значение решения</param>
        public static void ChangeNodeColor(Node root, double value, bool direction)
        {
            root.IsSolutionNode = true;

            foreach (Node node in (direction) ? root.Childrens : root.Childrens.Reverse())
            {
                if (node.Value == value)
                {
                    ChangeNodeColor(node, value, direction);

                    return;
                }
            }
        }

        /// <summary>
        /// Алгоритм альфа-бета отсечения для максимумов
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="alpha">Альфа</param>
        /// <param name="beta">Бета</param>
        /// <returns>Значение узла</returns>
        public static double MaxValue(Node root, bool direction, double alpha = double.NegativeInfinity, double beta = double.PositiveInfinity)
        {
            Logger.Log($"MaxValue [узел номер {root.Id}]: запуск алгоритма с α = {alpha} β = {beta}");

            root.IsSkiped = false;

            if (root.Childrens.Count == 0)
            {
                return root.Value;
            }

            double value = double.MinValue;

            foreach (Node child in (direction) ? root.Childrens : root.Childrens.Reverse())
            {
                double newValue = MinValue(child, direction, alpha, beta);

                if (newValue > value)
                {
                    value = newValue;
                }

                if (newValue >= beta)
                {
                    root.Value = value;

                    Logger.Log($"MaxValue [узел номер {root.Id}]: {newValue} >= β({beta}), производим отсечение");

                    return value;
                }

                if (newValue > alpha)
                {
                    alpha = newValue;
                }

                Logger.Log($"MaxValue [узел номер {root.Id}]: обработан узел {child.Id}, теперь α = {alpha} β = {beta}");
            }

            root.Value = value;

            return value;
        }

        /// <summary>
        /// Алгоритм альфа-бета отсечения для минимумов
        /// </summary>
        /// <param name="root">Корень дерева</param>
        /// <param name="alpha">Альфа</param>
        /// <param name="beta">Бета</param>
        /// <returns>Значение узла</returns>
        public static double MinValue(Node root, bool direction, double alpha = double.NegativeInfinity, double beta = double.PositiveInfinity)
        {
            Logger.Log($"MinValue [узел номер {root.Id}]: запуск алгоритма с α = {alpha} β = {beta}");

            root.IsSkiped = false;

            if (root.Childrens.Count == 0)
            {
                return root.Value;
            }

            double value = int.MaxValue;

            foreach (Node child in (direction) ? root.Childrens : root.Childrens.Reverse())
            {
                double newValue = MaxValue(child, direction, alpha, beta);


                if (newValue < value)
                {
                    value = newValue;
                }

                if (newValue <= alpha)
                {
                    Logger.Log($"MinValue [узел номер {root.Id}]: {newValue} <= α({alpha}), производим отсечение");
                    
                    root.Value = value;

                    return value;
                }

                if (newValue < beta)
                {
                    beta = newValue;
                }

                Logger.Log($"MinValue [узел номер {root.Id}]: обработан узел {child.Id}, теперь α = {alpha} β = {beta}");
            }

            root.Value = value;

            return value;
        }
    }
}
