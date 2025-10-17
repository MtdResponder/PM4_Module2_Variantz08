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
            // ������ ������
            RunTests();

            // ������ ����������
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
                MessageBox.Show($"����� �� ��������: {ex.Message}", "������ ������",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}