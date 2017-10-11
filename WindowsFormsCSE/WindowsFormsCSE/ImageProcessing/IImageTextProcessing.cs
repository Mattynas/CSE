using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSE
{
    interface IImageTextProcessing
    {
        string GetProcessedText { get; }
        void ImageTextAnalysis(String imageName);
    }
}
