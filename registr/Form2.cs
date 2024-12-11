using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace registr
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // Устанавливаем стандартные параметры формы
            this.BackColor = SystemColors.Window; // Цвет фона формы
            this.ForeColor = SystemColors.ControlText; // Цвет текста
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Устанавливаем стиль границы окна
            this.Text = "Login"; // Устанавливаем заголовок окна
            this.Font = new System.Drawing.Font("Segoe UI", 10); // Устанавливаем шрифт Segoe UI

            // Настройка элементов управления
            SetupControls();
        }

        private void SetupControls()
        {}

        string FilePath = "C:\\Users\\Loli Admin\\Desktop\\logins.txt";
        string FilePathPASS = "C:\\Users\\Loli Admin\\Desktop\\Password.txt";

        private void Form2_Load(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            // Цикл для повторной проверки логина и пароля
            while (true)
            {
                // Проверяем, заполнены ли поля
                if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    string CheckLog = textBox1.Text;
                    string CheckPass = textBox2.Text;
                    List<string> logins = new List<string>(File.ReadAllLines(FilePath));
                    List<string> passwords = new List<string>(File.ReadAllLines(FilePathPASS));

                    bool isSuccessful = false;

                    for (int i = 0; i < logins.Count; i++)
                    {
                        if (logins[i] == CheckLog && passwords[i] == CheckPass)
                        {
                            label3.Text = "Login successful!";
                            isSuccessful = true;
                            break; // Выходим из цикла, если пользователь найден
                        }
                    }

                    if (isSuccessful)
                    {
                        break; // Выходим из внешнего цикла, если вход успешен
                    }
                    else
                    {
                        label3.Text = "Invalid login or password. Try again.";
                        // Очищаем поля для повторного ввода
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus(); // Фокусируемся на поле логина
                        return; // Завершаем обработчик, чтобы избежать блокировки интерфейса
                    }
                }
                else
                {
                    label3.Text = "Please enter both login and password.";
                    return; // Завершаем обработчик, чтобы избежать блокировки интерфейса
                }
            }
        }
    }
}
