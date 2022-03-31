using System;
using System.Collections.Generic;
using System.Linq;

namespace laba4
{
    public class Program
    {
        private static bool _isRightOrLeft = false;

        private static void Main(string[] args)
        {
            var list = new List<NodeList>
            {
                new NodeList("S", "A"),               
                new NodeList("A", "A-T"),
                new NodeList("A", "T"),
                new NodeList("T", "T^U"),
                new NodeList("T", "U"),
                new NodeList("U", "H"),
                new NodeList("H", "(A)"),
                new NodeList("H", "V"),
                new NodeList("V", "VL"),
                new NodeList("V", "L"),
                new NodeList("L", "m"),
            };

            list.Reverse();

            var rules = list.GroupBy(rule => rule.Key).ToDictionary(rule => rule.Key, rule => rule.ToList());

            foreach (var key in rules.Take(rules.Count - 1))
            {
                var result = new List<char>();
                AppendDataInNodeList(key.Key, rules, result);
                var flag = _isRightOrLeft ? "R" : "L";
                Console.WriteLine($"{flag}({key.Key}) -> {{{string.Join(", ", result.Distinct())}}}");
            }
            Console.ReadLine();
        }

        private static void AppendDataInNodeList(string key, IReadOnlyDictionary<string, List<NodeList>> rules, ICollection<char> result)
        {
            if (!rules.ContainsKey(key)) return;

            var values = rules[key];

            foreach (var value in values)
            {
                var newKey = _isRightOrLeft ? value.Value.Last() : value.Value.First();
                if (newKey.ToString().Equals(key))
                {
                    result.Add(newKey);
                    continue;
                }
                result.Add(newKey);
                AppendDataInNodeList(newKey.ToString(), rules, result);
            }
        }
    }

    public class NodeList
    {
        public NodeList(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public string Value { get; }
    }
}
