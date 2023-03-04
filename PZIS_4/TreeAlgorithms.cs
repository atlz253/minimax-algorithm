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
    }
}
