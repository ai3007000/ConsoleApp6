using System;
using System.IO;

namespace ConsoleApp6.Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"D:\Книги\Прогромирование";
                if (Directory.Exists(path))
                {
                    // if (Directory.GetLastAccessTime(path). < TimeSpan.FromMinutes(30))
                    DateTime time = DateTime.Now;
                    TimeSpan tm = new TimeSpan(0, time.Minute, 0);

                    TimeSpan TimeLastAccess = new TimeSpan(0, Directory.GetLastAccessTime(path).Minute, 0);
                    Console.WriteLine(TimeLastAccess < TimeSpan.FromMinutes(30));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}