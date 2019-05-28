using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja_pracownikow
{
    abstract class Pracownik
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double WorkingHours { get; set; }
        public double HourlyRate { get; set; }
        public double BasicAmount { get; set; }
        public double BonusAmount { get; set; }
        public double Turnover { get; set; }
        public double Kilometers { get; set; }

        public Pracownik()
        {

        }

        protected Pracownik(string name, string surname, double workingHours, double hourlyRate, double turnover)
        {
            Name = name;
            Surname = surname;
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
            Turnover = turnover;
        }

        internal double Basic(double WorkingHours, double HourlyRate)
        {
            BasicAmount = WorkingHours * HourlyRate;
            return BasicAmount;
        }

        public virtual double Bonus(double srednia1, double srednia2, double BasicAmount)
        {
            return BonusAmount;
        }

    }
}
