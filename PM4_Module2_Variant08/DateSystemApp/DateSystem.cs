using System;

namespace DateSystemApp
{
    public class DateSystem
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public DateSystem(int year, int month, int day)
        {
            ValidateDate(year, month, day);
            Year = year;
            Month = month;
            Day = day;
        }

        private void ValidateDate(int year, int month, int day)
        {
            if (year < 1 || year > 9999)
                throw new ArgumentException("Год должен быть в диапазоне от 1 до 9999");

            if (month < 1 || month > 12)
                throw new ArgumentException("Месяц должен быть от 1 до 12");

            int daysInMonth = GetDaysInMonth(year, month);
            if (day < 1 || day > daysInMonth)
                throw new ArgumentException($"День должен быть от 1 до {daysInMonth} для месяца {month} года {year}");
        }

        /// <summary>
        /// Разница в днях между двумя датами
        /// </summary>
        public int DifferenceInDays(DateSystem other)
        {
            DateTime date1 = new DateTime(this.Year, this.Month, this.Day);
            DateTime date2 = new DateTime(other.Year, other.Month, other.Day);
            return Math.Abs((date1 - date2).Days);
        }

        /// <summary>
        /// Добавление дней к дате
        /// </summary>
        public DateSystem AddDays(int days)
        {
            DateTime date = new DateTime(Year, Month, Day);
            DateTime newDate = date.AddDays(days);
            return new DateSystem(newDate.Year, newDate.Month, newDate.Day);
        }

        /// <summary>
        /// Получение дня недели
        /// </summary>
        public string GetDayOfWeek()
        {
            DateTime date = new DateTime(Year, Month, Day);
            return GetRussianDayOfWeek(date.DayOfWeek);
        }

        /// <summary>
        /// Перевод дня недели на русский
        /// </summary>
        private string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестно";
            }
        }

        /// <summary>
        /// Проверка на високосный год
        /// </summary>
        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(Year);
        }

        /// <summary>
        /// Получение количества дней в месяце
        /// </summary>
        private int GetDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public override string ToString()
        {
            return $"{Day:00}.{Month:00}.{Year}";
        }
    }
}