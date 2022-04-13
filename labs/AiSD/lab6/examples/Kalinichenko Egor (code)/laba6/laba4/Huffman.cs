using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba4
{
    public class Huffman
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }

        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frequencies.ContainsKey(source[i]))
                {
                    Frequencies.Add(source[i], 0);
                }

                Frequencies[source[i]]++;
            }

            foreach (var symbol in Frequencies)
            {
                nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value });
            }

            while (nodes.Count > 1)
            {
                var orderedNodes = nodes.OrderBy(node => node.Frequency).ToList();

                if (orderedNodes.Count >= 2)
                {
                    var taken = orderedNodes.Take(2).ToList();

                    var parent = new Node()
                    {
                        Symbol = '*',
                        Frequency = taken[0].Frequency + taken[1].Frequency,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }

                Root = nodes.FirstOrDefault();
            }
        }

        public BitArray Encode(string source)
        {
            var encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                var encodedSymbol = Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }

            var bits = new BitArray(encodedSource.ToArray());

            return bits;
        }

        public string Decode(BitArray bits)
        {
            var current = Root;
            var decoded = new StringBuilder();

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                }
                else
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                }

                if (current.Left == null && current.Right == null)
                {
                    decoded.Append(current.Symbol);
                    current = Root;
                }
            }

            return decoded.ToString();
        }
    }
}
