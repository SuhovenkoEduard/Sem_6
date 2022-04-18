using System;
using System.Collections.Generic;

namespace ConsoleApp1.Huffman
{
    public class Tree
    {
        public const int CharIsEof = -1;

        private readonly Node _root;

        private readonly Node[] _nodes;

        private readonly int _nodeCount;

        private static void SwapNodes(Node n1, Node n2)
        {
            (n1.Freq, n2.Freq) = (n2.Freq, n1.Freq);

            var t1 = n1.Parent.Left;
            var t2 = n2.Parent.Left;

            if (t1 == n1)
                n1.Parent.Left = n2;
            else
                n1.Parent.Right = n2;

            if (t2 == n2)
                n2.Parent.Left = n1;
            else
                n2.Parent.Right = n1;

            (n1.Parent, n2.Parent) = (n2.Parent, n1.Parent);
        }

        private static Node FindHighestWithSameFreq(Node nd)
        {
            var current = nd;
            if (nd.Parent == null) return current;
            var nd2 = current.Parent;
            if (nd2.Left == current && nd2.Right.Freq == current.Freq)
                current = nd2.Right;

            if (nd2.Parent == null) return current;
            Node nd3 = nd2.Parent;
            if (nd3.Left == nd2 && nd3.Right.Freq == current.Freq)
                current = nd3.Right;
            else if ((nd3.Right == nd2) && (nd3.Left.Freq == current.Freq))
                current = nd3.Left;

            return current;
        }

        private Node GetNytNode()
        {
            return _nodes[257];
        }

        private Node AddToTree(int sym, int count)
        {
            Node nyt = GetNytNode();
            nyt.Nt = NodeType.Int;

            nyt.Right = new Node(NodeType.Nyt, 257, 0, nyt.Order - 1);
            nyt.Left = new Node(NodeType.Sym, sym, count, nyt.Order - 2)
            {
                Parent = nyt.Right.Parent = nyt
            };
            nyt.Sym = 259;
            _nodes[257] = nyt.Right;
            _nodes[sym] = nyt.Left;
            return nyt.Right;
        }

        public void UpdateTree(int sym)
        {
            if (sym > _nodeCount) return;
            var temp = _nodes[sym] ?? AddToTree(sym, 0);

            do
            {
                Node same = FindHighestWithSameFreq(temp);
                if ((same != temp) && (temp.Parent != same))
                    SwapNodes(temp, same);
                temp.Freq++;
                temp = temp.Parent;
            } while (temp != null);
        }

        public Tree()
        {
            _root = new Node(NodeType.Int, 258, 0, 516);
            _root.Right = new Node(NodeType.Nyt, 257, 0, _root.Order - 1);
            _root.Left = new Node(NodeType.Eof, 256, 0, _root.Order - 2)
            {
                Parent = _root.Right.Parent = _root
            };
            _nodes = new Node[259];
            _nodes[256] = _root.Left;
            _nodes[257] = _root.Right;
            _nodeCount = 258;
        }

        public bool Contains(int sym)
        {
            return (sym <= _nodeCount && _nodes[sym] != null);
        }

        private Node _ptr;
        private int _tempCode, _count;
        private bool _inNyt;

        public int DecodeBinary(int bit)
        {
            try
            {
                _ptr ??= _root;
                if (_inNyt)
                {
                    _tempCode <<= 1;
                    _tempCode |= bit;
                    _count++;
                    if (_count == 8)
                    {
                        UpdateTree(_tempCode);
                        int sym = _tempCode;
                        _tempCode = _count = 0;
                        _inNyt = false;
                        return sym;
                    }
                    return CharIsEof;
                }

                _ptr = bit == 1 ? _ptr.Right : _ptr.Left;

                switch (_ptr.Nt)
                {
                    case NodeType.Nyt when _ptr.Sym == 257:
                        _ptr = _root;
                        _inNyt = true;
                        return CharIsEof;
                    case NodeType.Sym:
                    {
                        int sym = _ptr.Sym;
                        UpdateTree(sym);
                        _ptr = _root;
                        return sym;
                    }
                    case NodeType.Eof:
                    case NodeType.Int:
                    default:
                        return CharIsEof;
                }
            }
            catch (NullReferenceException)
            {
                throw new Exception("Corrupted Huffman sequence supplied for decoding");
            }
        }

        public Stack<int> GetCode(int sym)
        {
            var bits = new Stack<int>();
            var pointer = _nodes[sym];
            while (pointer is {Parent: { }})
            {
                bits.Push(pointer.Parent.Left == pointer ? 0 : 1);
                pointer = pointer.Parent;
            }
            return bits;
        }
    }

}
