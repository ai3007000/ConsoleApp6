using System;
using System.IO;

namespace ConsoleApp6.Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\Книги\Прогромирование";
                long SourceSize = FolderSize(path);
                Console.WriteLine($"Исходный размер папки: {SourceSize} байт");

                DeleteFiles(path);
                long NowSize = FolderSize(path);

                Console.WriteLine($"Освобождено: {SourceSize - NowSize} байт");
                Console.WriteLine($"Текущий размер папки: {NowSize} байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Удаление файлов которые не использовались больше 30 минут
        /// </summary>
        /// <param name="path">Путь</param>
        static void DeleteFiles(string path)
        {
            // D:\Книги\Прогромирование
            if (Directory.Exists(path))
            {
                DirectoryInfo directories = new DirectoryInfo(path);
                FileInfo[] files = directories.GetFiles();
                foreach (var file in files) // Удаление файлов в каталоге
                {
                    TimeSpan TimeLastAccess = new TimeSpan(0, file.LastAccessTime.Minute, 0); // Время последнего использования
                    if ((file.Exists) && (TimeLastAccess > TimeSpan.FromMinutes(30))) // Проверка
                    {
                        file.Delete();
                    }
                }
                foreach (var dr in Directory.GetDirectories(path)) // Удаление файлов в подкаталогах
                {
                    DeleteFiles(dr); // Удаление файлов в подкаталогах
                }
            }

        }
        /// <summary>
        /// Подсчёт размера файлов
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Размер файлов</returns>
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