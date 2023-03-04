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
        public static int GetNodeLevelCount(Node root, int level)
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
