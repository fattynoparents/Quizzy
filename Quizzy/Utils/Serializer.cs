using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quizzy
{
    public class Serializer
    {
        /// <summary>
        /// Serialization / deserialization for injecting into .exe
        /// </summary>

        public static void SerializeObject(string fileName, ObjectToSerialize objectToSerialize)
        {
            try
            {
                Stream stream = File.Open(fileName, FileMode.Create);
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
                stream.Close();
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to save the quiz as a template!\n" + e.Message, "Quizzy", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        public static ObjectToSerialize DeSerializeObject(string filename)
        {
            try
            {
                ObjectToSerialize objectToSerialize;
                Stream stream = File.Open(filename, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to open the quiz template!\n" + e.Message, "Quizzy", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to open the quiz template!\n" + e.Message, "Quizzy", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        // ----     ----    ----    ----    ----    ----    ----    ----    ----    ----    ----        
        public static byte[] Serialize(Object o)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter { AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple };
                formatter.Serialize(stream, o);
                return stream.ToArray();
            }
        }

        
    }
}
