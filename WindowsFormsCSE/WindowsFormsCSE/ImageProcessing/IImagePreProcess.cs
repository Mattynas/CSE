﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSE
{
    interface IImagePreProcess<T>
    {
        T GetProcessedImage { get; }
        void BinarizeImage(T image);
    }
}