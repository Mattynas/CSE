using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopGuru_web.Validation
{
    public class InputOutputManager
    {
        public static void SaveProcessedText(String filename, String text)
        {
            var streamWriter = new StreamWriter(filename);

            streamWriter.Write(text);
            streamWriter.Close();

        }
    }
}
