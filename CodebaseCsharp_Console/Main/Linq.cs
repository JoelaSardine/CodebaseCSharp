using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseCsharp
{
    class Linq
    {
        List<Student> data;

        public static void Example()
        {
            Linq queries = new Linq(Data.students);

            queries.PrintList();
            queries.PrintNames();
            queries.PrintNamesAplhabetically();
            queries.PrintStudentsByAverage(85, true);
            queries.PrintStudentsByAverage(84, false);
            queries.PrintAverageTotal();
        }

        public Linq(List<Student> data)
        {
            this.data = data;
        }

        public void PrintList()
        {
            Console.WriteLine("Printing overall list :");

            var query = from s in data
                        select s;

            foreach (var s in query)
            {
                Console.WriteLine($"  {s}");
            }
            Console.WriteLine();
        }

        public void PrintNames()
        {
            Console.WriteLine("Printing names list :");

            var query = from s in data
                        orderby s.First
                        select new { s.First, s.Last };

            foreach (var s in query)
            {
                Console.WriteLine($"  {s.First} {s.Last}");
            }
            Console.WriteLine();
        }

        public void PrintNamesAplhabetically()
        {
            Console.WriteLine("Printing names list :");

            var query = from s in data
                        group s by s.Last[0] into sgroup
                        orderby sgroup.Key
                        select sgroup;

            foreach (var group in query)
            {
                Console.WriteLine($"  {group.Key}");
                foreach (var s in group)
                {
                    Console.WriteLine($"    {s.Last}, {s.First}");
                }
            }
            Console.WriteLine();
        }

        public void PrintStudentsByAverage(int treshold, bool higher)
        {
            Console.WriteLine($"Printing names of students that have a {(higher ? "higher" : "lower")} score than {treshold} :");

            var query = from s in data
                        let total = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                        let average = total / 4
                        where (average >= treshold && higher) || (average <= treshold && !higher)
                        select $"({average}) {s.First} {s.Last}";

            foreach (var s in query)
            {
                Console.WriteLine($"  {s}");
            }
            Console.WriteLine();
        }

        public void PrintAverageTotal()
        {
            Console.WriteLine("Average total is :");

            var query = (from s in data
                         let total = s.Scores[0] + s.Scores[1] + s.Scores[2] + s.Scores[3]
                         select total)
                         .Average();

            Console.WriteLine($"  {query}");
            Console.WriteLine();
        }
    }
}
