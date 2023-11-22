using System;
using System.IO;

namespace ConsoleApp6.Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"C:\Users\ai500\Desktop\Прогромирование";
                string[] directories = Directory.GetDirectories(path);
                foreach (var item in directories)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}