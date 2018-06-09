namespace PIT_Magic
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Text;

    public class PitInputStream
    {
        private BinaryReader inputStream;

        public PitInputStream(Stream byteStream)
        {
            this.inputStream = new BinaryReader(byteStream, Encoding.UTF8);
        }

        public string GetMemoryAddress() => 
            $"0x{this.inputStream.BaseStream.Position.ToString("X")}";

        public int Read(byte[] buffer, int offset, int length) => 
            this.inputStream.Read(buffer, offset, length);

        public byte[] ReadBytes(int byteCount) => 
            this.inputStream.ReadBytes(byteCount);

        public int ReadInt() => 
            this.inputStream.ReadInt32();

        public string ReadRemainingBytes()
        {
            int count = (int) (this.inputStream.BaseStream.Length - this.inputStream.BaseStream.Position);
            byte[] buffer = new byte[0];
            buffer = this.inputStream.ReadBytes(count);
            StringBuilder builder = new StringBuilder(buffer.Length * 2);
            foreach (byte num2 in buffer)
            {
                builder.AppendFormat("{0:X2}", num2);
            }
            return builder.ToString();
        }

        public short ReadShort() => 
            this.inputStream.ReadInt16();

        public string ReadString(byte[] buffer, int strMaxLength)
        {
            char[] chArray = new char[strMaxLength + 1];
            if (this.inputStream.Read(buffer, 0, strMaxLength) != strMaxLength)
            {
                return Conversions.ToString(-1);
            }
            int index = 0;
            for (int i = 0; i < strMaxLength; i++)
            {
                if (buffer[i] == 0)
                {
                    index = i;
                    break;
                }
                chArray[i] = Convert.ToChar(buffer[i]);
            }
            chArray[index] = Convert.ToChar(0);
            return new string(chArray, 0, index);
        }
    }
}

