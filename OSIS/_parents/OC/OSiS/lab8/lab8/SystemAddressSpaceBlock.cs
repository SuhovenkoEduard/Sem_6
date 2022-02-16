namespace lab8
{
    abstract class SystemAddressSpaceBlock
    {
        public SystemAddressSpace SystemAddressSpace { get; set; }
        public SystemAddressSpaceBlock NextBlock { get; set; } = null;
        public int Adress { get; set; }

        public SystemAddressSpaceBlock(SystemAddressSpace systemAddressSpace)
        {
            SystemAddressSpace = systemAddressSpace;
        }
        public abstract int GetSize();
        public abstract void Remove();
    }
}
