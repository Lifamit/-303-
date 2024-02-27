using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ветеренарная_клиника_Марков_Кирилл_303гр
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            PasswordTextBox.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPasswordCheckBox.Checked == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void Regestration_Click(object sender, EventArgs e)
        {
            Regestration regestration = new Regestration();
            regestration.ShowDialog();
            
        }

        private void Entry_Click(object sender, EventArgs e)
        {
            string Connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=VetClinic;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(Connectionstring))
            {
                try
                {
                    connection.Open();
                    string sqlquery = $@"SELECT * FROM Registration WHERE login = @Login AND password = @Password;";
                    SqlCommand sqlcommand = new SqlCommand(sqlquery, connection);
                    sqlcommand.Parameters.AddWithValue("@login", LoginTextBox.Text);
                    sqlcommand.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                    SqlDataReader reader = sqlcommand.ExecuteReader();
                    if (reader.Read())
                    {
                        string login = reader["login"].ToString();
                        string password = reader["password"].ToString();
                        MessageBox.Show($"Добро пожаловать, {login}!");
                    }
                    else
                    {
                        MessageBox.Show("Введены неправильные данные или данного аккаунта не существует");
                    }
                    reader.Close();
                    this.Close();

                }
                catch (Exception er)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + er.Message);
                }
                
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В поле \"Логин\" нужно написать свой логин\nВ поле \"Пароль\" нужно написать свой пароль\nКнопка \"Показать пароль?\" показывает пароль", "Помощь в авторизации");
        }
    }
}
