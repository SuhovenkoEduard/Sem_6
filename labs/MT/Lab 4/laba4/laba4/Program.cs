using System;
using System.Collections.Generic;
using System.Linq;

namespace laba4
{
    public static class Program
    {
        private static IEnumerable<char> CollectSideChars
        (
            string key,
            IReadOnlyDictionary<string, List<string>> rules, 
            Func<string, char> selector
        )
        {
            if (!rules.ContainsKey(key))
                return new HashSet<char>();

            var result = new HashSet<char>();
            var selectedUniqueChars = rules[key].Select(selector).Distinct();
            foreach (var newKey in selectedUniqueChars)
            {
                result.Add(newKey);
                if (!newKey.ToString().Equals(key))
                    result.UnionWith(CollectSideChars(newKey.ToString(), rules, selector));   
            }
            return result;
        }
        
        private static void Main()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                // new("S", "A"), because this is first symbol              
                new("A", "A-T"),
                new("A", "T"),
                new("T", "T^U"),
                new("T", "U"),
                new("U", "H"),
                new("H", "(A)"),
                new("H", "V"),
                new("V", "VL"),
                new("V", "L"),
                new("L", "m"),
            };

            var rules = list
                .GroupBy(rule => rule.Key)
                .ToDictionary(rule => rule.Key, rule => rule.Select(r => r.Value).ToList());

            var selectors = new List<KeyValuePair<char, Func<string, char>>>
            {
                new('L', s => s.First()),
                new('R', s => s.Last())
            };
            
            selectors.ForEach(selector =>
            {
                rules.Keys
                    .Reverse()
                    .ToList()
                    .ForEach(key => 
                        Console.WriteLine($"{selector.Key}({key}) -> [{string.Join(", ", CollectSideChars(key, rules, selector.Value))}]"));
            });
        }
    }
}
