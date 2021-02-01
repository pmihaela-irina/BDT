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
    public partial class Log_verif : Form
    {
        public Log_verif()
        {
            InitializeComponent();
        }

        public Log_verif(int rol, string nume)
        {
            InitializeComponent();
            textBox_identitate.Text = nume;
            textBox_identitate.Enabled = false;

            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT DISTINCT rol FROM login ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox_rol.Items.Add(dr["rol"].ToString());
            }
            con.Close();
        }


        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_confirmare_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            string name = textBox_identitate.Text;
            OleDbConnection con1 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT rol FROM login  WHERE user_tip ='"+ name +"'", con1);
            DataTable dt1 = new DataTable();
            
            sda1.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                string functieValida;
                foreach (DataRow dr in dt1.Rows)
                {
                    functieValida = dr["rol"].ToString();
                    if (comboBox_rol.Text == functieValida)
                    {
                        Flag = 1;
                    }
                }
                if (Flag == 1)
                {
                    switch (comboBox_rol.Text)
                    {
                        case "administrator":
                            this.Hide();
                            //this.Close();
                            Administrator admin = new Administrator(textBox_identitate.Text);
                            admin.Show();
                            
                            break;
                        case "manager":
                            this.Hide();
                            Manager manager = new Manager(textBox_identitate.Text);
                            manager.Show();
                            //this.Close();
                            break;
                      
                    }
                }
                else
                {
                    MessageBox.Show("ERR: Funcția introdusă nu corespunde cu atribuțiile dumneavoastră în cadrul campusului TUIASI! Reintroduceți!");
                }
            }
            else
            {
                MessageBox.Show("ERR: Funcția introdusă nu corespunde cu atribuțiile dumneavoastră în cadrul campusului TUIASI! Reintroduceți!");
            }
        }

        private void button_refuz_Click(object sender, EventArgs e)
        {
            Log_bloc intf = new Log_bloc();
            intf.Show();
            this.Close();
        }
    }
}
