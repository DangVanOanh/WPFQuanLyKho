using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericClass<string> myGenericClass = new MyGenericClass<string>("DANG VAN OANH");
            Console.WriteLine(myGenericClass.genericProperty);

            Console.Read();
        }
    }
}
