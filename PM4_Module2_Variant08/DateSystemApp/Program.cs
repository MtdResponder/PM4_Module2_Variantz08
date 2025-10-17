using DateSystemApp.Tests;
using System;
using System.Windows.Forms;

namespace DateSystemApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Запуск тестов
            RunTests();

            // Запуск приложения
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void RunTests()
        {
            try
            {
                DateSystemTests.RunAllTests();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Тесты не пройдены: {ex.Message}", "Ошибка тестов",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}