namespace lab2
{
    class NodeTree
    {
        public int Key { get; set; }
        public NodeTree Left { get; set; }
        public NodeTree Right { get; set; }

        public NodeTree(int key, NodeTree left = null, NodeTree right = null)
        {
            Key = key;
            Left = left;
            Right = right;
        }
    }
}
