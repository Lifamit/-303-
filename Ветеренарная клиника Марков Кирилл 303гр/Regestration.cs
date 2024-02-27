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
    public partial class Regestration : Form
    {
        public Regestration()
        {
            InitializeComponent();
            PasswordTextBox.UseSystemPasswordChar = true;
            AgainPasswordTextBox.UseSystemPasswordChar = true;
        }

        string Connectionstring = @"Data Source=.\SQLEXPRESS;Initial Catalog=VetClinic;Integrated Security=True";

        private void Regestration_Load(object sender, EventArgs e)
        {

        }
        private void Regestr_Click(object sender, EventArgs e)
        {
            if(PasswordTextBox.Text == AgainPasswordTextBox.Text)
            {
                using (SqlConnection connection = new SqlConnection(Connectionstring))
                {
                    try
                    {
                        connection.Open();
                        
                        string sqlQuery = $@"INSERT INTO Registration (login,lastname,firstname,surname,age,telephone,password)
                        VALUES ('{LoginTextBox.Text}','{LastnameTextBox.Text}','{FirstnameTextBox.Text}','{SurnameTextBox.Text}','{AgeTextBox.Text}','{TelephoneTextBox.Text}','{PasswordTextBox.Text}')";
                        using(SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {
                            command.ExecuteNonQuery(); // Вводит данные в базу данных
                            MessageBox.Show($"Вы успешно зарегистрировались!");
                        }

                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Ошибка подключения к базе данных: " + er.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Введённые пароли не совпадают\nПопробуйте снова");
            }
            this.Close();
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
                AgainPasswordTextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
                AgainPasswordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0", "Помощь в регистрации");
        }
    }
}
