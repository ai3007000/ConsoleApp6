using System;

namespace ConsoleApp6.Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\Книги\Прогромирование";
                DeleteFiles(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void DeleteFiles(string path)
        {
            // D:\Книги\Прогромирование
            if (Directory.Exists(path))
            {
                TimeSpan TimeLastAccess = new TimeSpan(0, Directory.GetLastAccessTime(path).Minute, 0); // Время последнего использования

                string[] directories = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);

                foreach (string file in files) // Удаление файлов в каталоге
                {
                    if ((File.Exists(file)) && (TimeLastAccess > TimeSpan.FromMinutes(30))) // Проверка
                    {
                        File.Delete(file);
                        Console.WriteLine($"Удаление файла: {file}");
                    }
                }
                foreach (string dr in directories) // Удаление файлов в подкаталогах
                {
                    DeleteFiles(dr); // Удаление файлов в подкаталогах
                    Directory.Delete(dr); // Удаление подкаталога
                }
            }

        }
    }
}