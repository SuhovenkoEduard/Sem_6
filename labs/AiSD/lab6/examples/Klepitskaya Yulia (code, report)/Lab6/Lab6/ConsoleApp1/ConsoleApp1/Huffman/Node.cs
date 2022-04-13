using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Node
    {
        public int sym;
        public int freq;
        public int order;
        public Node right, left, parent;
        public NodeType nt;

        public Node(NodeType nt, int sym, int freq, int order)
        {
            this.nt = nt;
            this.sym = sym;
            this.freq = freq;
            this.order = order;
        }

        private Node()
        {
        }
    }

}
