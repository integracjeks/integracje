using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integracje.Helpers;

namespace Integracje
{
    class Program
    {
        static void Main(string[] args)
        {
            var helper = new SQLHelper();
            helper.CreateDatabase();
            Console.WriteLine("Database created");

            foreach (var item in new JSONHelper().BookList)
            {
                helper.InsertIntem(item);
            }
            Console.WriteLine("\nInsert finished");

            Console.WriteLine("\nEnter to exit...");
            Console.ReadLine();
        }
    }
}
