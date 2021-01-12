using System;
using System.Data.OleDb;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = DB1.mdb";
        private OleDbConnection myConnection;
        OleDbCommand cmd;
        OleDbDataReader dr;
        int i;
        public int A;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Проверка введены ли данные//
            if ((textbox3.Text == "") | (textbox3.Text == "Username"))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            else
            {
                if ((textbox4.Text == "") | (textbox4.Text == "Password"))
                {
                    MessageBox.Show("Введите пароль");
                    return;
                }
                else
                {
                    if ((textbox1.Text == "") | (textbox1.Text == "First Name"))
                    {
                        MessageBox.Show("Введите Имя пользователя");
                        return;
                    }
                    else
                    {
                        if ((textbox2.Text == "") | (textbox2.Text == "Last Name"))
                        {
                            MessageBox.Show("Введите Фамилию");
                            return;
                        }
                        else
                        {
                            if ((textbox5.Text == "") | (textbox5.Text == "Email"))
                            {
                                MessageBox.Show("Введите Электронную почту");
                                return;
                            }
                            else
                            {
                                if ((textbox6.Text == "") | (textbox6.Text == "Telephone"))
                                {
                                    MessageBox.Show("Введите Телефон");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            if (chekuser())     //Проверка, есть ли уже такой логин//
            {
                return;
            }
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            //добавление в базу данных//
            string query = "INSERT INTO tbluser (Login, pass, FirstName, Email,LastName,Telephone ) VALUES ('" + textbox3.Text + "' , '" + textbox4.Text + "','" + textbox1.Text + "','" + textbox5.Text + "','" + textbox2.Text + "','" + textbox6.Text + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был создан");
                Form2.ActiveForm.Hide();
                Form1 MyForm1 = new Form1();
                MyForm1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Аккаунт не был создан");
            }
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }
        public Boolean chekuser()            //Проверка, есть ли уже такой логин//
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            string str = "SELECT * FROM tblUser where Login='" + textbox3.Text + "'";
            cmd.CommandText = str;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Такой логин уже зарегистрирован, введите другой");
                return true;
            }
            else
            {
                return false;
            }
            myConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Регистрация и Авторизация пользователя. Выполнил Гузенко Александр ");
        }
        private void RegFirstnameText_Click(object sender, EventArgs e)
        {
            white();
            i = 1;
            Controls["textbox" + i.ToString()].Text = "";
            Controls["pictureBox" + i.ToString()].BackgroundImage = Properties.Resources.user2;
            Controls["panel" + i.ToString()].BackColor = Color.FromArgb(78, 184, 206);
            Controls["textbox" + i.ToString()].ForeColor = Color.FromArgb(78, 184, 206);
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            white();
            A = 1;
            blue();
            pictureBox1.Image = Properties.Resources.name2;
        }

        private void white()
        {
            for (int i = 1; i < 6; i++)
            {
                Controls["panel" + i.ToString()].BackColor = Color.White;
                Controls["textbox" + i.ToString()].ForeColor = Color.White;
            }
            pictureBox1.Image = Properties.Resources.name1;
            pictureBox2.Image = Properties.Resources.user1;
            pictureBox3.Image = Properties.Resources.group1;
            pictureBox4.Image = Properties.Resources.password1;
            pictureBox5.Image = Properties.Resources.email1;
            pictureBox6.Image = Properties.Resources.phone1;
        }
        private void blue()
        {
            Controls["textbox" + A.ToString()].Text = "";
            Controls["panel" + A.ToString()].BackColor = Color.FromArgb(78, 184, 206);
            Controls["textbox" + A.ToString()].ForeColor = Color.FromArgb(78, 184, 206); ;
        }

        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }

        private void textbox2_Click(object sender, EventArgs e)
        {
            white();
            A = 2;
            blue();
            pictureBox2.Image = Properties.Resources.user2;
        }

        private void textbox3_Click(object sender, EventArgs e)
        {
            white();
            A = 3;
            blue();
            pictureBox3.Image = Properties.Resources.group2;
        }

        private void textbox4_Click(object sender, EventArgs e)
        {
            white();
            A = 4;
            blue();
            pictureBox4.Image = Properties.Resources.password2;
        }

        private void textbox5_Click(object sender, EventArgs e)
        {
            white();
            A = 5;
            blue();
            pictureBox5.Image = Properties.Resources.email2;
        }

        private void textbox6_Click(object sender, EventArgs e)
        {
            white();
            A = 6;
            blue();
            pictureBox6.Image = Properties.Resources.phone2;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)//передвижение формы//
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
