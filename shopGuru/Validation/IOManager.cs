using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopGuru.Validation
{
    public class IOManager
    {
        public static void SaveProcessedText(String filename, String text)
        {
            var streamWriter = new StreamWriter(filename);

            streamWriter.Write(text);
            streamWriter.Close();

        }
    }
}
