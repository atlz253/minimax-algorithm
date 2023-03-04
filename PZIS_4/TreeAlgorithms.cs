using System.Collections.Generic;

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
        public static int MinMaxAlgoritm(Node root, bool IsMax)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            if (root.Childrens.Count == 0)
            {
                return root.Value;
            }

            foreach (Node node in root.Childrens)
            {
                int value = MinMaxAlgoritm(node, !IsMax);

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
        public static void ChangeNodeColor(Node root, int value)
        {
            root.IsIncludedNode = true;

            foreach (Node node in root.Childrens)
            {
                if (node.Value == value)
                {
                    ChangeNodeColor(node, value);

                    return;
                }
            }
        }
    }
}
