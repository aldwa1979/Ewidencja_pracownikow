using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ewidencja_pracownikow
{
    class Kierowca : Pracownik
    {
        public double Srednia { get; set; }

        public Kierowca()
        {

        }

        public Kierowca(string name, string surname, double workingHours, double hourlyRate, double kilometers) : base(name, surname, workingHours, hourlyRate, kilometers)
        {
            Name = name;
            Surname = surname;
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
            Kilometers = kilometers;
        }

        public Kierowca(string name, string surname, double workingHours, double hourlyRate, double kilometers, double srednia) : base(name, surname, workingHours, hourlyRate, kilometers)
        {
            Name = name;
            Surname = surname;
            WorkingHours = workingHours;
            HourlyRate = hourlyRate;
            Kilometers = kilometers;
            Srednia = srednia;
        }


        public override double Bonus(double srednia1, double srednia2, double BasicAmount)
        {

            if (srednia1 < srednia2)
            {
                BonusAmount = BasicAmount * 0.2;
                return BonusAmount;
            }
            else
            {
                BonusAmount = BasicAmount * 0.1;
                return BonusAmount;
            }
        }
    }
}
