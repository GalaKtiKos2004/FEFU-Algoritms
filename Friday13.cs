using System;

namespace Informatics
{
    class Program
    {
        static void Main()
        {
            int century;
            int result;

            Console.Write("Введите номер столетия: ");

            int.TryParse(Console.ReadLine(), out century);

            Friday13Counter counter = new Friday13Counter(century);
            result = counter.CountFridays13();

            Console.WriteLine($"Количество пятниц 13-ого в {century}-м столетии: {result}");
        }
    }

    class Friday13Counter
    {
        private const int DayOfMonth = 13;
        private const int MonthsInYear = 12;
        private const int DaysInWeek = 7;
        private const int DaysInCentury = 100;
        private const int AdjustmentMonths = 12;
        private const int CalculationFactorMultiplier = 13;
        private const int CalculationFactorDivisor = 5;
        private const int DivisionFactor = 4;
        private const int JFactor = 5;
        private const int FridayInWeek = 6;

        private int _century;

        public Friday13Counter(int century)
        {
            _century = century;
        }

        public int CountFridays13()
        {
            int startYearMultiplier = DaysInCentury;
            int startYearOffset = 1;

            int startYear = (_century - 1) * startYearMultiplier + startYearOffset;
            int endYear = _century * startYearMultiplier;
            int friday13Count = 0;

            for (int year = startYear; year <= endYear; year++)
            {
                for (int month = 1; month <= MonthsInYear; month++)
                {
                    if (IsFriday13(year, month))
                    {
                        friday13Count++;
                    }
                }
            }

            return friday13Count;
        }

        private bool IsFriday13(int year, int month)
        {
            if (month < 3)
            {
                month += AdjustmentMonths;
                year--;
            }

            int k = year % DaysInCentury;
            int j = year / DaysInCentury;

            int calculationFactor = (DayOfMonth + (CalculationFactorMultiplier * (month + 1)) / CalculationFactorDivisor + k + k / DivisionFactor + j / DivisionFactor + JFactor * j) % DaysInWeek;

            return calculationFactor == FridayInWeek;
        }
    }
}