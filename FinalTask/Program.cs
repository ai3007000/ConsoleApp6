using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Runtime.Serialization;

namespace FinalTask
{
    /// <summary>
    /// Класс Студент
    /// </summary>
    [Serializable]
    class Student
    {
        public string? Name { get; set; } // Имя
        public string? Group { get; set; } // Группа
        public DateTime DateOfBirth { get; set; } // Дата рождения
        /// <summary>
        /// Переопределения метода строки экземпляра
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Имя: {this.Name}\tГруппа: {this.Group}\tДата рождения: {this.DateOfBirth}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"D:\Програмирование\C#\ConsoleApp6\FinalTask\Students.dat";

            var HumanArray = ReadBinaryFile(path); // Возврат массива студентов

            List<string> studentsGroups = new List<string>(); // Список групп
            
            foreach ( var student in HumanArray )
            {
                WriteTextFile(student.Group, HumanArray); // Запись данных в файл
            }
            
        }
        /// <summary>
        /// Запись данных в текстовый файл
        /// </summary>
        /// <param name="group">Группа</param>
        /// <param name="students">Массив студентов</param>
        static void WriteTextFile(string group, Student[] students)
        {
            const string AnotherPath = @"C:\Users\ai500\Desktop\Students";
            Directory.CreateDirectory(AnotherPath);
            if (Directory.Exists(AnotherPath))
            {
                using (var writer = new StreamWriter(AnotherPath + $"\\student {group}.txt"))
                {
                    foreach(var student in students)
                    {
                        if (student.Group == group)
                        {
                            writer.WriteLine($"{student.Name}\t{student.Group}\t{student.DateOfBirth}");
                        }
                    }
                }

            }
        }
        /// <summary>
        /// Чтение бинарных файлов
        /// </summary>
        /// <param name="path">Путь</param>
        /// <returns>Массив студентов</returns>
        static Student[] ReadBinaryFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Student[] humanArray = new Student[0]; // Заглушка для возврата данных
            if (File.Exists(path))
            {

                using (var file = new FileStream(path, FileMode.OpenOrCreate))
                {

                    humanArray = (Student[])formatter.Deserialize(file);
                    return humanArray;
                }

            }
            return humanArray; // Без этого ошибка: не все пути возращают значение
        }
    }
}