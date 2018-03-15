using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodebaseCsharp.Linq
{
    static class Data
    {
    }

    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(First).Append(" ").Append(Last).Append(" ; ").Append(ID).Append(" { ");
            foreach (var s in Scores)
            {
                sb.Append(s).Append(" ");
            }
            return sb.Append("}").ToString();
        }
    }
}
