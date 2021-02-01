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
    public partial class Manager : Form
    {
        int ID = 0;
        public Manager()
        {
            InitializeComponent();
        }
        public Manager(string name)
        {
            InitializeComponent(); 
            textBox_identitate.Text = name;
            textBox_identitate.Enabled = false;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda1 = new OleDbDataAdapter("Select * FROM user_tables  WHERE table_name != 'LOGIN' AND table_name != 'REGISTRE' AND table_name != 'DATE_STUDENTI' AND table_name != 'DOSARE'", con);
            DataTable dt1= new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox_tabele.Items.Add(dr["table_name"].ToString());
            }

            OleDbDataAdapter sda2 = new OleDbDataAdapter("Select nume_camin FROM camine order by id_camin", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            foreach (DataRow dr in dt2.Rows)
            {
                comboBox_camin.Items.Add(dr["nume_camin"].ToString());
            }
            con.Close();

            groupBox_camine.Enabled = false;
            groupBox_conducere.Enabled = false;

            //incarcare combobox luna
            comboBox_luna.Items.Add("octombrie");
            comboBox_luna.Items.Add("noiembrie");
            comboBox_luna.Items.Add("decembrie");
            comboBox_luna.Items.Add("ianuarie");
            comboBox_luna.Items.Add("februarie");
            comboBox_luna.Items.Add("martie");
            comboBox_luna.Items.Add("aprilie");
            comboBox_luna.Items.Add("mai");
            comboBox_luna.Items.Add("iunie");
            comboBox_luna.Items.Add("iulie");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewManager.Rows[e.RowIndex];
                switch (comboBox_tabele.Text)
                {
                    case "CONDUCERE":
                        textBox_admin.Text = row.Cells["NUME_ADMINISTRATOR"].Value.ToString();
                        textBox_prodecan.Text = row.Cells["NUME_PRODECAN"].Value.ToString();
                        textBox_presedinte.Text = row.Cells["NUME_PRESEDINTE"].Value.ToString();
                        ID = Convert.ToInt32(row.Cells["ID_CONDUCERE"].Value.ToString());
                        break;
                }
            }
        }
        void AfisareEntitate()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM  " + comboBox_tabele.Text, con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewManager.DataSource = ds;
            this.dataGridViewManager.DataMember = comboBox_tabele.Text;
        }

        private void button_afiseaza_Click(object sender, EventArgs e)
        {
            switch(comboBox_tabele.Text)
            {
                case "CAMERE":
                    groupBox_camine.Enabled = false;
                    groupBox_conducere.Enabled = false;
                    AfisareEntitate();
                    break;
                case "CAMINE":
                    groupBox_camine.Enabled = true;
                    groupBox_conducere.Enabled = false;
                    comboBox_liber.Enabled = false;
                    AfisareEntitate();
                    break;
                case "CONDUCERE":
                    groupBox_camine.Enabled = false;
                    groupBox_conducere.Enabled = true;
                    AfisareEntitate();
                    break;
                case "STUDENTI":
                    groupBox_camine.Enabled = false;
                    groupBox_conducere.Enabled = false;
                    AfisareEntitate();
                    break;

            }
        }
        private void ClearData()
        {
            textBox_admin.Text = "";
            textBox_prodecan.Text = "";
            textBox_presedinte.Text = "";

        }

        private void button_sterge_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți continuarea acestei operațiuni? \n ESTE POSIBILĂ PIERDEREA UNUI NUMĂR MARE DE DATE DIN BAZA DE DATE", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ID != 0)
                {
                    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                    con.Open();
                    //verific daca administratorul are mai multe camine in subordonare
                    //daca are unul singur, atunci sterg contul sau de administrator
                    int nr_camine = 0;
                    OleDbDataAdapter sda = new OleDbDataAdapter("SELECT COUNT(a.id_camin) AS NR_CAMINE " +
                                                                "FROM camine a " +
                                                                "JOIN conducere b ON a.id_conducere = b.id_conducere " +
                                                                "WHERE b.nume_administrator = '" + textBox_admin.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        nr_camine = Convert.ToInt32(dr["NR_CAMINE"]);
                    }

                    if (nr_camine == 1)
                    {
                        OleDbCommand sters_cont = new OleDbCommand("DELETE FROM login where user_tip = '" + textBox_admin.Text + "'", con);
                        sters_cont.ExecuteNonQuery();
                        MessageBox.Show("S-a șters contul administratorului din baza de date!");
                    }

                    OleDbCommand sters_conducere = new OleDbCommand("DELETE FROM CONDUCERE WHERE id_conducere = " + ID, con);
                    sters_conducere.Parameters.AddWithValue("@ID_CONDUCERE", ID);
                    sters_conducere.ExecuteNonQuery();
                    MessageBox.Show("ACTIVITATE INCHEIATĂ CU SUCCES! \n Ștergerea CONDUCERII s-a realizat cu succes!");
                    AfisareEntitate();
                    con.Close();
                    
                }
                else
                {
                    MessageBox.Show("ERR! \n Selectați un rând pentru ștergere!");
                    groupBox_camine.Enabled = false;
                    groupBox_conducere.Enabled = false;
                }
            }
            
        }

        private void button_modifica_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbCommand cmd = new OleDbCommand("UPDATE CONDUCERE set nume_prodecan ='" + textBox_prodecan.Text +
                                                               "', nume_administrator = '" + textBox_admin.Text +
                                                               "', nume_presedinte = '" + textBox_presedinte.Text +
                                                               "'  WHERE id_conducere = " + ID , con);

            con.Open();
            cmd.Parameters.AddWithValue("@ID_CONDUCERE", ID);
            cmd.ExecuteNonQuery();
            //creare cont de administrator in cazul in care nu are
            Creare_cont(textBox_admin.Text.ToString());

            con.Close();
            MessageBox.Show("ACTIVITATE INCHEIATĂ CU SUCCES! \n Modificarea tabelei CONDUCERE s-a realizat cu succes!");
            AfisareEntitate();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_deconectare_Click(object sender, EventArgs e)
        {
            Log_bloc log = new Log_bloc();
            log.Show();
            this.Hide();
        }

        private void button_adauga_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO conducere (nume_prodecan,nume_administrator,nume_presedinte) " +
                                                "VALUES('" 
                                                + textBox_prodecan.Text +"', '" 
                                                + textBox_admin.Text + "', '" 
                                                + textBox_presedinte.Text + "')", con);
            
            cmd.ExecuteNonQuery();
            //creare cont administrator in cazul in care nu are
            Creare_cont(textBox_admin.Text.ToString());

            con.Close();
            MessageBox.Show("ACTIVITATE INCHEIATĂ CU SUCCES! \n Inserarea în tabela CONDUCERE s-a realizat cu succes!");

            AfisareEntitate();
        }

        private void button_afisare_bani_Click(object sender, EventArgs e)
        {
            if(comboBox_camin.Text.ToString() != "")
            {
                if (comboBox_luna.Text.ToString() != "")
                {
                    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                    OleDbDataAdapter sda = new OleDbDataAdapter("SELECT sum(cam.tarif) AS suma_incasata " +
                                                                "FROM registre r " +
                                                                "JOIN studenti s ON r.id_student = s.id_student " +
                                                                "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                                "JOIN camine c ON c.id_camin = cam.id_camin " +
                                                                "WHERE c.nume_camin = '" + comboBox_camin.Text + "' AND r." + comboBox_luna.Text + " = 1 ", con);
                    DataSet ds = new DataSet();
                    ds.Tables.Add(comboBox_tabele.Text);
                    sda.Fill(ds, comboBox_tabele.Text);
                    this.dataGridViewManager.DataSource = ds;
                    this.dataGridViewManager.DataMember = comboBox_tabele.Text;
                }
                else
                {
                    MessageBox.Show("Selectați luna pentru care doriți să se efectueze calculele!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        }

        int id_camera = 0;
        int nr_studenti = 0;
        private void button_afisare_camere_Click(object sender, EventArgs e)
        {
            if(comboBox_camin.Text.ToString() != "")
            {
                comboBox_liber.Enabled = true;
                OleDbConnection conexiune = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                int stud_maxim = 0;
                OleDbDataAdapter stud_total = new OleDbDataAdapter("SELECT cam.id_camera, COUNT(d.id_student) as STUDENTI_CAZATI "
                                                                               + "FROM dosare d "
                                                                               + "JOIN studenti s on s.id_student = d.id_student "
                                                                               + "JOIN camere cam on s.id_camera = cam.id_camera "
                                                                               + "JOIN camine c on cam.id_camin = c.id_camin "
                                                                               + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBox_camin.Text + "' "
                                                                               + "group by cam.id_camera ", conexiune);
                DataTable dt5 = new DataTable();
                stud_total.Fill(dt5);

                foreach (DataRow dr in dt5.Rows)
                {
                    id_camera = Convert.ToInt32(dr["ID_CAMERA"].ToString());
                    nr_studenti = Convert.ToInt32(dr["STUDENTI_CAZATI"].ToString());
                    OleDbDataAdapter camere_libere = new OleDbDataAdapter("SELECT a.nr_camera, a.id_camera as CAMERA_LIBERA "
                                                                      + "FROM camere a, nr_total b "
                                                                      + "WHERE a.id_camera = b.id_camera AND a.nr_studenti > b.stud_total "
                                                                      + "order by b.stud_total ", conexiune);
                    OleDbDataAdapter stud_numar = new OleDbDataAdapter("SELECT nr_studenti, nr_camera FROM camere "
                                                                     + "WHERE id_camera = " + id_camera
                                                                     + " AND id_camin = (SELECT id_camin FROM camine  WHERE  nume_camin = '" + comboBox_camin.Text + "')", conexiune);

                    DataTable dt6 = new DataTable();
                    stud_numar.Fill(dt6);
                    foreach (DataRow dr1 in dt6.Rows)
                    {
                        stud_maxim = Convert.ToInt32(dr1["nr_studenti"].ToString());
                    }

                    if (nr_studenti < stud_maxim)
                    {
                        comboBox_liber.Items.Add(id_camera);
                    }

                }
                conexiune.Close();
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        
    }

        private void button_detalii_Click(object sender, EventArgs e)
        {
            if(comboBox_liber.Text.ToString() != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM camere WHERE id_camera = " + comboBox_liber.Text, con);
                DataSet ds = new DataSet();
                //string tabela = comboBoxTabele.Text;
                ds.Tables.Add(comboBox_tabele.Text);
                sda.Fill(ds, comboBox_tabele.Text);
                this.dataGridViewManager.DataSource = ds;
                this.dataGridViewManager.DataMember = comboBox_tabele.Text;
            }
            else
            {
                MessageBox.Show("Selectați camera pentru care doriți să vizionați detaliile!");
            }
        }

        private void button_afiseaza_studenti_Click(object sender, EventArgs e)
        {
            if(comboBox_camin.Text.ToString() != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT s.id_student, s.nume_student, s.facultate, s.an_studiu, cam.nr_camera " +
                                                            "FROM studenti s " +
                                                            "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                            "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                            "WHERE c.nume_camin = '" + comboBox_camin.Text + "' " +
                                                            "ORDER BY cam.nr_camera", con);
                DataSet ds = new DataSet();
                ds.Tables.Add(comboBox_tabele.Text);
                sda.Fill(ds, comboBox_tabele.Text);
                this.dataGridViewManager.DataSource = ds;
                this.dataGridViewManager.DataMember = comboBox_tabele.Text;
            }
            else
            {
                MessageBox.Show("Selectați căminul pentru care doriți să vizionați date!");
            }
        }

        void Creare_cont(string admin)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            con.Open();
            
            string verif = "";
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * " +
                                                        "FROM login " +
                                                        "WHERE user_tip = '" + textBox_admin.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                verif = dr["user_tip"].ToString();
            }
            
            if (verif == "")
            {
                OleDbCommand cont = new OleDbCommand("INSERT INTO login (user_tip,pass,rol)  " +
                                                     "VALUES ('" + admin + "', 'administratie','administrator')", con);
                cont.ExecuteNonQuery();
                MessageBox.Show("S-a creat un cont pentru acest administrator!");
            }
            con.Close();
        }

        private void button_curata_interfata_Click(object sender, EventArgs e)
        {
            ClearData();
        }
    }
}
