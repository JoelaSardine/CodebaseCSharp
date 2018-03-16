using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseCsharp
{
    class Program
    {
        /*  Ordre des modifieurs d'accès : 
         *      { public / protected / internal / private / protected internal } // access modifiers
         *      new
         *      { abstract / virtual / override } // inheritance modifiers
         *      sealed
         *      static
         *      readonly
         *      extern
         *      unsafe
         *      volatile
         *      async
         */

        // Eh oui, c'est possible en C# 6
        string name { get; set; } = "Bonjour";

        static void Main(string[] args)
        {
            Execute();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static void Execute()
        {
            Format.Example();
            //Linq.Example();
        }

        static void MethodWithArgs(params object[] args)
        {

        }

        
    }
}
