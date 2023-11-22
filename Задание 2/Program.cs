using System;
using System.IO;

namespace ConsoleApp6.Test2
{
    class Program
    {
        static public void Main()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                Console.WriteLine("Список логических дисков получен.");
                foreach (var drive in drives)
                {
                    if (drive.IsReady)
                    {
                        var Folder = Directory.GetDirectories(drive.Name);// Список каталогов
                        // C:\$WinREAgent
                        foreach (var fd in Folder)
                        {
                            long TotalFolderSize = FolderSize(fd); // Расчёт размера файлов
                            Console.WriteLine($"Общий размер файлов: {FolderSize(fd)}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Функция расчёта размера файлов
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Размер всех файлов</returns>
        static long FolderSize(string path)
        {
            long totalSizeOfDir = 0; // Размер файлов

            var allFiles = Directory.GetFiles(path); // Каталоги
            if (allFiles.Length > 0)
            {
                Console.WriteLine("Список файлов получен." + allFiles[0]);
                foreach (var file in allFiles)
                {
                    if (File.Exists(file))
                    {
                        Console.WriteLine("Файл существует.");
                        totalSizeOfDir += file.Length; // Расчёт размера файлов
                    }
                }
            }

            var subFolders = Directory.GetDirectories(path); // Подкаталоги

            foreach (var dir in subFolders)
            {
                totalSizeOfDir += FolderSize(dir); // Рекурсия
            }
            return totalSizeOfDir;

        }
    }
}