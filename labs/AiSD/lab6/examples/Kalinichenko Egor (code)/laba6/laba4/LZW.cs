using System.Collections.Generic;
using System.Text;

namespace laba4
{
    public class LZW
    {
        private Dictionary<string, int> dictionaryCode = new Dictionary<string, int>();
        Dictionary<int, string> dictionaryDecode = new Dictionary<int, string>();
        List<int> compressed = new List<int>();

        public List<int> Encode(string uncompressed)
        {
            for (var i = 0; i < 256; i++)
                dictionaryCode.Add(((char)i).ToString(), i);

            var w = string.Empty;

            foreach (var c in uncompressed)
            {
                var wc = w + c;
                if (dictionaryCode.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    compressed.Add(dictionaryCode[w]);
                    dictionaryCode.Add(wc, dictionaryCode.Count);
                    w = c.ToString();
                }
            }

            if (!string.IsNullOrEmpty(w))
                compressed.Add(dictionaryCode[w]);

            return compressed;
        }

        public string Decode(List<int> compressed)
        {
            for (var i = 0; i < 256; i++)
                dictionaryDecode.Add(i, ((char)i).ToString());

            var w = dictionaryDecode[compressed[0]];
            compressed.RemoveAt(0);
            var decompressed = new StringBuilder(w);

            foreach (var k in compressed)
            {
                string entry = null;
                if (dictionaryDecode.ContainsKey(k))
                    entry = dictionaryDecode[k];
                else if (k == dictionaryDecode.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                dictionaryDecode.Add(dictionaryDecode.Count, w + entry[0]);

                w = entry;
            }

            return decompressed.ToString();
        }
    }
}
