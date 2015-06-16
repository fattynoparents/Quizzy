using Microsoft.Win32;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzy
{
    public class InjectionIntoExe
    {
        public static bool Injection(byte[] title, byte[] description, byte[] questions)
        {
            using (MemoryStream memStream = new MemoryStream(Quizzy.Properties.Resources.QuizzyExe))
            {
                var asm = AssemblyDefinition.ReadAssembly(memStream);

                asm.MainModule.Resources.Add(new EmbeddedResource("Title", ManifestResourceAttributes.Public, title));
                asm.MainModule.Resources.Add(new EmbeddedResource("Description", ManifestResourceAttributes.Public, description));
                asm.MainModule.Resources.Add(new EmbeddedResource("Questions", ManifestResourceAttributes.Public, questions));

                SaveFileDialog sfd = new SaveFileDialog { Filter = "Exe files (*.exe)|*.exe", CheckPathExists = true };

                if (sfd.ShowDialog() == true)
                {
                    asm.Write(sfd.FileName);
                    return true;
                }
            }
            return false;
        }
    }
}

