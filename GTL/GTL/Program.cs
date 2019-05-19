using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Add(3, 5));
            Console.ReadKey();
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
