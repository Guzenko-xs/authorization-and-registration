
using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = DB1.mdb";
        private OleDbConnection myConnection;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public static string id;
        Form3 f3;
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConnection;
            string str = "SELECT * FROM tblUser where Login='" + textBox1.Text + "' AND pass='" + textBox2.Text + "'";
            cmd.CommandText = str;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string query = "SELECT Login FROM tblUser where Login='" + textBox1.Text + "' AND pass='" + textBox2.Text + "'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                Class1.User = command.ExecuteScalar().ToString();
                var f3 = new Form3();
                Hide();
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            myConnection.Close();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox1.Image = Properties.Resources.user2;
            Panel1.BackColor = Color.FromArgb(78, 184, 206);
            textBox1.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox2.Image = Properties.Resources.password1;
            Panel2.BackColor = Color.White;
            textBox2.ForeColor = Color.White;
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            pictureBox2.Image = Properties.Resources.password2;
            Panel2.BackColor = Color.FromArgb(78, 184, 206);
            textBox2.ForeColor = Color.FromArgb(78, 184, 206);

            pictureBox1.Image = Properties.Resources.user1;
            Panel1.BackColor = Color.White;
            textBox1.ForeColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Регистрация и Авторизация пользователя. Выполнил Гузенко Александр ");
        }
        private void Регистрация_Click_1(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form2 MyForm2 = new Form2();
            MyForm2.ShowDialog();
            Close();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)//передвижение формы//
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}

