using System;
using System.Globalization;
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
            me.PrintDateFormats();
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
            Console.WriteLine($"  'c ' {label,-15} {valDouble,-20:c} double"); 
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
            
            Console.WriteLine();
        }

        public void PrintDateFormats()
        {
            Console.WriteLine("Print date formats.");
            DateTime t = DateTime.Now;

            Console.WriteLine($"  'd' {"Date courte",-25} {t:d}");
            Console.WriteLine($"  'D' {"Date longue",-25} {t:D}");
            Console.WriteLine($"  'f' {"Date/heure complet court",-25} {t:f}");
            Console.WriteLine($"  'F' {"Date/heure complet long",-25} {t:F}");
            Console.WriteLine($"  'g' {"Date général court",-25} {t:g}");
            Console.WriteLine($"  'G' {"Date général long",-25} {t:G}");
            Console.WriteLine($"  'm' {"Mois/jour",-25} {t:m}");
            Console.WriteLine($"  'M' {"Mois/jour",-25} {t:M}");
            Console.WriteLine($"  'o' {"Date/heure A/R",-25} {t:o}"); // ISO 8601
            Console.WriteLine($"  'O' {"Date/heure A/R",-25} {t:O}");
            Console.WriteLine($"  'r' {"RFC1123",-25} {t:r}");
            Console.WriteLine($"  'R' {"RFC1123",-25} {t:R}");
            Console.WriteLine($"  's' {"Triable",-25} {t:s}");
            Console.WriteLine($"  't' {"Heure courte",-25} {t:t}");
            Console.WriteLine($"  'T' {"Heure longue",-25} {t:T}");
            Console.WriteLine($"  'u' {"Universel triable",-25} {t:u}");
            Console.WriteLine($"  'U' {"Universel complet",-25} {t:U}");
            Console.WriteLine($"  'y' {"Année/mois",-25} {t:y}");
            Console.WriteLine($"  'Y' {"Année/mois",-25} {t:Y}");

            Console.WriteLine();
        }
    }
}
