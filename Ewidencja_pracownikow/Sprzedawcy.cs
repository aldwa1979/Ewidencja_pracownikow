using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja_pracownikow
{
    class Sprzedawca : Pracownik
    {
        public double Srednia { get; set; }

        public Sprzedawca()
        {

        }

        public Sprzedawca(string name, string surname, double workingHours, double hourlyRate, double turnover) : base (name, surname, workingHours, hourlyRate, turnover)
        {
            Name = name;
            Surname = surname;
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
            Turnover = turnover;
        }

        public Sprzedawca(string name, string surname, double workingHours, double hourlyRate, double turnover, double srednia) : base(name, surname, workingHours, hourlyRate, turnover)
        {
            Name = name;
            Surname = surname;
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
            Turnover = turnover;
            Srednia = srednia;
        }

        public override double Bonus(double srednia1, double srednia2, double BasicAmount)
        {

            if (srednia1 < srednia2)
            {
                BonusAmount = BasicAmount * 0.4;
                return BonusAmount;
            }
            else
            {
                BonusAmount = BasicAmount * 0.3;
                return BonusAmount;
            }
        }
    }
}
