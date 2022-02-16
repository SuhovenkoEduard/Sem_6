using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class SystemFileBlock: SystemAddressSpaceBlock
    {
        string Text { get; }
        
        public SystemFileBlock(SystemAddressSpace systemAddressSpace, string text)
            :base(systemAddressSpace)
        {
            var blockSize = SystemAddressSpace.BlockSize;
            Text = text.Substring(0, (blockSize >= text.Length ? text.Length : blockSize));
            if (text.Length > 0)
            {
                NextBlock = systemAddressSpace.GetAddressSpaceBlock(systemAddressSpace.Insert(new SystemFileBlock
                        (
                            systemAddressSpace,
                            text.Substring(text.Length > blockSize ? blockSize : text.Length)
                        )));
            }
            else
                NextBlock = null;
        }

        public override int GetSize()
        {
            var result = 3;

            if (NextBlock == null)
                return result * SystemAddressSpace.BlockSize;

            var addressBlock = NextBlock as SystemFileBlock;
            while (addressBlock.NextBlock != null)
            {
                result++;
                addressBlock = addressBlock.NextBlock as SystemFileBlock;
            }

            return result * SystemAddressSpace.BlockSize;
        }

        public override void Remove()
        {
            if (NextBlock != null)
                SystemAddressSpace.Remove(this, NextBlock);
        }

        public override string ToString()
        {
            //var nextBlock = (nextBlock == null) ? null : SystemAddressSpace.GetAddressSpaceBlock(nextBlockAddress) as SystemFileBlock;
            return Text + (NextBlock == null ? "" : NextBlock.ToString());
        }
    }
}
