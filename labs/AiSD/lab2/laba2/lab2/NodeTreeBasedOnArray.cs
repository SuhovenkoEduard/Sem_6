namespace lab2
{
    class NodeTreeBasedOnArray
    {
        public int Key { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }

        public NodeTreeBasedOnArray(int key, int left = int.MinValue, int right = int.MinValue)
        {
            Key = key;
            Left = left;
            Right = right;
        }
    }
}
