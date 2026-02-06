namespace Feladatsor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            F41();
        }

        static int ISzamBekeres()
        {
            int? number = null;
            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.Write("A megadott érték nem alakítható számmá, kérlek add meg újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {int.MinValue} és {int.MaxValue} között kell lennie, kérlek próbáld újra: ");
                }
            }
            while (number is null);

            return number.Value;
        }

        static uint USzamBekeres()
        {
            uint? number = null;
            do
            {
                try
                {
                    number = uint.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.Write("A megadott érték nem alakítható számmá, kérlek add meg újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {uint.MinValue} és {uint.MaxValue} között kell lennie, kérlek próbáld újra: ");
                }
            }
            while (number is null);

            return number.Value;
        }

        static double DoubleBekeres(bool pozitive) // pozitive = true csak pozitív számokat engedélyez
        {
            double? number = null;
            do
            {
                try
                {
                    number = double.Parse(Console.ReadLine()!);
                    if (number < 0 && pozitive)
                    {
                        Console.Write("A megadott szám nem lehet negatív, kérlek add meg újra: ");
                        number = null;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("A megadott érték nem alakítható számmá, kérlek add meg újra: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"A megadott számnak {double.MinValue} és {double.MaxValue} között kell lennie, kérlek próbáld újra: ");
                }
            }
            while (number is null);

            return number.Value;
        }

        static string StringBekeres()
        {
            string? input = null;
            do
            {
                try
                {
                    input = Console.ReadLine()!;
                }
                catch (Exception)
                {
                    Console.WriteLine("Valami félre sikerült, kérlek próbáld újra:");
                }

            }
            while (input is null);
            return input;
        }

        static void F1()
        {
            Console.WriteLine("Hello World!");
        }

        static void F2()
        {
            Console.Write("Add meg a neved:");
            string name = Console.ReadLine()!;
            Console.WriteLine($"Szia {name}!");
        }

        static void F3()
        {
            Console.WriteLine("Adj meg egy egész számot:");
            int a = ISzamBekeres();
            Console.WriteLine($"A szám kétszerese: {a * (long)2}");
        }

        static void F4()
        {
            Console.WriteLine("Adj meg egy egész számot:");
            int a = ISzamBekeres();
            Console.WriteLine("Adj meg még egy egész számot:");
            int b = ISzamBekeres();

            Console.WriteLine($"A számok összege: {a + b}");
            Console.WriteLine($"A számok különbözete: {a - b}");
            Console.WriteLine($"A számok szorzata: {a * b}");
            if (b != 0)
            {
                Console.WriteLine($"A számok hányadosa: {a / b}");
            }
            else
            {
                Console.WriteLine("Nullával nem lehet osztani.");
            }
        }

        static void F5()
        {
            Console.WriteLine("Adj meg egy egész számot:");
            int a = ISzamBekeres();
            Console.WriteLine("Adj meg még egy egész számot:");
            int b = ISzamBekeres();

            if (a > b)
            {
                Console.WriteLine($"{a} nagyobb, mint {b}");
            }
            else if (b > a)
            {
                Console.WriteLine($"{b} nagyobb, mint {a}");
            }
            else
            {
                Console.WriteLine("Egyenlőek a számok.");
            }
        }

        static void F6()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();
            Console.WriteLine("Adj meg még egy pozitív egész számot:");
            uint b = USzamBekeres();
            Console.WriteLine("Adj meg még egy pozitív egész számot:");
            uint c = USzamBekeres();

            if (c < b && c < a)
            {
                Console.WriteLine($"{c} a legkisebb szám");
            }
            else if (b < c && b < a)
            {
                Console.WriteLine($"{b} a legkisebb szám");
            }
            else
            {
                Console.WriteLine($"{a} a legkisebb szám");
            }
        }

        static void F7()
        {
            Console.WriteLine("Add meg az első oldalt:");
            double a = DoubleBekeres(true);
            Console.WriteLine("Add meg a második oldalt:");
            double b = DoubleBekeres(true);
            Console.WriteLine("Add meg a harmadik oldalt:");
            double c = DoubleBekeres(true);

            if (a + b > c || a + c > b || b + c > a)
            {
                Console.WriteLine("Ezekkel az oldalakkal szerkeszthető háromszög.");
            }
            else
            {
                Console.WriteLine("Ezekkel az oldalakkal nem szerkeszthető háromszög.");
            }
        }

        static void F8()
        {
            Console.WriteLine("Add meg az első oldalt:");
            double a = DoubleBekeres(true);
            Console.WriteLine("Add meg a második oldalt:");
            double b = DoubleBekeres(true);

            Console.WriteLine($"A számtani közepe a számoknak: {(a + b) / 2}");
            Console.WriteLine($"A mértani közepe a számoknak: {Math.Sqrt(a * b)}");
        }

        static void F9()
        {
            Console.WriteLine("Add meg az első együtthatót:");
            double a = DoubleBekeres(false);
            Console.WriteLine("Add meg a második együtthatót:");
            double b = DoubleBekeres(false);
            Console.WriteLine("Add meg a harmadik együtthatót:");
            double c = DoubleBekeres(false);

            double D = b * b - 4 * a * c;
            if (D < 0)
            {
                Console.WriteLine("Az egyenletnek nincs megoldása.");
            }
            else
            {
                Console.WriteLine("Az egyenletnek legalább 1 megoldása van.");
            }
        }

        static void F10()
        {
            Console.WriteLine("Add meg az első együtthatót:");
            double a = DoubleBekeres(false);
            Console.WriteLine("Add meg a második együtthatót:");
            double b = DoubleBekeres(false);
            Console.WriteLine("Add meg a harmadik együtthatót:");
            double c = DoubleBekeres(false);

            double D = b * b - 4 * a * c;
            if (D >= 0)
            {
                double plusz = (-b + Math.Sqrt(D)) / (2 * a);
                double minusz = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine($"Az egyenletnek van megoldása: {plusz} és {minusz}");
            }
            else
            {
                Console.WriteLine("Az egyenletnek nincs megoldása.");
            }
        }

        static void F11()
        {
            Console.WriteLine("Add meg az első oldalt:");
            double a = DoubleBekeres(true);
            Console.WriteLine("Add meg a második oldalt:");
            double b = DoubleBekeres(true);

            double atlo = Math.Sqrt(a * a + b * b);
            Console.WriteLine($"Az átló hossza: {atlo:F2}");
        }

        static void F12()
        {
            Console.WriteLine("Add meg az első élet:");
            double a = DoubleBekeres(true);
            Console.WriteLine("Add meg a második élet:");
            double b = DoubleBekeres(true);
            Console.WriteLine("Add meg a harmadik élet:");
            double c = DoubleBekeres(true);

            Console.WriteLine($"A téglatest felszíne: {2 * (a * b) + 4 * (b * c)}");
            Console.WriteLine($"A téglatest térfogata: {a * b * c}");
        }

        static void F13()
        {
            Console.WriteLine("Add meg a kör átmérőjét:");
            double a = DoubleBekeres(true);
            double r = a / 2.0;

            double K = 2 * r * Math.PI;
            double T = r * r * Math.PI;

            Console.WriteLine($"A kör kerülete: {K} és területe: {T}");
        }

        static void F14()
        {
            Console.WriteLine("Add meg a körív sugarát:");
            double a = DoubleBekeres(true);
            Console.WriteLine("Add meg a körív középponti szögét fokban:");
            uint b = USzamBekeres();

            double L = b * Math.PI * a / 180;
            double T = a * a * Math.PI / 360 * b;

            Console.WriteLine($"A határoló ív hossza: {L}");
            Console.WriteLine($"A körcikk területe: {T}");
        }

        static void F15()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();

            for (int i = 0; i < a; i++)
            {
                Console.Write($"{i} ");
            }
        }

        static void F16()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();

            for (int i = 0; i < a; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void F17()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();


            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    Console.Write($"{i} ");
                }
            }
        }

        static void F18()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();

            List<int> osztok = new List<int>();
            int osszeg = 0;

            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    osszeg += i;
                }
            }

            Console.WriteLine($"Az osztok összege: {osszeg}");
        }

        static void F19()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();

            int osszeg = 0;
            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    osszeg += i;
                }
            }


            if (osszeg == 2 * a)
            {
                Console.WriteLine($"{a} egy tökéletes szám.");
            }
            else
            {
                Console.WriteLine($"{a} nem tökéletes szám.");
            }
        }

        static void F20()
        {
            Console.WriteLine("Hatványalap:");
            int a = ISzamBekeres();
            Console.WriteLine("Kitevő:");
            int b = ISzamBekeres();
            Console.WriteLine($"Hatványérték: {Math.Pow(a, b)}");
        }

        static void F21()
        {
            Console.WriteLine("Adj meg egy pozitív számot:");
            uint a = USzamBekeres();
            Console.WriteLine("Ez a szám pozitív.");
        }

        static void F22()
        {
            bool nagyobb = false;
            int osszeg = 0;

            while (!nagyobb)
            {
                Console.WriteLine("írj egy számot:");
                int a = ISzamBekeres();

                if (a > 10)
                {
                    nagyobb = true;
                }
                else
                {
                    osszeg += a;
                }
            }

            Console.WriteLine($"A számok összege: {osszeg}");
        }

        static void F23()
        {
            Console.WriteLine("Adj meg egy egész számot:");
            int num = ISzamBekeres();
            int num_clone = num;

            int db = 0;

            while (num_clone % 2 == 0)
            {
                db++;
                num_clone /= 2;
            }

            string szorzat = "";

            for (int i = 0; i < db; i++)
            {
                szorzat += "2 * ";
            }


            Console.WriteLine($"{num} = {szorzat}{num_clone}");
        }

        static void F24()
        {
            bool alma = false;
            do
            {
                Console.Write("Kérlek írj valamit: ");
                string input = StringBekeres();

                if (input == "alma")
                {
                    alma = true;
                }
            }
            while (!alma);

            Console.WriteLine("Az alma gyümölcs!");
        }

        static void F25()
        {
            Console.WriteLine("Adj meg egy egész számot:");
            int num = ISzamBekeres();
            int num_clone = num;

            int db = 0;
            while (num_clone > 3)
            {
                db++;
                num_clone -= 3;
            }

            Console.WriteLine($"{num} = {db}*3+{num_clone}");

        }

        static void F26()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            int osztok = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    osztok++;
                }
                if (osztok > 2)
                {
                    break;
                }
            }
            if (osztok == 2)
            {
                Console.WriteLine("A szám prím.");
            }
            else
            {
                Console.WriteLine("A szám nem prím.");
            }
        }

        static void F27()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            for (int i = 2; i < num; i++)
            {
                int osztok = 0;

                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        osztok++;
                    }
                    if (osztok > 2)
                    {
                        break;
                    }
                }
                if (osztok == 2)
                {
                    Console.Write($"{i} ");
                }
            }
        }

        static void F28()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            for (int i = 2; i < num; i++)
            {
                int osztok_szama = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        osztok_szama++;
                    }
                    if (osztok_szama > 2)
                    {
                        break;
                    }
                }
                if (osztok_szama == 2)
                {
                    if (num % i == 0)
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }

        static void F29()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            Console.Write($"{num} = ");
            bool elso = true;

            for (uint i = 2; i <= num; i++)
            {
                while (num % i == 0)
                {
                    if (!elso)
                    {
                        Console.Write(" * ");
                    }
                    Console.Write(i);
                    num /= i;
                    elso = false;
                }
            }
        }

        static void F30()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();
            Console.WriteLine("Adj meg még egy pozitív egész számot:");
            uint b = USzamBekeres();

            while (b > 0)
            {
                uint t = b;
                b = a % b;
                a = t;
            }

            Console.WriteLine($"A két szám legnagyobb közös osztója: {a}");
        }

        static void F31()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();
            Console.WriteLine("Adj meg még egy pozitív egész számot:");
            uint b = USzamBekeres();

            uint a_orig = a;
            uint b_orig = b;

            while (b > 0)
            {
                uint t = b;
                b = a % b;
                a = t;
            }

            uint lkkt = (a_orig * b_orig) / a;

            Console.WriteLine($"A két szám legkisebb közös többszöröse: {lkkt}");
        }

        static void F32()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
            }
        }

        static void F33()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint num = USzamBekeres();

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num} + {i} = {num + i}");
            }
        }

        static void F34() //TODO!
        {

        }

        static void F35() //TODO!
        {
            for (int i = 97; i <= 122; i++)
            {
                Console.WriteLine($"{((char)i)} {i}\t");
            }
        }

        static void F36()
        {
            Console.WriteLine("Add meg a sor hosszát:");
            uint a = USzamBekeres();
            Console.WriteLine("Add meg az oszlop hosszát:");
            uint b = USzamBekeres();

            for (int i = 1; i < a * b + 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write($"O");
                }
                else
                {
                    Console.Write($"X");
                }
                if (i % a == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static void F37()
        {
            Console.WriteLine("Add meg a háromszög magasságát:");
            uint a = USzamBekeres();

            string csillag = "*";

            for (int i = 1; i <= a; i++)
            {
                Console.WriteLine(csillag);
                csillag += "**";
            }
        }

        static void F38()
        {
            Console.WriteLine("Add meg a háromszög magasságát:");
            uint a = USzamBekeres();

            string csillag = "*";

            for (int i = 1; i <= a; i++)
            {
                string space = "";
                for (int j = 0; j < a - i; j++)
                {
                    space += " ";
                }

                Console.WriteLine(space + csillag);
                csillag += "**";
            }
        }

        static void F39()
        {
            Console.WriteLine("Add meg a téglalap hosszát:");
            uint a = USzamBekeres();
            Console.WriteLine("Add meg a téglalap magasságát:");
            uint b = USzamBekeres() - 2;

            string hossz = "";
            for (int i = 0; i < a; i++)
            {
                hossz += "*";
            }

            string magassag = "*";
            for (int i = 0; i < a - 2; i++)
            {
                magassag += " ";
            }
            magassag += "*";

            Console.WriteLine(hossz);
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine(magassag);
            }
            Console.WriteLine(hossz);
        }

        static void F40()
        {
            Console.WriteLine("Adj meg egy pozitív egész számot:");
            uint a = USzamBekeres();

            for (int i = 1; i <= a; i++)
            {
                int osszeg = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        osszeg += j;
                    }
                }
                if (osszeg == i * 2)
                {
                    Console.Write($"{i} ");
                }
            }
        }

        static void F41()
        {
            char[] chars = new char[26];
            for (int i = 0; i < 26; i++)
            {
                chars[i] = (char)(i+65);
            }

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    Console.Write(chars[j]);
                }
                Console.WriteLine();

                char[] temp = new char[chars.Length];
                for (int j = 0; j < chars.Length - 1; j++)
                {
                    temp[j] = chars[j + 1];
                }
                temp[temp.Length - 1] = chars[0];

                chars = temp;
            }

        }
    }
}
