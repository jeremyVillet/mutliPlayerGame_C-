using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DllSharpmon.dll
{
    public class Utils
    {
        public static byte[] ConvertObjToByte(Object obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (var ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            catch
            {
                Console.WriteLine("Impossible de sérialiser l'object en byte , avez vous pensé à l attribut  [Serializable] ?");

                return new byte[1] { 0 };
            }

        }
        public static Object ConvertByteToObj(byte[] byteArray)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
               
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
    }
}
