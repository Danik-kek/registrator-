using System.ComponentModel;

namespace registr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string FilePath = "C:\\Users\\Loli Admin\\Desktop\\logins.txt";
        string FilePathPASS = "C:\\Users\\Loli Admin\\Desktop\\Password.txt";

        private void Form1_Load(object sender, EventArgs e)
        {






        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Close(); // Закрываем Form1, когда Form2 закрывается
            form2.Show();
            this.Hide(); // Скрываем Form1 вместо её закрытия
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool run = true;

            // Проверяем, заполнены ли поля перед входом в цикл
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
            else
            {
                string CheckLog = textBox1.Text;
                string CheckPass = textBox2.Text;
                List<string> logins = new List<string>(File.ReadAllLines(FilePath));
                List<string> passwords = new List<string>(File.ReadAllLines(FilePathPASS));

                bool userExists = false; // Переменная для отслеживания существования пользователя

                for (int i = 0; i < logins.Count; i++)
                {
                    if (logins[i] == CheckLog && passwords[i] == CheckPass)
                    {
                        MessageBox.Show("Такой пользователь существует.");
                        userExists = true; // Устанавливаем флаг, если пользователь найден
                        break; // Выходим из цикла, так как пользователь найден
                    }
                }

                if (!userExists) // Если пользователь не найден
                {
                    // Добавляем нового пользователя
                    File.AppendAllText(FilePath, CheckLog + Environment.NewLine);
                    File.AppendAllText(FilePathPASS, CheckPass + Environment.NewLine);
                    MessageBox.Show("Успешно добавлено.");
                }
            }
        }
    }
}

