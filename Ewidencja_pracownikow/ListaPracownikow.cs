using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja_pracownikow
{
    class ListaPracownikow
    {
        public void ListaSprzedawcy()
        {
            string path = @"../txt/DaneSprzedawcy.txt";

            Sprzedawca sprzedawca = new Sprzedawca();
            List<Sprzedawca> ListaSprzed1 = new List<Sprzedawca>();
            List<Sprzedawca> ListaSprzed2 = new List<Sprzedawca>();
            Menu menu = new Menu();
            string line;
            int counter = 0;

            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var line2 = line.Split(';');
                        ListaSprzed1.Add(new Sprzedawca(line2[0], line2[1], Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]), Convert.ToDouble(line2[4])));
                        counter++;
                    }

                }
            }

            var srednia = ListaSprzed1.Sum(x => x.Turnover)/counter;


            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var line2 = line.Split(';');
                        var podstawa = sprzedawca.Basic(Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]));
                        ListaSprzed2.Add(new Sprzedawca(line2[0], line2[1], Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]), Convert.ToDouble(line2[4]), sprzedawca.Bonus(srednia, Convert.ToDouble(line2[4]), podstawa)));
                    }

                }
            }

            Console.WriteLine("Imię       | Nazwisko   |    Godziny |     Stawka |     Premia |     Obrót");

            foreach (var item in ListaSprzed2)
            {
                Console.WriteLine($"{item.Name,-10} | {item.Surname,-10} | {item.WorkingHours,10:F2} | {item.HourlyRate,10:F2} | {item.Srednia,10:F2} | {item.Turnover,10:F2}");
            }

            Console.WriteLine();
            Console.WriteLine("Dowolny klawisz - zapisz obliczone dane, ESC - wyjdź bez zapisu");

            var listaSprzedawcyZapis = ListaSprzed2.ToArray();

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.Clear();
                menu.PierwszaStrona();
            }

            else
            {
                ZapiszListeSprzedawcy(listaSprzedawcyZapis);
                Console.Clear();
                menu.PierwszaStrona();
            }
        }

        public void ListaKierowcy()
        {
            string path = @"../txt/DaneKierowcy.txt";

            Kierowca kierowca = new Kierowca();
            List<Kierowca> ListaKier1 = new List<Kierowca>();
            List<Kierowca> ListaKier2 = new List<Kierowca>();
            Menu menu = new Menu();
            string line;
            int counter = 0;

            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var line2 = line.Split(';');
                        ListaKier1.Add(new Kierowca(line2[0], line2[1], Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]), Convert.ToDouble(line2[4])));
                        counter++;
                    }

                }
            }

            var srednia = ListaKier1.Sum(x => x.Turnover) / counter;


            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        var line2 = line.Split(';');
                        var podstawa = kierowca.Basic(Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]));
                        ListaKier2.Add(new Kierowca(line2[0], line2[1], Convert.ToDouble(line2[2]), Convert.ToDouble(line2[3]), Convert.ToDouble(line2[4]), kierowca.Bonus(srednia, Convert.ToDouble(line2[4]), podstawa)));
                    }

                }
            }

            Console.WriteLine("Imię       | Nazwisko   |    Godziny |     Stawka |     Premia |   Kilometry");

            foreach (var item in ListaKier2)
            {
                Console.WriteLine($"{item.Name,-10} | {item.Surname,-10} | {item.WorkingHours,10:F2} | {item.HourlyRate,10:F2} | {item.Srednia,10:F2} |{item.Kilometers,10}");
            }

            Console.WriteLine();
            Console.WriteLine("Dowolny klawisz - zapisz obliczone dane, ESC - wyjdź bez zapisu");

            var listaKierowcyZapis = ListaKier2.ToArray();

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.Clear();
                menu.PierwszaStrona();
            }
            
            else
            {
                ZapiszListeKierowcow(listaKierowcyZapis);
                Console.Clear();
                menu.PierwszaStrona();
            }
        }

        public void ZapiszListeKierowcow(Kierowca[] kierowca)
        {
            string path = @"../txt/DaneKierowcyZapis.txt";

            using (FileStream fs = File.Create(path))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    foreach (var item in kierowca)
                    {
                        sr.WriteLine($"{item.Name},{item.Surname},{item.WorkingHours},{item.HourlyRate},{item.Srednia},{item.Kilometers}");
                    }
                }
            }
        }

        public void ZapiszListeSprzedawcy(Sprzedawca[] sprzedawca)
        {
            string path = @"../txt/DaneSprzedawcyZapis.txt";

            using (FileStream fs = File.Create(path))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    foreach (var item in sprzedawca)
                    {
                        sr.WriteLine($"{item.Name},{item.Surname},{item.WorkingHours},{item.HourlyRate},{item.Srednia},{item.Turnover}");
                    }
                }
            }
        }

    }
}
