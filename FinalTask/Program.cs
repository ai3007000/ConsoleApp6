using System;
using System.Text;
using System.IO;

namespace ConsoleApp6.FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"D:\Програмирование\C#\ConsoleApp6\FinalTask\bin\Debug\net6.0\Students.dat";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var str = reader.ReadString();
                Console.WriteLine(str);
            }
        }
    }
}