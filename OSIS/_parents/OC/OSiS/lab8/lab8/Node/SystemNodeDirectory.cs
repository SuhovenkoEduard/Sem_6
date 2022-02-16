using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class SystemNodeDirectory : SystemNode
    {
        public List<int> innerFilesAddresses = new List<int>();

        public SystemNodeDirectory(SystemAddressSpace systemAddressSpace, int index, string name) 
            : base(systemAddressSpace, index, name, "Directory")
        {
            systemAddressSpace.Insert(this, index);
        }

        public void AddNode(SystemAddressSpaceBlock systemAddressSpaceBlock, int index = -1)
        {
            if(innerFilesAddresses.Count > 1)
                (SystemAddressSpace.GetAddressSpaceBlock(innerFilesAddresses.Last()) as SystemNode)
                    .IndexNext = innerFilesAddresses.Last();
            innerFilesAddresses.Add(index);
        }
        public override void Remove()
        {
            while (innerFilesAddresses.Count > 0)
                RemoveNode(innerFilesAddresses.First());
        }
        public void RemoveNode(int address)
        {
            if (innerFilesAddresses.Contains(address))
            {
                innerFilesAddresses.Remove(address);
                SystemAddressSpace.Remove(address);
            }
        }

        public override int GetSize()
        {
            var result = 0;
            foreach (var item in innerFilesAddresses)
            {
                var block = SystemAddressSpace.GetAddressSpaceBlock(item);
                if (block != null)
                    result += block.GetSize();
            }
            return result + SystemAddressSpace.BlockSize;
        }
    }
}
