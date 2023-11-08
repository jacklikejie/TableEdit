using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TableEdit
{
    public class FileHelper
    {
        public static T Load<T>(string filePath, string fileName) where T : class
        {
            FileStream stream = new FileStream(filePath + fileName, FileMode.Open);
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
            T Tclass = dataContractSerializer.ReadObject(stream) as T;
            stream.Close();
            return Tclass;
        }

        public static void Save(object obj, string filePath, string fileName)
        {
            if (!File.Exists(filePath))
            {
                new DirectoryInfo(filePath).Create();
            }

            FileStream stream = new FileStream(filePath + fileName, FileMode.Create);
            DataContractSerializer dataContractSerializer = new DataContractSerializer(obj.GetType());
            dataContractSerializer.WriteObject(stream, obj);
            stream.Close();
        }
    }
}
