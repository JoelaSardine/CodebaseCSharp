using System;
using System.Text;

namespace CodebaseCsharp
{
    class Format
    {
        public static void Example()
        {
            Format me = new Format();

            me.PrintWithSpacing(new int[] { 109, 2, 3456, 49949, 51, 612379 });
            me.PrintFormats();
        }

        public Format()
        {
        }

        public void PrintWithSpacing<T>(T[] data)
        {           
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Print with 10 char spacing and changing alignment.");
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat(i % 2 == 0 ? "  |{0,10}|  \n" : "  |{0,-10}|\n", data[i]);
            }
            Console.WriteLine($"{sb}");
        }

        public void PrintFormats()
        {
            Console.WriteLine("Print standard formats.");

            double valDouble = -12345.6789;
            int valInt = -123456789;

            string label = "Devise :";
            Console.WriteLine($"  'c ' {label,-15} {valInt,-20:c} int");
            Console.WriteLine($"  'c ' {label,-15} {valDouble,-20:c} double"); // Ne marche pas
            Console.WriteLine($"  'cN' {label,-15} {valInt,-20:c3} int avec c3");
            label = "Decimal :";
            Console.WriteLine($"  'd ' {label,-15} {valInt,-20:d} nombres entiers uniquement");
            Console.WriteLine($"  'dN' {label,-15} {valInt,-20:d3} avec d3");
            label = "Exponentiel :";
            Console.WriteLine($"  'e ' {label,-15} {valInt,-20:e} int");
            Console.WriteLine($"  'e ' {label,-15} {valDouble,-20:e} double");
            Console.WriteLine($"  'eN' {label,-15} {valInt,-20:e3} int avec e3");
            label = "Virgule fixe :";
            Console.WriteLine($"  'f ' {label,-15} {valInt,-20:f} int");
            Console.WriteLine($"  'f ' {label,-15} {valDouble,-20:f} double");
            Console.WriteLine($"  'fN' {label,-15} {valInt,-20:f3} int avec f3");
            label = "Général :";
            Console.WriteLine($"  'g ' {label,-15} {valInt,-20:g} int");
            Console.WriteLine($"  'g ' {label,-15} {valDouble,-20:g} double");
            Console.WriteLine($"  'gN' {label,-15} {valInt,-20:g3} int avec g3");
            label = "Nombre :";
            Console.WriteLine($"  'n ' {label,-15} {valInt,-20:n} int");
            Console.WriteLine($"  'n ' {label,-15} {valDouble,-20:n} double");
            Console.WriteLine($"  'nN' {label,-15} {valInt,-20:n3} int avec n3");
            label = "Pourcentage :";
            Console.WriteLine($"  'p ' {label,-15} {valInt,-20:p} int");
            Console.WriteLine($"  'p ' {label,-15} {valDouble,-20:p} double");
            Console.WriteLine($"  'pN' {label,-15} {valDouble,-20:p3} double avec n3");
            label = "Hexadecimal :";
            Console.WriteLine($"  'X ' {label,-15} {2550,-20:x} nombres entiers uniquement");
            Console.WriteLine($"  'XN' {label,-15} {2550,-20:x4} avec n4");
            label = "Custom :";
            Console.WriteLine($"  {label}");
            Console.WriteLine($"  {"'000000.000000'",-18} : {-valDouble,-20:000000.000000}");
            Console.WriteLine($"  {"'######.######'",-18} : {-valDouble,-20:######.######}");
            Console.WriteLine($"  {"'0.0'",-18} : {-valDouble,-20:0.0}");
            Console.WriteLine($"  {"'#.#'",-18} : {-valDouble,-20:#.#}");
            Console.WriteLine($"  {"'##,#'",-18} : {-valDouble,-20:##,#}");
            Console.WriteLine($"  {"'#,#,'",-18} : {-valDouble,-20:#,#,}");
            Console.WriteLine($"  {"'#0.00% 'mieux''",-18} : {-valDouble,-20:#0.00% 'mieux'}");
            Console.WriteLine($"  {"'\\##0.0e+0'",-18} : {-valDouble,-20:\\##0.0e+0'}");
            Console.WriteLine($"  {"'+pos;-neg;nul'",-18} : 1 = {1:+pos;-neg;nul} ; 0 = {0:+pos;-neg;nul} ; -1 = {-1:+pos;-neg;nul}");
            label = "Date :";
            Console.WriteLine($"  {label}");
            Console.WriteLine("It is now {0:d} at {0:t}.", DateTime.Now);
            

            Console.WriteLine();
        }
    }
}
