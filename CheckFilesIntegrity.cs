using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CheckFileIntegrity
{
    // Класс, который отвечает за проверку файлов на целостность.
    class CheckFilesIntegrity
    {
        // Метод, который проводит проверку файлов на целостность.
        public static void FilesIntegrity(string pathToTheDirectoryContainingTheFilesToCheck, List<InfoAboutFile> fileWithReadyFilesInfo, string[] arrayWithFilesNames)
        {
            Console.WriteLine("Вывод: ");
            string[] filesNameThatWasFound = new string[fileWithReadyFilesInfo.Count];
            foreach (var info in fileWithReadyFilesInfo)
            {
                bool flag = false;
                foreach (var fileName in arrayWithFilesNames)
                {
                    if (info.fileName == fileName)
                    {
                        flag = true;
                        string infoAboutFile;
                        FileStream file1 = new FileStream(pathToTheDirectoryContainingTheFilesToCheck + fileName, FileMode.Open);
                        StreamReader reader = new StreamReader(file1);
                        infoAboutFile = reader.ReadToEnd();
                        reader.Close();
                        if (info.algorithmName == "md5")
                        {
                            var md5 = MD5.Create();
                            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(infoAboutFile));
                            Console.WriteLine("Хэшсумма файла " + fileName + ": " + Convert.ToBase64String(hash));
                            if (Convert.ToBase64String(hash) == info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + " OK");
                            }
                            if (Convert.ToBase64String(hash) != info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + " FAIL");
                            }
                        }
                        if (info.algorithmName == "sha1")
                        {
                            var sha1 = SHA1.Create();
                            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(infoAboutFile));
                            Console.WriteLine("Хэшсумма файла " + fileName + ": " + Convert.ToBase64String(hash));
                            if (Convert.ToBase64String(hash) == info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + " OK");
                            }
                            if (Convert.ToBase64String(hash) != info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + " FAIL");
                            }
                        }
                        if (info.algorithmName == "sha256")
                        {
                            var sha256 = SHA256.Create();
                            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(infoAboutFile));
                            Console.WriteLine("Хэшсумма файла " + fileName + ": " + Convert.ToBase64String(hash));
                            if (Convert.ToBase64String(hash) == info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + "OK");
                            }
                            if (Convert.ToBase64String(hash) != info.hashSumm)
                            {
                                Console.WriteLine(info.fileName + "FAIL");
                            }
                        }
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine(info.fileName + " NOT FOUND");
                }
            }
        }
    }
}
