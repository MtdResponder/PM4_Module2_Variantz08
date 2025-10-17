using System;

namespace DateSystemApp.Tests
{
    public static class DateSystemTests
    {
        public static void RunAllTests()
        {
            Console.WriteLine("Запуск тестов DateSystem...");

            TestLeapYear();
            TestDayOfWeek();
            TestDifferenceInDays();
            TestAddDays();
            TestAddDays_YearTransition();
            TestBoundaryDates();
            TestHistoricalDates();
            TestInvalidDate();
            TestLeapYearFebruary();
            TestAddDays_Negative();
            TestToString();

            Console.WriteLine("Все тесты пройдены успешно!");
        }

        public static void TestLeapYear()
        {
            DateSystem date1 = new DateSystem(2020, 2, 29);
            DateSystem date2 = new DateSystem(2021, 2, 28);

            if (!date1.IsLeapYear()) throw new Exception("TestLeapYear failed: 2020 should be leap year");
            if (date2.IsLeapYear()) throw new Exception("TestLeapYear failed: 2021 should not be leap year");

            Console.WriteLine("✓ TestLeapYear passed");
        }

        public static void TestDayOfWeek()
        {
            DateSystem date = new DateSystem(2023, 1, 1);
            string dayOfWeek = date.GetDayOfWeek();

            if (dayOfWeek != "Воскресенье")
                throw new Exception($"TestDayOfWeek failed: expected 'Воскресенье', got '{dayOfWeek}'");

            Console.WriteLine("✓ TestDayOfWeek passed");
        }

        public static void TestDifferenceInDays()
        {
            DateSystem date1 = new DateSystem(2023, 1, 1);
            DateSystem date2 = new DateSystem(2023, 1, 10);

            int difference = date1.DifferenceInDays(date2);
            if (difference != 9)
                throw new Exception($"TestDifferenceInDays failed: expected 9, got {difference}");

            Console.WriteLine("✓ TestDifferenceInDays passed");
        }

        public static void TestAddDays()
        {
            DateSystem date = new DateSystem(2023, 1, 28);
            DateSystem newDate = date.AddDays(5);

            if (newDate.Day != 2 || newDate.Month != 2 || newDate.Year != 2023)
                throw new Exception("TestAddDays failed: expected 02.02.2023");

            Console.WriteLine("✓ TestAddDays passed");
        }

        public static void TestAddDays_YearTransition()
        {
            DateSystem date = new DateSystem(2023, 12, 28);
            DateSystem newDate = date.AddDays(10);

            if (newDate.Day != 7 || newDate.Month != 1 || newDate.Year != 2024)
                throw new Exception("TestAddDays_YearTransition failed: expected 07.01.2024");

            Console.WriteLine("✓ TestAddDays_YearTransition passed");
        }

        public static void TestBoundaryDates()
        {
            DateSystem minDate = new DateSystem(1, 1, 1);
            DateSystem maxDate = new DateSystem(9999, 12, 31);

            if (minDate == null || maxDate == null)
                throw new Exception("TestBoundaryDates failed");

            Console.WriteLine("✓ TestBoundaryDates passed");
        }

        public static void TestHistoricalDates()
        {
            DateSystem historical1 = new DateSystem(1961, 4, 12);
            DateSystem historical2 = new DateSystem(1945, 5, 9);

            if (historical1.Year != 1961 || historical1.Month != 4 || historical1.Day != 12)
                throw new Exception("TestHistoricalDates failed for 1961");

            if (historical2.Year != 1945 || historical2.Month != 5 || historical2.Day != 9)
                throw new Exception("TestHistoricalDates failed for 1945");

            Console.WriteLine("✓ TestHistoricalDates passed");
        }

        public static void TestInvalidDate()
        {
            try
            {
                DateSystem invalidDate = new DateSystem(2023, 2, 30);
                throw new Exception("TestInvalidDate failed: expected exception");
            }
            catch (ArgumentException)
            {
                // Ожидаемое поведение
            }

            Console.WriteLine("✓ TestInvalidDate passed");
        }

        public static void TestLeapYearFebruary()
        {
            DateSystem leapYearDate = new DateSystem(2020, 2, 29);

            if (!leapYearDate.IsLeapYear())
                throw new Exception("TestLeapYearFebruary failed: 2020 should be leap year");

            try
            {
                DateSystem invalidLeapDate = new DateSystem(2021, 2, 29);
                throw new Exception("TestLeapYearFebruary failed: expected exception for 29.02.2021");
            }
            catch (ArgumentException)
            {
                // Ожидаемое поведение
            }

            Console.WriteLine("✓ TestLeapYearFebruary passed");
        }

        public static void TestAddDays_Negative()
        {
            DateSystem date = new DateSystem(2023, 1, 15);
            DateSystem newDate = date.AddDays(-5);

            if (newDate.Day != 10 || newDate.Month != 1 || newDate.Year != 2023)
                throw new Exception("TestAddDays_Negative failed: expected 10.01.2023");

            Console.WriteLine("✓ TestAddDays_Negative passed");
        }

        public static void TestToString()
        {
            DateSystem date = new DateSystem(2023, 12, 5);
            string result = date.ToString();

            if (result != "05.12.2023")
                throw new Exception($"TestToString failed: expected '05.12.2023', got '{result}'");

            Console.WriteLine("✓ TestToString passed");
        }
    }
}