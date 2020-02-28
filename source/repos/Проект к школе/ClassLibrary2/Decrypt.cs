﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ClassLibrary2.Security
{
    static public class DecryptClass
    {
        public static object Decrypt(byte[] Message, byte[] key)
        {
            byte[] Arry = new byte[Message.Length / 64];
            byte l = 0;
            MemoryStream s = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            for (int i = 0; i < Arry.Length; i++)
            {
                Arry[i] = (byte)(255 - Message[i * 64 + key[l]]);
                l++;
                if (l == key.Length)
                    l = 0;
            }
            foreach (var i in Arry)
                s.WriteByte(i);

            s.Seek(0, SeekOrigin.Begin);

            return b.Deserialize(s);
        }
        public static string DecryptCesar(string _CrypedMessage, int _key)
        {
            string OutString = "";
            for (int i = 0; i < _CrypedMessage.Length; i++)
            {
                OutString += (Char)((int)_CrypedMessage[i] + _key);
            }
            return OutString;
        }
    }

}
