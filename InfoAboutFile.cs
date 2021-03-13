using System;
using System.Collections.Generic;
using System.Text;

namespace CheckFileIntegrity
{
    // Класс, хранящий информацию из файла с файлами.
    class InfoAboutFile
    {
            public string fileName { get; set; }
            public string algorithmName { get; set; }
            public string hashSumm { get; set; }
    }
}
