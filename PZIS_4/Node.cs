using System.Collections.Generic;

namespace PZIS_4
{
    /// <summary>
    /// Узел дерева
    /// </summary>
    public class Node
    {
        public const double UndifinedValue = double.MaxValue; // Неизвестное значение узла

        private double value = UndifinedValue;

        private Node? parent;

        private readonly List<Node> childrens = new();

        private bool isIncludedNode = false;
        private bool isSkiped = false;

        private int id;

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
        /// Значение узла
        /// </summary>
        public double Value
        {
            get => value;

            set => this.value = value;
        }

        /// <summary>
        /// Включен ли узел в итоговое решение
        /// </summary>
        public bool IsSolutionNode
        {
            get => isIncludedNode;

            set => isIncludedNode = value;
        }

        /// <summary>
        /// Был ли узел пропущен?
        /// </summary>
        public bool IsSkiped
        {
            get => isSkiped;

            set => isSkiped = value;
        }

        public int Id => id;

        public Node(int id)
        {
            this.id = id;
        }

        public Node(int id, int value) : this(id)
        {
            Value = value;
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

        /// <summary>
        /// Очищает узел после предыдущих алгоритмов
        /// </summary>
        public void Clear()
        {
            isIncludedNode = false;
            isSkiped = true;

            if (Childrens.Count != 0)
            {
                Value = UndifinedValue;
            }

            foreach (Node node in Childrens)
            {
                node.Clear();
            }
        }
    }
}
