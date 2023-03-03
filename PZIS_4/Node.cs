using System.Collections.Generic;

namespace PZIS_4
{
    public class Node
    {
        int value = int.MaxValue;

        private readonly List<Node> childrens = new();

        public IReadOnlyList<Node> Childrens => childrens;

        public void Add(Node node) => childrens.Add(node);

        public void Remove(Node node) => childrens.Remove(node);
    }
}
