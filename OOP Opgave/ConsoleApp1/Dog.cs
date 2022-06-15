using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Dog : Animal
    {

        public Dog() { }

        public Dog(string name, int weight, int age) : base(name, weight, age)
        {

        }

        public override void MakeSound()
        {
            Console.WriteLine("Bark Bark Bark");
        }

    }
}
