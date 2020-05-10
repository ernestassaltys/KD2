using System;
using System.IO;


namespace KD2
{
    class Program
    {
        const string Df = "Duomenys.txt";   
        static void Main(string[] args)
        {
            Console.WriteLine("Įveskite autoriaus pavardę ir vardą");
            string ieskomas = Console.ReadLine();
            Autoriai A = SkaitytiT(Df);
            Spausdinti(A, "Pradinis nerikiuotas sąrašas");
            A.RikiuotiBurbuliukas();
            Spausdinti(A, "Pradinis rikiuotas sąrašas");
            A.Pabaiga();
            Autorius paskutinis = A.ImtiDuomenis();
            Autoriai Naujas = FormuotiNauja(A, paskutinis);
            Spausdinti(Naujas, "Naujas suformuotas sąrašas");
            Brangiausia(Naujas, ieskomas);
            Naujas.Naikinti();
        }
        static Autoriai SkaitytiT(string fv)
        {
            string pavVard, knyga, leidykla;
            double kaina;
            string eilute;
            var A = new Autoriai();
            using (var failas = new StreamReader(fv))
            {
                while ((eilute = failas.ReadLine()) != null)
                {
                    string[] parts = eilute.Split(';');
                    pavVard = parts[0];
                    knyga = parts[1];
                    leidykla = parts[2];
                    kaina = double.Parse(parts[3]);
                    Autorius temp = new Autorius(pavVard, knyga, leidykla, kaina);
                    A.DetiDuomenisT(temp);
                }
                return A;
            }
        }
        static void Spausdinti(Autoriai A, string koment)
        {
            string line = "+------------------------------+----------------------+" +
                "----------------------+--------------+";
            string headers = "|        Pavarde, vardas       |  Knygos pavadinimas  | " +
                "      Leidykla        |    Kaina     |";

                Console.WriteLine(koment);
                Console.WriteLine(line);
                Console.WriteLine(headers);
                Console.WriteLine(line);
                for (A.Pradzia();A.Yra();A.Kitas())
                {
                    Console.WriteLine("{0}", A.ImtiDuomenis().ToString());
                }
                Console.WriteLine(line);
                Console.WriteLine();
        }
        static Autoriai FormuotiNauja(Autoriai A, Autorius paskutinis)
        {
            Autoriai temp = new Autoriai();
            for (A.Pradzia(); A.Yra(); A.Kitas())
            {
                Autorius dabartinis = A.ImtiDuomenis();
                if (dabartinis.leidykla == paskutinis.leidykla)
                {
                    temp.DetiDuomenisT(dabartinis);
                }
            }
            return temp;
        }
        static void Brangiausia(Autoriai A, string ieskomas)
        {
            Autorius max = new Autorius();
            for (A.Pradzia(); A.Yra(); A.Kitas())
            {
                if (A.ImtiDuomenis().pavVard == ieskomas)
                {
                    if (A.ImtiDuomenis().kaina > max.kaina)
                    {
                        max = A.ImtiDuomenis();
                    }
                }
            }
            Console.WriteLine("Autorius: {0}", max.pavVard);
            Console.WriteLine("Brangiausia knyga : {0}", max.knyga);
            Console.WriteLine("Kaina: {0}", max.kaina);
            Console.WriteLine("Leidykla: {0}", max.leidykla);
            Console.WriteLine();
        }

    }
}
