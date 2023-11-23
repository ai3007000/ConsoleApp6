using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace ConsoleApp6.FinalTask
{
    class Student
    {
        public string? Name { get; set; }
        public string? Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return $"Имя: {this.Name}\tГруппа: {this.Group}\tДата рождения: {this.DateOfBirth}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            const string path = @"D:\Програмирование\C#\ConsoleApp6\FinalTask\Students.dat";
            if (File.Exists(path))
            {
                using (var file = new FileStream(path, FileMode.OpenOrCreate))
                {
                    
                    Student[] humanArray = (Student[])formatter.Deserialize(file);
                    Console.WriteLine("Десериализация выполнена.");
                    foreach(var student in humanArray)
                    {
                        Console.WriteLine(student.ToString());
                    }
                }
            }
        }
    }
}