using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Animal animal1 = new Animal("Tiger", 140, 14);

            animal1.MakeSound();


            Cat cat1 = new Cat("nino", 5, 3);

            cat1.MakeSound();

            Dog dog1 = new Dog("Tommy", 20, 10);

            dog1.MakeSound();


            Console.ReadLine();



        }
    }
}
