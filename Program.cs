using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CheckFileIntegrity
{
    // Главный класс программы.
    class Program
    {
        static void Main(string[] args)
        {
            string pathToTheInputFile = "";
            string pathToTheDirectoryContainingTheFilesToCheck = "";
            Console.WriteLine("Привет! Введите пожалуйста полный путь до файла с файлами: ");
            pathToTheInputFile = Console.ReadLine();
            Console.WriteLine("Введите путь до директория, где лежат файлы: ");
            pathToTheDirectoryContainingTheFilesToCheck = Console.ReadLine();
            List<InfoAboutFile> fileWithReadyFilesInfo = new List<InfoAboutFile>();
            fileWithReadyFilesInfo = FilesWorking.ParsingOurFileWithFiles(pathToTheInputFile);
            string[] arrayWithFilesNames;
            arrayWithFilesNames = FilesWorking.ParsingOurFiles(pathToTheDirectoryContainingTheFilesToCheck);
            CheckFilesIntegrity.FilesIntegrity(pathToTheDirectoryContainingTheFilesToCheck, fileWithReadyFilesInfo, arrayWithFilesNames);
            Console.ReadKey();
        }
    }
}
