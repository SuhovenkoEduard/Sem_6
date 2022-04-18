using System;
using System.IO;

namespace ConsoleApp1.Huffman
{
    public class BitIo
    {
        private readonly bool _isOut;
        private readonly bool _open;
        private readonly Stream _stream;
        private byte _bc;
        private int _bi;

        private byte _buffer, _bits;

        public BitIo(Stream stream, bool isOut)
        {
            _stream = stream;
            _open = true;
            _isOut = isOut;
            if (!isOut)
                _bi = stream.ReadByte();
        }

        public void WriteBit(int bit)
        {
            if (!_open)
                throw new InvalidOperationException("Cannot write to the disposing stream");
            if (!_isOut)
                throw new NotSupportedException("Cannot write to the read-only bit stream");
            if (_bits == 8)
            {
                _bits = 0;
                _stream.WriteByte(_buffer);
                _buffer = 0;
            }

            _bits++;
            _buffer <<= 1;
            if (bit > 0)
                _buffer |= 0x1;
        }

        public int ReadBit()
        {
            if (!_open)
                throw new InvalidOperationException("Cannot read from the disposing stream");
            if (_isOut)
                throw new NotSupportedException("Cannot read from a write-only bit stream");
            _bc++;
            var ret = (_bi & 0x80) > 0 ? 1 : 0;
            _bi <<= 1;
            if (_bc != 8) return ret;
            _bc = 0;
            _bi = _stream.ReadByte();
            if (_bi == -1) return 2;

            _bi &= 0xff;
            return ret;
        }
    }
}