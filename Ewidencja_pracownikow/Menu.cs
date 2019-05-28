using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja_pracownikow
{
    class Menu
    {
        public void PierwszaStrona()
        {
            Console.SetBufferSize(120, 30);
            Console.SetWindowSize(120, 30);
            Console.SetCursorPosition(40, 5);
            Console.WriteLine(">>> Ewidencja pracowników <<<");

            Console.SetCursorPosition(40, 13);
            Console.WriteLine("1 - Wczytaj i oblicz dane kierowców");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("2 - Wczytaj i oblicz dane sprzedawców");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("3 - Wyjście");

            switch (Console.ReadKey().Key)
            {
               case ConsoleKey.D1:
                    Console.Clear();
                    ListaPracownikow lista1 = new ListaPracownikow();
                    lista1.ListaKierowcy();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    ListaPracownikow lista2 = new ListaPracownikow();
                    lista2.ListaSprzedawcy();
                    break;

                default:
                    break;
            }
        }

    }
}
