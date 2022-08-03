using Balta.ContentContext;
using System;

namespace Balta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var course = new Course();

            course.Level = ContentContext.Enums.EContentLevel.Advanced;
            
        }
    }
}
