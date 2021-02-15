using Example.Reader;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Example.Abstract;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Dir dir = new Dir(@"C:\Windows\System32", null);
            dir.Create();
            for (int i = 0; i < 2; i++)
            {
                var x = dir.Invoke(x => Path.GetFileName(x).Contains(".exe"));
                foreach (var item in x)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("12345");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
