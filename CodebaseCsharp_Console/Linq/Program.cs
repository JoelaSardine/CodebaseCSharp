using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseCsharp.Linq
{
    class Program
    {
        /* Standard query operators : 
        * - where
        * - orderby
        * - select
        * - from
        * - group
        * - let 
        */

        static void Main(string[] args)
        {
            Execute();
            
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana",   Last="Omelchenko",  ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire",     Last="O'Donnell",   ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Sven",       Last="Mortensen",   ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {First="Cesar",      Last="Garcia",      ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Debra",      Last="Garcia",      ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new Student {First="Fadi",       Last="Fakhouri",    ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new Student {First="Hanying",    Last="Feng",        ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new Student {First="Hugo",       Last="Garcia",      ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new Student {First="Lance",      Last="Tucker",      ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new Student {First="Terry",      Last="Adams",       ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new Student {First="Eugene",     Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new Student {First="Michael",    Last="Tucker",      ID=122, Scores= new List<int> {94, 92, 91, 91} }
        };

        static void Execute()
        {
            Queries queries = new Queries(students);

            queries.PrintList();
            queries.PrintNames();
            queries.PrintNamesAplhabetically();
            queries.PrintStudentsByAverage(85, true);
            queries.PrintStudentsByAverage(84, false);
            queries.PrintAverageTotal();
        }

        static void LogVar<T>(string name, T variable)
        {
            Console.WriteLine("La variable '{0}' est de type '{1}'.", name, typeof(T));
        }
    }
}
