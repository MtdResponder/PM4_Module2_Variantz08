using System;
using System.Drawing;
using System.Windows.Forms;

namespace DateSystemApp
{
    public partial class MainForm : Form
    {
        private TextBox txtDate1;
        private TextBox txtDate2;
        private TextBox txtDaysToAdd;
        private TextBox txtResults;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Настройка формы
            this.Text = "Система работы с датами";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Padding = new Padding(10);

            CreateControls();
        }

        private void CreateControls()
        {
            // Группа для ввода первой даты
            GroupBox groupDate1 = new GroupBox()
            {
                Text = "Первая дата",
                Location = new Point(20, 20),
                Size = new Size(250, 80),
                Font = new Font("Arial", 9)
            };

            Label lblDate1 = new Label()
            {
                Text = "Дата (дд.мм.гггг):",
                Location = new Point(10, 25),
                AutoSize = true,
                Font = new Font("Arial", 9)
            };

            txtDate1 = new TextBox()
            {
                Location = new Point(120, 22),
                Size = new Size(100, 20),
                Text = "01.01.2023",
                Font = new Font("Arial", 9)
            };

            groupDate1.Controls.AddRange(new Control[] { lblDate1, txtDate1 });

            // Группа для ввода второй даты
            GroupBox groupDate2 = new GroupBox()
            {
                Text = "Вторая дата",
                Location = new Point(20, 110),
                Size = new Size(250, 80),
                Font = new Font("Arial", 9)
            };

            Label lblDate2 = new Label()
            {
                Text = "Дата (дд.мм.гггг):",
                Location = new Point(10, 25),
                AutoSize = true,
                Font = new Font("Arial", 9)
            };

            txtDate2 = new TextBox()
            {
                Location = new Point(120, 22),
                Size = new Size(100, 20),
                Text = "01.01.2024",
                Font = new Font("Arial", 9)
            };

            groupDate2.Controls.AddRange(new Control[] { lblDate2, txtDate2 });

            // Группа для операций
            GroupBox groupOperations = new GroupBox()
            {
                Text = "Операции",
                Location = new Point(300, 20),
                Size = new Size(250, 170),
                Font = new Font("Arial", 9)
            };

            Button btnDifference = new Button()
            {
                Text = "Разница между датами",
                Location = new Point(20, 25),
                Size = new Size(200, 30),
                Font = new Font("Arial", 9)
            };

            Button btnAddDays = new Button()
            {
                Text = "Добавить дни",
                Location = new Point(20, 65),
                Size = new Size(200, 30),
                Font = new Font("Arial", 9)
            };

            Button btnDayOfWeek = new Button()
            {
                Text = "День недели",
                Location = new Point(20, 105),
                Size = new Size(200, 30),
                Font = new Font("Arial", 9)
            };

            Button btnIsLeap = new Button()
            {
                Text = "Проверить високосный год",
                Location = new Point(20, 145),
                Size = new Size(200, 30),
                Font = new Font("Arial", 9)
            };

            groupOperations.Controls.AddRange(new Control[] {
                btnDifference, btnAddDays, btnDayOfWeek, btnIsLeap
            });

            // Группа для добавления дней
            GroupBox groupAddDays = new GroupBox()
            {
                Text = "Добавление дней",
                Location = new Point(300, 200),
                Size = new Size(250, 80),
                Font = new Font("Arial", 9)
            };

            Label lblDaysToAdd = new Label()
            {
                Text = "Количество дней:",
                Location = new Point(10, 25),
                AutoSize = true,
                Font = new Font("Arial", 9)
            };

            txtDaysToAdd = new TextBox()
            {
                Location = new Point(130, 22),
                Size = new Size(90, 20),
                Text = "10",
                Font = new Font("Arial", 9)
            };

            groupAddDays.Controls.AddRange(new Control[] { lblDaysToAdd, txtDaysToAdd });

            // Группа для результатов
            GroupBox groupResults = new GroupBox()
            {
                Text = "Результаты",
                Location = new Point(20, 290),
                Size = new Size(530, 120),
                Font = new Font("Arial", 9)
            };

            txtResults = new TextBox()
            {
                Location = new Point(10, 20),
                Size = new Size(510, 90),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Font = new Font("Arial", 9)
            };

            groupResults.Controls.Add(txtResults);

            // Добавление всех групп на форму
            this.Controls.AddRange(new Control[] {
                groupDate1, groupDate2, groupOperations, groupAddDays, groupResults
            });

            // Обработчики событий
            btnDifference.Click += (s, e) => CalculateDifference();
            btnAddDays.Click += (s, e) => AddDaysToDate();
            btnDayOfWeek.Click += (s, e) => GetDayOfWeek();
            btnIsLeap.Click += (s, e) => CheckLeapYear();
        }

        private DateSystem ParseDate(string dateString)
        {
            try
            {
                string[] parts = dateString.Split('.');
                if (parts.Length != 3)
                    throw new FormatException("Неверный формат даты. Используйте дд.мм.гггг");

                int day = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int year = int.Parse(parts[2]);

                return new DateSystem(year, month, day);
            }
            catch (Exception ex)
            {
                throw new FormatException($"Ошибка парсинга даты: {ex.Message}");
            }
        }

        private void CalculateDifference()
        {
            try
            {
                DateSystem date1 = ParseDate(txtDate1.Text);
                DateSystem date2 = ParseDate(txtDate2.Text);

                int difference = date1.DifferenceInDays(date2);
                txtResults.Text = $"Разница между {date1} и {date2}: {difference} дней";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDaysToDate()
        {
            try
            {
                DateSystem date = ParseDate(txtDate1.Text);
                int days = int.Parse(txtDaysToAdd.Text);

                DateSystem newDate = date.AddDays(days);
                txtResults.Text = $"Дата {date} + {days} дней = {newDate}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetDayOfWeek()
        {
            try
            {
                DateSystem date = ParseDate(txtDate1.Text);
                string dayOfWeek = date.GetDayOfWeek();
                txtResults.Text = $"Дата {date}: {dayOfWeek}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckLeapYear()
        {
            try
            {
                DateSystem date = ParseDate(txtDate1.Text);
                bool isLeap = date.IsLeapYear();
                string result = isLeap ? "високосный" : "не високосный";
                txtResults.Text = $"Год {date.Year} - {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}