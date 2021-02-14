using Example.Reader;
using System;
using System.Linq;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Dir dir = new Dir(@"C:\Windows\System32", null);
            dir.Create();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
