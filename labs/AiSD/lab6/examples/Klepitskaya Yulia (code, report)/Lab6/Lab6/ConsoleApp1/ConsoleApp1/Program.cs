namespace ConsoleApp1
{
    public static class Program
    {
        private static void Main()
        {
            const string basePath = "../../../";
            const string resPath = basePath + "resources";
            
            // HUFFMAN
            const string lzwPath = resPath + "/lzw";
            // IO
            const string lzwFrom = lzwPath + "/lzwInput.txt";
            const string lzwTo = lzwPath + "/lzwOutput.txt";
            // archives
            const string lzwArchDirPath = lzwPath + "/archives";
            const string lzwArchBaseFileName = "lzwArch";
            const int lzwTom = 115;

            // LWZ
            const string huffPath = resPath + "/huffman";
            // IO
            const string huffFrom = huffPath + "/huffInput.txt";
            const string huffTo = huffPath + "/huffOutput.txt";
            // archives
            const string huffArchDirPath = huffPath + "/archives";
            const string huffArchBaseFileName = "huffArch";
            const int huffTom = 200;

            Lzw.Lzw.Compress(lzwFrom, lzwArchDirPath, lzwArchBaseFileName, lzwTom);
            Lzw.Lzw.Decompress(lzwArchDirPath, lzwArchBaseFileName, lzwTo);

            Huffman.Huffman.Compress(huffFrom, huffArchDirPath, huffArchBaseFileName, huffTom);
            Huffman.Huffman.Decompress(huffArchDirPath, huffArchBaseFileName, huffTo);
        }
    }
}
