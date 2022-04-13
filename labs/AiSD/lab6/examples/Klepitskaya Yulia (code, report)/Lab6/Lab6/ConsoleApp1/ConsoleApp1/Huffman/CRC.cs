using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class CRCCalc
    {
        private static uint poly = 0x82608edb;
        private static uint[] table = new uint[256];

        static CRCCalc()
        {
            for (uint i = 0; i < 256; i++)
            {
                uint cs = i;
                for (uint j = 0; j < 8; j++)
                    cs = (cs & 1) > 0 ? (cs >> 1) ^ poly : cs >> 1;
                table[i] = cs;
            }
        }

        private uint crc;

        public uint GetCRC()
        {
            return crc;
        }

        public CRCCalc()
        {
            crc = 0xffffffff;
        }

        public uint UpdateByte(byte b)
        {
            crc = table[(crc ^ b) & 0xff] ^ (crc >> 8);
            crc ^= 0xffffffff;
            return crc;
        }
    }

}
