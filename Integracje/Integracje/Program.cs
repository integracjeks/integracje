using Integracje.Helpers;
using System;

namespace Integracje
{
    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
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

        #endregion Methods
    }
}