using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class SystemNodeFile : SystemNode
    {
        int rootBlockAddress = -1;

        public SystemNodeFile(SystemAddressSpace systemAddressSpace, int index, string name, string text)
            :base(systemAddressSpace, index, name, "File")
        {
            systemAddressSpace.Insert(this);
            rootBlockAddress = systemAddressSpace.Insert(new SystemFileBlock(systemAddressSpace, (text ?? "")));
        }
        
        public override int GetSize()
        {
            return (SystemAddressSpace.GetAddressSpaceBlock(rootBlockAddress) as SystemFileBlock).GetSize();
        }

        public override void Remove()
        {
            if(rootBlockAddress >= 0)
                SystemAddressSpace.Remove(rootBlockAddress);
        }

        public override string ToString()
        {
            return (SystemAddressSpace.GetAddressSpaceBlock(rootBlockAddress) as SystemFileBlock).ToString();
        }
    }
}
