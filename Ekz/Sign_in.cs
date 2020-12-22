using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ekz
{
    public partial class Sign_in : Form
    {
        public Sign_in()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_UP form = new Sign_UP();
            form.Show();
        }

        // Авторизация пользователя
        public void AugUser(string log, string pass)
        {
            DB dB = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command =
                new MySqlCommand("SELECT * FROM `users` WHERE `login` = @ul AND" +
                "`pass`= @up", dB.getConnection());

            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = pass;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
                MessageBox.Show("Yes");
            else
                MessageBox.Show("No");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = bunifuMaterialTextbox1.Text.Trim(),
                   pass = bunifuMaterialTextbox2.Text.Trim();
                 

            if (login.Length < 5)
            {
                MessageBox.Show("Логин введен неверно!");
                return;
            }

            if (pass.Length < 5)
            {
                MessageBox.Show("Пароль введен неверно!");
                return;
            }

            AugUser(login, pass);
        }
    }
}
