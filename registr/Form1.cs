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
            form2.FormClosed += (s, args) => this.Close(); // ��������� Form1, ����� Form2 �����������
            form2.Show();
            this.Hide(); // �������� Form1 ������ � ��������
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool run = true;

            // ���������, ��������� �� ���� ����� ������ � ����
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("����������, ��������� ��� ����.");
            }
            else
            {
                string CheckLog = textBox1.Text;
                string CheckPass = textBox2.Text;
                List<string> logins = new List<string>(File.ReadAllLines(FilePath));
                List<string> passwords = new List<string>(File.ReadAllLines(FilePathPASS));

                bool userExists = false; // ���������� ��� ������������ ������������� ������������

                for (int i = 0; i < logins.Count; i++)
                {
                    if (logins[i] == CheckLog && passwords[i] == CheckPass)
                    {
                        MessageBox.Show("����� ������������ ����������.");
                        userExists = true; // ������������� ����, ���� ������������ ������
                        break; // ������� �� �����, ��� ��� ������������ ������
                    }
                }

                if (!userExists) // ���� ������������ �� ������
                {
                    // ��������� ������ ������������
                    File.AppendAllText(FilePath, CheckLog + Environment.NewLine);
                    File.AppendAllText(FilePathPASS, CheckPass + Environment.NewLine);
                    MessageBox.Show("������� ���������.");
                }
            }
        }
    }
}

