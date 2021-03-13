using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CheckFileIntegrity
{
    // Класс, который отвечает за обработку файлов.
    class FilesWorking
    {
        //Метод, который возвращает все названия наших файлов.
        public static string[] ParsingOurFiles(string pathToTheDirectoryContainingTheFilesToCheck)
        {
            string[] files = Directory.GetFiles(pathToTheDirectoryContainingTheFilesToCheck);
            string[] arrayWithFileNames = new string[files.Length];
            foreach (var str in files)
            {
                int i = 0;
                string[] words = str.Split(new char[] { '\\' });
                arrayWithFileNames[i] = words[words.Length - 1];
            }
            return arrayWithFileNames;
        }

        // Метод, который считывает и помещает информацию из файла с файлами в список списков.
        public static List<InfoAboutFile> ParsingOurFileWithFiles(string pathToTheInputFile)
        {
            List<InfoAboutFile> fileWithFilesInfo = new List<InfoAboutFile>();
            using (StreamReader sr = new StreamReader(pathToTheInputFile, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arrayForOneLineFromFile = line.Split(' ');
                    fileWithFilesInfo.Add(new InfoAboutFile()
                    {
                        fileName = arrayForOneLineFromFile[0],
                        algorithmName = arrayForOneLineFromFile[1],
                        hashSumm = arrayForOneLineFromFile[2]
                    });
                }
            }
            Console.WriteLine();
            Console.WriteLine("Содержимое файла с файлами: ");
            foreach (InfoAboutFile info in fileWithFilesInfo)
            {
                Console.WriteLine(info.fileName + " " + info.algorithmName + " " + info.hashSumm);
            }
            Console.WriteLine();
            return fileWithFilesInfo;
        }
    }
}
