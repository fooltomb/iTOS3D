using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTOS3D.NET
{
    class Message
    {
        private byte[] data = new byte[1024];
        private int startIndex;

        public byte[] Data
        {
            get { return data; }
        }

        public int StartIndex
        {
            get { return startIndex; }
        }
        public int RemainSize
        {
            get { return data.Length - startIndex; }
        }
        public void ReadMessage(int amount,Action<byte[]> processDataCallBack)
        {
            startIndex += amount;
            if (startIndex < 4) return;

            int msgLenth = BitConverter.ToInt32(data, 0);//这个不包含本身的长度
            
            while (msgLenth <= startIndex - 4)
            {
                byte[] value = new byte[msgLenth];
                Array.Copy(data, 4, value, 0, msgLenth);
                processDataCallBack(value);
                startIndex -= (msgLenth + 4);
                Array.Copy(data, msgLenth + 4, data, 0, startIndex);
            }
        }
        public static byte[] PackData(byte[] data)
        {
            byte[] lenth = BitConverter.GetBytes(data.Length);
            return lenth.Concat(data).ToArray<byte>();
        }
    }
}
