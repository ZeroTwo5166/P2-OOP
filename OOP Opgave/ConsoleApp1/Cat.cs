using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cat : Animal
    {

        public Cat() { }
        public Cat(string name, int weight, int age):base(name, weight, age)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow Meow Meow");
        }




    }
}
