using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTLab1.StringUtils
{
    public enum StringChild
    {
        Other,
        Prefix,
        Suffix,
        Substring,
        Subsequence
    }

    internal class StringUtilsLibrary
    {
        public static StringChild ConvertStringChildToEnum(string stringChild)
        {
            switch (stringChild)
            {
                case "Prefix":
                    {
                        return StringChild.Prefix;
                    }
                case "Suffix":
                    {
                        return StringChild.Suffix;
                    }
                case "Substring":
                    {
                        return StringChild.Substring;
                    }
                default:
                    {
                        return StringChild.Other;
                    }
            }
        }

        public static bool IsInLanguage(char[] language, string s)
        {
            foreach (char c in s.ToCharArray())
            {
                if (!language.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static string[] GetPrefixes(string s)
        {
            StringBuilder currectPrefix = new StringBuilder();
            List<string> prefixes = new()
            {
                currectPrefix.ToString()
            };
            for (int i = 0; i < s.Length; i++)
            {
                currectPrefix.Append(s[i]);
                prefixes.Add(currectPrefix.ToString());
            }
            return prefixes.ToArray();
        }

        public static string[] GetSuffixes(string s)
        {
            string reversedString = new(s.Reverse().ToArray());
            return GetPrefixes(reversedString);
        }

        public static string[] GetSubstrings(string s)
        {
            List<string> substrings = new();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    int substringLength = j - i + 1;
                    substrings.Add(s.Substring(i, substringLength));
                }
            }
            return substrings.OrderBy(x => x.Length).ToArray();
        }

        public static string[] GetAllChilds(string s, StringChild stringMembers)
        {
            string[] resultedChilds;
            switch (stringMembers)
            {
                case StringChild.Prefix:
                    {
                        resultedChilds = GetPrefixes(s);
                        break;
                    }
                case StringChild.Suffix:
                    {
                        resultedChilds = GetSuffixes(s);
                        break;
                    }
                case StringChild.Substring:
                    {
                        resultedChilds = GetSubstrings(s);
                        break;
                    }
                default:
                    {
                        resultedChilds = Array.Empty<string>();
                        break;
                    }
            }
            return resultedChilds;
        }

        public static bool IsSubSequence(string text, string sequence)
        {
            if (sequence.Length == 0) return true;
            int pos = 0;
            int currentIndex = -1;
            while(pos < sequence.Length && text.IndexOf(sequence[pos], currentIndex + 1) != -1)
            {
                currentIndex = text.IndexOf(sequence[pos], currentIndex + 1);
                pos += 1;

            }
            return pos == sequence.Length;
        }

        public static StringChild[] InvestigateText(string text, string sequence)
        {
            if (sequence.Length > text.Length)
            {
                return new StringChild[] { StringChild.Other };
            }

            List<StringChild> children = new();
            if (IsSubSequence(text, sequence) || text.IndexOf(sequence) != -1)
            {
                if (text.IndexOf(sequence) != -1)
                    children.Add(StringChild.Substring);
                if (text[..sequence.Length] == sequence)
                    children.Add(StringChild.Prefix);
                if (text[(text.Length - sequence.Length)..] == sequence)
                    children.Add(StringChild.Suffix);
                if (IsSubSequence(text, sequence))
                    children.Add(StringChild.Subsequence);
            }
            else
            {
                children.Add(StringChild.Other);
            }
            return children.ToArray();
        }
    }
}
