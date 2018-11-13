using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{

    class Program
    {
        public static void Main(string[] args)
        {
            File.Delete(Path);
            File.Delete(Path1);
            File.Delete(Path2);

            Person jim = new Person();
            jim.Name = "Jim";
            jim.Age = 20;
            jim.Weight = 80;

            Car tesla = new Car();
            tesla.Name = "Tesla";
            tesla.Price = 100500;
            tesla.Colour = "black";

            Animal cat = new Animal();
            cat.Name = "Murzic";
            cat.Legs = 4;
            cat.Height = 50;

            SetAllProp<Person>(jim);
            SetAllProp<Car>(tesla);
            SetAllProp<Animal>(cat);

            SetFromFile<Person>(jim);
            SetFromFile<Car>(tesla);
            SetFromFile<Animal>(cat);
          
            Console.ReadLine();

            

        }

        

        public static string Path = @"C:\Homework\Person.txt";
        public static string Path1 = @"C:\Homework\Animal.txt";
        public static string Path2 = @"C:\Homework\Car.txt";


        public static void SetAllProp<T>(T obj)
        {
            var className = nameof(T);
            var objpath = $"{Path}{className}.txt";

            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = prop.GetValue(obj, null);
                string str = $" {prop.Name}: {value} ";
                str = str + Environment.NewLine;

                if (obj.GetType() == typeof(Person))
                    File.AppendAllText(Path, str);

                else if (obj.GetType() == typeof(Animal))                
                    File.AppendAllText(Path1, str);
                
                else  File.AppendAllText(Path2, str);
                
            }           
        }
        public static void SetFromFile<T>(T obj)
        {
            if (obj.GetType() == typeof(Person))
            {
                string text = File.ReadAllText(@"C:\Homework\Person.txt", Encoding.UTF8);                
                Console.WriteLine("Текст из файла: {0}", text);
               
            }
            else if (obj.GetType() == typeof(Animal))
            {
                string text = File.ReadAllText(@"C:\Homework\Animal.txt", Encoding.UTF8);
                Console.WriteLine("Текст из файла: {0}", text);
               
            }
            else if (obj.GetType() == typeof(Car))
            {
                string text = File.ReadAllText(@"C:\Homework\Car.txt", Encoding.UTF8);
                Console.WriteLine("Текст из файла: {0}", text);
                
            }

        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
        }
        public class Car
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public string Colour { get; set; }

        }
        public class Animal
        {
            public string Name { get; set; }
            public int Legs { get; set; }
            public int Height { get; set; }
        }

    }
}
