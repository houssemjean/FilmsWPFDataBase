using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Bonjour.DireBonjour();
            for (int i = 0; i < 10000; i++)
            {
                if (AForge.Math.Tools.IsPowerOf2(i))
                    Console.WriteLine(i + " est une puissance de 2");
            }
        }


    }
}
