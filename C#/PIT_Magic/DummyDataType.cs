namespace PIT_Magic
{
    using System;
    using System.Text;

    public class DummyDataType
    {
        public static byte[] GetDummyDataFromHexStr(string hexStr)
        {
            while (hexStr.Length < 8)
            {
                hexStr = hexStr + "0";
            }
            if ((hexStr.Length % 2) != 0)
            {
                return null;
            }
            byte[] buffer2 = new byte[((hexStr.Length / 2) - 1) + 1];
            int num2 = hexStr.Length - 1;
            for (int i = 0; i <= num2; i += 2)
            {
                buffer2[i / 2] = Convert.ToByte(hexStr.Substring(i, 2), 0x10);
            }
            return buffer2;
        }

        public static byte[] GetDummyDataFromStr(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            while (str.Length < 4)
            {
                str = str + "\0";
            }
            return encoding.GetBytes(str);
        }

        public static string GetHexStrFromDummyData(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder(bytes.Length * 2);
            foreach (byte num in bytes)
            {
                builder.AppendFormat("{0:X2}", num);
            }
            while (builder.Length < 8)
            {
                builder.Append("0");
            }
            return builder.ToString();
        }

        public static string GetStrFromDummyData(byte[] bytes) => 
            Encoding.UTF8.GetString(bytes);
    }
}

