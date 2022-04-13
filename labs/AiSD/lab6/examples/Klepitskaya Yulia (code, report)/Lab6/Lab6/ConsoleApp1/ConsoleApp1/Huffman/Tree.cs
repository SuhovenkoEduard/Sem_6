using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Tree
    {
        public const int CharIsEof = -1;

        private Node root;

        private Node[] nodes;

        private int nodeCount = 0;

        private void SwapNodes(Node n1, Node n2)
        {
            int tmp = n1.freq;
            n1.freq = n2.freq;
            n2.freq = tmp;

            Node t1 = n1.parent.left;
            Node t2 = n2.parent.left;

            if (t1 == n1)
                n1.parent.left = n2;
            else
                n1.parent.right = n2;

            if (t2 == n2)
                n2.parent.left = n1;
            else
                n2.parent.right = n1;

            Node t3 = n1.parent;
            n1.parent = n2.parent;
            n2.parent = t3;
        }

        private Node FindHighestWithSameFreq(Node nd)
        {
            Node current = nd;
            if (nd.parent != null)
            {
                Node nd2 = current.parent;
                if ((nd2.left == current) && (nd2.right.freq == current.freq))
                    current = nd2.right;

                if (nd2.parent != null)
                {
                    Node nd3 = nd2.parent;
                    if ((nd3.left == nd2) && (nd3.right.freq == current.freq))
                        current = nd3.right;
                    else if ((nd3.right == nd2) && (nd3.left.freq == current.freq))
                        current = nd3.left;
                }
            }

            return current;
        }

        private Node GetNytNode()
        {
            return nodes[257];
        }

        private Node AddToTree(int sym, int count)
        {
            Node nyt = GetNytNode();
            nyt.nt = NodeType.INT;

            nyt.right = new Node(NodeType.NYT, 257, 0, nyt.order - 1);
            nyt.left = new Node(NodeType.SYM, sym, count, nyt.order - 2);
            nyt.left.parent = nyt.right.parent = nyt;
            nyt.sym = 259;
            nodes[257] = nyt.right;
            nodes[sym] = nyt.left;
            return nyt.right;
        }

        public void UpdateTree(int sym)
        {
            if (sym > nodeCount) return;
            Node temp = nodes[sym];
            if (temp == null)
                temp = AddToTree(sym, 0);

            do
            {
                Node same = FindHighestWithSameFreq(temp);
                if ((same != temp) && (temp.parent != same))
                    SwapNodes(temp, same);
                temp.freq++;
                temp = temp.parent;
            } while (temp != null);
        }

        public Tree()
        {
            root = new Node(NodeType.INT, 258, 0, 516);
            root.right = new Node(NodeType.NYT, 257, 0, root.order - 1);
            root.left = new Node(NodeType.EOF, 256, 0, root.order - 2);
            root.left.parent = root.right.parent = root;
            nodes = new Node[259];
            nodes[256] = root.left;
            nodes[257] = root.right;
            nodeCount = 258;
        }

        public bool contains(int sym)
        {
            return (sym <= nodeCount && nodes[sym] != null);
        }

        public Node GetRootNode()
        {
            return root;
        }

        private Node ptr;
        private int _tempcode = 0, _count = 0;
        private bool InNyt = false;

        public int DecodeBinary(int bit)
        {
            try
            {
                if (ptr == null) ptr = root;
                if (InNyt)
                {
                    _tempcode <<= 1;
                    _tempcode |= bit;
                    _count++;
                    if (_count == 8)
                    {
                        UpdateTree(_tempcode);
                        int sym = _tempcode;
                        _tempcode = _count = 0;
                        InNyt = false;
                        return sym;
                    }
                    return CharIsEof;
                }

                if (bit == 1) ptr = ptr.right;
                else ptr = ptr.left;

                if (ptr.nt == NodeType.NYT && ptr.sym == 257)
                {
                    ptr = root;
                    InNyt = true;
                    return CharIsEof;
                }
                if (ptr.nt == NodeType.SYM)
                {
                    int sym = ptr.sym;
                    UpdateTree(sym);
                    ptr = root;
                    return sym;
                }
                return CharIsEof;
            }
            catch (System.NullReferenceException)
            {
                throw new Exception("Corrupted Huffman sequence supplied for decoding");
            }
        }

        public Stack<int> GetCode(int sym)
        {
            Stack<int> bits = new Stack<int>();
            Node pointer = nodes[sym];
            while (pointer != null && pointer.parent != null)
            {
                if (pointer.parent.left == pointer)
                {
                    bits.Push(0);
                }
                else
                {
                    bits.Push(1);
                }
                pointer = pointer.parent;
            }
            return bits;
        }
    }

}
