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
                // new KeyValuePair<string, string>("S", "A"),               
                new KeyValuePair<string, string>("A", "A-T"),
                new KeyValuePair<string, string>("A", "T"),
                new KeyValuePair<string, string>("T", "T^U"),
                new KeyValuePair<string, string>("T", "U"),
                new KeyValuePair<string, string>("U", "H"),
                new KeyValuePair<string, string>("H", "(A)"),
                new KeyValuePair<string, string>("H", "V"),
                new KeyValuePair<string, string>("V", "VL"),
                new KeyValuePair<string, string>("V", "L"),
                new KeyValuePair<string, string>("L", "m"),
            };

            list.Reverse();

            var rules = list
                .GroupBy(rule => rule.Key)
                .ToDictionary(rule => rule.Key, rule => rule.Select(r => r.Value).ToList());

            var selectors = new List<KeyValuePair<char, Func<string, char>>>
            {
                new KeyValuePair<char, Func<string, char>>('L', s => s.First()),
                new KeyValuePair<char, Func<string, char>>('R', s => s.Last())
            };
            
            selectors.ForEach(selector =>
            {
                rules.Keys
                    .ToList()
                    .ForEach(key => 
                        Console.WriteLine($"{selector.Key}({key}) -> [{string.Join(", ", CollectSideChars(key, rules, selector.Value))}]"));
            });
        }
    }
}
