using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ветеренарная_клиника_Марков_Кирилл_303гр
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;
            password_again.UseSystemPasswordChar = true;
        }

        private void seetopassword_CheckedChanged(object sender, EventArgs e)
        {
            if (seetopassword.Checked == true)
            {
                password.UseSystemPasswordChar = false;
                password_again.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
                password_again.UseSystemPasswordChar = true;
            }
        }

        private void regestr_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }
}
