using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class SystemAddressSpace
    {
        public SystemAddressSpaceBlock[][] systemNodes; 
        int[][] bitVectorOfFreeBlocks;
        
        List<KeyValuePair<string, SystemAddressSpaceBlock>> binarySearchTable;

        public int Size { get; set; }
        public int BlockSize { get; set; }

        public SystemAddressSpace(int size, int blockSize)
        {
            Size = size;
            BlockSize = blockSize;

            var blockMatrixRank = size / (blockSize * blockSize);
            systemNodes = new SystemAddressSpaceBlock[blockMatrixRank][]
                .Select(e => new SystemAddressSpaceBlock[blockMatrixRank])
                .ToArray();

            bitVectorOfFreeBlocks = new int[blockMatrixRank][]
                .Select(e => new int[blockMatrixRank].
                    Select(t => 0)
                    .ToArray())
                .ToArray();

            FormBinarySearchTable();

            new SystemNodeDirectory(this, 0, "Root");
            bitVectorOfFreeBlocks[0][0] = 1;
        }
        void FormBinarySearchTable()
        {
            binarySearchTable = new List<KeyValuePair<string, SystemAddressSpaceBlock>>
                (systemNodes.Length * systemNodes[0].Length);

            for (var i = 0; i < systemNodes.Length; i++)
            {
                for (var j = 0; j < systemNodes[i].Length; j++)
                {
                    if (bitVectorOfFreeBlocks[i][j] == 1)
                    {
                        if (systemNodes[i][j] is SystemNode node)
                            binarySearchTable
                                .Add(new KeyValuePair<string, SystemAddressSpaceBlock>(node.Name, node));
                    }
                }
            }
        }

        public int Insert(SystemAddressSpaceBlock systemAddressSpaceBlock, int index = -1)
        {
            var address = GetWasteBlockAdress();
            var i = address / systemNodes.Length;
            var j = address % systemNodes.Length;

            if(index >= 0)
            {
                i = index / systemNodes.Length;
                j = index % systemNodes.Length;
            }

            bitVectorOfFreeBlocks[i][j] = 1;
            systemNodes[i][j] = systemAddressSpaceBlock;
            
            FormBinarySearchTable();

            systemAddressSpaceBlock.Adress = address;
            return address;
        }
        public int GetWasteBlockAdress()
        {
            for(var i = 0; i < bitVectorOfFreeBlocks.Length; i++)
                for(var j = 0; j < bitVectorOfFreeBlocks[i].Length; j++)
                    if(bitVectorOfFreeBlocks[i][j] == 0)
                        return i * systemNodes.Length + j;
            return 1;
        }

        public void Remove(int address)
        {
            systemNodes[address / systemNodes.Length][address % systemNodes.Length].Remove();
            systemNodes[address / systemNodes.Length][address % systemNodes.Length] = null;
            bitVectorOfFreeBlocks[address / BlockSize][address % BlockSize] = 0;

            FormBinarySearchTable();
        }

        public void Remove(SystemAddressSpaceBlock prev, SystemAddressSpaceBlock deletable)
        {
            if (prev.NextBlock == deletable)
            {
                prev.NextBlock = deletable.NextBlock;
                Remove(deletable.Adress);
            }
        }

        public SystemAddressSpaceBlock GetAddressSpaceBlock(int address)
        {
            return systemNodes[address / systemNodes.Length][address % systemNodes.Length];
        }

        public int FreeSpace()
        {
            var result = bitVectorOfFreeBlocks.Select(e => e.Sum()).ToArray().Sum();

            return Size - result * systemNodes.Length;
        }

        public int FindByBinarySearch(string name)
        {
            binarySearchTable.Sort(new KvpSpaceBlockComparer());
            return binarySearchTable[binarySearchTable.BinarySearch
                (new KeyValuePair<string, SystemAddressSpaceBlock>(name, null), 
                new KvpSpaceBlockComparer())].Value.Adress;
        }
    }

    class KvpSpaceBlockComparer : IComparer<KeyValuePair<string, SystemAddressSpaceBlock>>
    {
        public int Compare(KeyValuePair<string, SystemAddressSpaceBlock> x, KeyValuePair<string, SystemAddressSpaceBlock> y)
        {
            return x.Key.CompareTo(y.Key);
        }
    }
}
