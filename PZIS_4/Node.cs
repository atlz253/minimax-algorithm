using System.Collections.Generic;

namespace PZIS_4
{
    /// <summary>
    /// Узел дерева
    /// </summary>
    public class Node
    {
        int value = int.MaxValue; // int.MaxValue - у узла неизвестное значение

        private Node? parent;

        private readonly List<Node> childrens = new();

        /// <summary>
        /// Дочерние узлы
        /// </summary>
        public IReadOnlyList<Node> Childrens => childrens;

        /// <summary>
        /// Родительский узел
        /// </summary>
        public Node? Parent
        {
            get => parent;

            private set => parent = value;
        }

        /// <summary>
        /// Добавляет дочерний узел
        /// </summary>
        /// <param name="node">Узел для добавления</param>
        public void Add(Node node)
        {
            childrens.Add(node);
            
            node.Parent = this;
        }

        /// <summary>
        /// Удаляет дочерний узел
        /// </summary>
        /// <param name="node">Узел для добавления</param>
        public void Remove(Node node)
        {
            childrens.Remove(node);

            node.Parent = null;
        }
    }
}
