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
                var path = @"D:\Книги\Прогромирование";
                long TotalFolderSize = FolderSize(path); // Расчёт размера файлов
                Console.WriteLine($"Общий размер файлов: {TotalFolderSize} байт");
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
            DirectoryInfo di = new DirectoryInfo(path); // Каталоги
            FileInfo[] AllFiles = di.GetFiles(); // Список файлов

            if (AllFiles.Length > 0)
            {
                foreach (var file in AllFiles)
                {
                    if (file.Exists)
                    {
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