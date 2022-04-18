namespace ConsoleApp1.Huffman
{
    public class CrcCalc
    {
        private uint _crc;
        private const uint Poly = 0x82608edb;
        private static readonly uint[] Table = new uint[256];

        static CrcCalc()
        {
            for (uint i = 0; i < 256; i++)
            {
                var cs = i;
                for (uint j = 0; j < 8; j++)
                    cs = (cs & 1) > 0 ? (cs >> 1) ^ Poly : cs >> 1;
                Table[i] = cs;
            }
        }
        public uint GetCrc()
        {
            return _crc;
        }

        public CrcCalc()
        {
            _crc = 0xffffffff;
        }

        public void UpdateByte(byte b)
        {
            _crc = Table[(_crc ^ b) & 0xff] ^ (_crc >> 8);
            _crc ^= 0xffffffff;
        }
    }

}
