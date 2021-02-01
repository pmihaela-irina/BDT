using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDT_Campus
{
    public partial class Log_bloc : Form
    {
        int tip_user;
        public Log_bloc()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("Select rol FROM login  WHERE user_tip= '" + textBox_username.Text + "'AND pass='" + textBox_password.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt); //trimite la toate interfetele
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                Log_verif intf = new Log_verif(0, textBox_username.Text);
                intf.Show();
            }
            else
            {
                MessageBox.Show("Va rugam verificati Username & Password");
            }
        }
    }
}
