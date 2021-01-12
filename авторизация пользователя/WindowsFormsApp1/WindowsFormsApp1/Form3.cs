using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = DB1.mdb";
        private OleDbConnection myConnection;
        OleDbCommand cmd;
        OleDbDataReader rd;
        public Form3()
        {
            InitializeComponent();
        }





        private void Form3_Load(object sender, EventArgs e)//вывод значений//
        {
            label_User.Text = Class1.User;//логин с формы авторизации
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            cmd = new OleDbCommand();
            cmd.Connection = myConnection;

            string query = "SELECT id FROM tblUser where Login='" + label_User.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            label_id.Text = command.ExecuteScalar().ToString();

            query = "SELECT Login FROM tblUser where Login='" + label_User.Text + "'";
            command = new OleDbCommand(query, myConnection);
            label_User.Text = command.ExecuteScalar().ToString();

            query = "SELECT FirstName FROM tblUser where Login='" + label_User.Text + "'";
            command = new OleDbCommand(query, myConnection);
            label_login.Text = command.ExecuteScalar().ToString();

            query = "SELECT Email FROM tblUser where Login='" + label_User.Text + "'";
            command = new OleDbCommand(query, myConnection);
            label_mail.Text = command.ExecuteScalar().ToString();

            query = "SELECT LastName FROM tblUser where Login='" + label_User.Text + "'";
            command = new OleDbCommand(query, myConnection);
            label_lastname.Text = command.ExecuteScalar().ToString();

            query = "SELECT telephone FROM tblUser where Login='" + label_User.Text + "'";
            command = new OleDbCommand(query, myConnection);
            label_phone.Text = command.ExecuteScalar().ToString();
        }


        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Регистрация и Авторизация пользователя. Выполнил Гузенко Александр ");
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)//передвижение формы//
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
