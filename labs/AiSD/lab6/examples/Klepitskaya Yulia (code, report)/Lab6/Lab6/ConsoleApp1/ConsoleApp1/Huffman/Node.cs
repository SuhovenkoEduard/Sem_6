namespace ConsoleApp1.Huffman
{
    public class Node
    {
        public int Sym;
        public int Freq;
        public readonly int Order;
        public Node Right, Left, Parent;
        public NodeType Nt;

        public Node(NodeType nt, int sym, int freq, int order)
        {
            Nt = nt;
            Sym = sym;
            Freq = freq;
            Order = order;
        }
    }

}
