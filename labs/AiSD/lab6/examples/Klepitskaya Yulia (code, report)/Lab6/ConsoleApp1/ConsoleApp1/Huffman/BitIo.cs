using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class BitIO
    {
        private Stream stream;
        private bool ownStream = false, IsOut = false, open = false;

        public BitIO(Stream stream, bool IsOut)
        {
            this.stream = stream;
            open = true;
            this.IsOut = IsOut;
            if (!IsOut)
                bi = stream.ReadByte();
        }

        public BitIO(string FileName, bool IsOut)
        {
            ownStream = true;
            open = true;
            if (IsOut)
                stream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            else
                stream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
        }

        public void Close()
        {
            open = false;
            if (IsOut)
                BitFlush();
            if (ownStream)
                stream.Close();
        }

        private byte buffer = 0, bits = 0;

        public bool CanRead
        {
            get { return this.open && !IsOut; }
        }

        public bool CanWrite
        {
            get { return this.open && IsOut; }
        }

        public void WriteBit(int bit)
        {
            if (!open)
                throw new InvalidOperationException("Cannot write to the disposing stream");
            if (!IsOut)
                throw new NotSupportedException("Cannot write to the read-only bit stream");
            if (bits == 8)
            {
                bits = 0;
                stream.WriteByte(buffer);
                buffer = 0;
            }
            bits++;
            buffer <<= 1;
            if (bit > 0)
                buffer |= 0x1;
        }

        private void BitFlush()
        {
            buffer <<= (8 - bits);
            stream.WriteByte(buffer);
        }

        private byte bc = 0;
        private int bi = 0;

        public int ReadBit()
        {
            if (!open)
                throw new InvalidOperationException("Cannot read from the disposing stream");
            if (IsOut)
                throw new NotSupportedException("Cannot read from a write-only bit stream");
            bc++;
            int ret = (bi & 0x80) > 0 ? 1 : 0;
            bi <<= 1;
            if (bc == 8)
            {
                bc = 0;
                bi = stream.ReadByte();
                if (bi == -1)
                {
                    return 2;
                }
                else

                    bi &= 0xff;
            }
            return ret;
        }
    }
}
