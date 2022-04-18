namespace ConsoleApp1.Huffman
{
    public class Node
    {
        public readonly int Order;
        public int Freq;
        public NodeType Nt;
        public Node Right, Left, Parent;
        public int Sym;

        public Node(NodeType nt, int sym, int freq, int order)
        {
            Nt = nt;
            Sym = sym;
            Freq = freq;
            Order = order;
        }
    }
}