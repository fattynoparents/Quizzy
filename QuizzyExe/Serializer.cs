using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizzyExe
{
    /// <summary>
    /// Deserialization of the data transferred from the main program
    /// </summary>
    public class Serializer    
    {
        public static Object BinaryDeserialize(byte[] bytes)
        {
            //try
            //{
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    BinaryFormatter formatter = new BinaryFormatter { AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple };
                    Object obj = (Object)formatter.Deserialize(stream);
                    return obj;
                }
            //}
            //catch (SerializationException e)
            //{
            //    MessageBox.Show("Failed to read the data!\n" + e.Message, "Quiz", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return null;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Failed to read the data!\n" + e.Message, "Quiz", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return null;
            //}
        }

    }
}
