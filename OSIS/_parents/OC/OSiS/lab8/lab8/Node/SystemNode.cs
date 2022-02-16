using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract class SystemNode: SystemAddressSpaceBlock
    {
        public int Index { get; }
        public int IndexNext { get; set; }

        public string Name { get; }
        public string Type { get; }
        
        public SystemNode(SystemAddressSpace systemAddressSpace, int index, string name, string type): base(systemAddressSpace)
        {
            Index = index;
            Name = name;
            Type = type;

            IndexNext = -1;
        }

        public override abstract int GetSize();

        public override abstract void Remove();
    }
}
