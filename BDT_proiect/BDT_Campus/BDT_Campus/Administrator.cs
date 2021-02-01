using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDT_Campus
{
    public partial class Administrator : Form
    {
        int ID = 0;
        public Administrator()
        {
            InitializeComponent();
        }
        public Administrator(string nume)
        {
            InitializeComponent();
            textBox_identitate.Text = nume;
            textBox_identitate.Enabled = false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("Select * FROM user_tables  WHERE table_name!='CONDUCERE' AND table_name!='CAMINE' AND table_name!='LOGIN' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox_tabele.Items.Add(dr["table_name"].ToString());
            }

            OleDbDataAdapter sda1 = new OleDbDataAdapter("SELECT c.nume_camin FROM camine c JOIN conducere co ON co.id_conducere = c.id_conducere  WHERE co.nume_administrator = '" + textBox_identitate.Text + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox_camin.Items.Add(dr["nume_camin"].ToString());
            }
            con.Close();
            groupBox_camere.Enabled = false;
            groupBox_studenti.Enabled = false;
            groupBox_date_studenti.Enabled = false;
            groupBox_dosare.Enabled = false;
            groupBox_registre.Enabled = false;
            textBox_nr_referate.Enabled = false;
            comboBox_status.Enabled = false;
            //incarcare tarif in combo, conform bazei de date
            comboBox_tarif.Items.Add("120");
            comboBox_tarif.Items.Add("130");
            comboBox_tarif.Items.Add("135");
            comboBox_tarif.Items.Add("150");
            comboBox_tarif.Items.Add("200");
            comboBox_tarif.Items.Add("270");
            //incarcare tip_camera in combo, conform bazei de date
            comboBox_tip_camera.Items.Add("Cvadubla");
            comboBox_tip_camera.Items.Add("Dubla");
            comboBox_tip_camera.Items.Add("Tripla");
            comboBox_tip_camera.Items.Add("Single");
            comboBox_tip_camera.Items.Add("Oficiu");
            comboBox_tip_camera.Items.Add("Garsoniera");
            //incarcare tip_baie in combo, conform bazei de date
            comboBox_tip_baie.Items.Add("Comuna");
            comboBox_tip_baie.Items.Add("Modul");
            comboBox_tip_baie.Items.Add("Proprie");
            //incarcare facultate in combo, conform bazei de date
            comboBox_facultate.Items.Add("Facultatea de Arhitectura");
            comboBox_facultate.Items.Add("Facultatea de Automatica si Calculatoare");
            comboBox_facultate.Items.Add("Facultatea de Constructii de Masini si Management Industrial");
            comboBox_facultate.Items.Add("Facultatea de Constructii si Instalatii");
            comboBox_facultate.Items.Add("Facultatea de Design Industrial si Managementul Afacerilor");
            comboBox_facultate.Items.Add("Facultatea de Electronica, Telecomunicatii si Tehnologia Informatiei");
            comboBox_facultate.Items.Add("Facultatea de Inginerie Chimica si Protectia Mediului");
            comboBox_facultate.Items.Add("Facultatea de Inginerie Electrica, Energetica si Informatica Aplicata");
            comboBox_facultate.Items.Add("Facultatea de Mecanica");
            comboBox_facultate.Items.Add("Facultatea de Stiinta si Ingineria Materialelor");
            //incarcare an_studiu in combo, conform bazei de date
            comboBox_an_studiu.Items.Add("I");
            comboBox_an_studiu.Items.Add("II");
            comboBox_an_studiu.Items.Add("III");
            comboBox_an_studiu.Items.Add("IV");
            comboBox_an_studiu.Items.Add("V");
            comboBox_an_studiu.Items.Add("VI");
            comboBox_an_studiu.Items.Add("Master I");
            comboBox_an_studiu.Items.Add("Master II");
            comboBox_an_studiu.Items.Add("Doctorat I");
            comboBox_an_studiu.Items.Add("Doctorat II");
            //incarcare status in combo, conform bazei de date
            comboBox_status.Items.Add("Cazat");
            comboBox_status.Items.Add("Decazat");
            //incarcare combobox_luna
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
            //incarcare combobox_cazati_decazati
            comboBox_cazati_decazati.Items.Add("Cazat");
            comboBox_cazati_decazati.Items.Add("Decazat");
        }

        void afisare_camere_libere()
        {
            OleDbConnection conexiune = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            /*OleDbDataAdapter camere_libere = new OleDbDataAdapter("WITH "
                                                                  + "nr_total AS("
                                                                           + "SELECT cam.id_camera, COUNT(d.id_student) as stud_total "
                                                                           + "FROM dosare d "
                                                                           + "JOIN studenti s on s.id_student = d.id_student "
                                                                           + "JOIN camere cam on s.id_camera = cam.id_camera "
                                                                           + "JOIN camine c on cam.id_camin = c.id_camin "
                                                                           + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBox_camin.Text + "' "
                                                                           + "group by cam.id_camera) "
                                                                  + "SELECT a.nr_camera, a.id_camera as CAMERA_LIBERA "
                                                                  + "FROM camere a, nr_total b "
                                                                  + "WHERE a.id_camera = b.id_camera AND a.nr_studenti > b.stud_total "
                                                                  + "order by b.stud_total ", conexiune);

            DataSet ds = new DataSet();
            ds.Tables.Add("dosare");
            ds.Tables.Add("studenti");
            ds.Tables.Add("camine");
            ds.Tables.Add("camere");
            ds.Tables.Add("nr_total");

            camere_libere.Fill(ds, "dosare");
            //camere_libere.Fill(ds, "studenti");
            //camere_libere.Fill(ds, "camine");
            //camere_libere.Fill(ds, "camere");
            //camere_libere.Fill(ds, "nr_total");

            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = "dosare";

            DataTable dt1 = new DataTable();
            camere_libere.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox_liber.Items.Add(dr["CAMERA_LIBERA"].ToString());
            }*/
            int id_camera = 0;
            int nr_studenti = 0;
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
                    /*DataSet ds = new DataSet();
                    ds.Tables.Add("camere");
                    stud_total.Fill(ds, "camere");
                    this.dataGridViewAdministrator.DataSource = ds;
                    this.dataGridViewAdministrator.DataMember = "camere";*/
                }

            }
            conexiune.Close();
        }
        private void button_adauga_Click(object sender, EventArgs e)
        {
            if(comboBox_camin.Text.ToString() != "")
            {
                if(comboBox_tabele.Text.ToString() != "")
                {
                    int flag = 0;
                    switch (comboBox_tabele.Text)
                    {
                        case "CAMERE":

                            try
                            {
                                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                OleDbCommand insert = new OleDbCommand(); //numarul de camere deja inserate in caminul x
                                insert.Connection = con;
                                con.Open();

                                int camere_total = 0;
                                int camere = 0;
                                int capacitate_camera = 0;
                                OleDbDataAdapter camere1 = new OleDbDataAdapter("SELECT nr_camere FROM camine  WHERE id_camin = (SELECT id_camin FROM camine  WHERE nume_camin = '" + comboBox_camin.Text + "')", con);
                                OleDbDataAdapter camere2 = new OleDbDataAdapter("SELECT count(id_camera) as NUMAR_CAMERE FROM camere  WHERE id_camin = (SELECT id_camin FROM camine  WHERE nume_camin = '" + comboBox_camin.Text + "') group by id_camin", con);
                                OleDbDataAdapter capacitate = new OleDbDataAdapter("SELECT capacitate_camere FROM camine WHERE nume_camin = '" + comboBox_camin.Text + "'", con);
                                DataTable dt1 = new DataTable();
                                DataTable dt2 = new DataTable();
                                DataTable dt3 = new DataTable();
                                camere1.Fill(dt1);
                                camere2.Fill(dt2);
                                capacitate.Fill(dt3);

                                foreach (DataRow dr in dt1.Rows)
                                {
                                    camere_total = Convert.ToInt32(dr["nr_camere"].ToString());

                                }
                                foreach (DataRow dr in dt2.Rows)
                                {
                                    camere = Convert.ToInt32(dr["numar_camere"].ToString());
                                }

                                foreach (DataRow dr in dt3.Rows)
                                {
                                    capacitate_camera = Convert.ToInt32(dr["capacitate_camere"].ToString());
                                }

                                if (camere < camere_total)
                                {
                                    if (Convert.ToInt32(textBox_nr_studenti.Text.ToString()) <= capacitate_camera)
                                    {
                                        insert.CommandText = "INSERT into camere (nr_camera, nr_studenti, tarif, tip_camera, tip_baie, id_camin)" +
                                                       "VALUES('"
                                                       + textBox_nr_camera.Text + "', "
                                                       + textBox_nr_studenti.Text + ", "
                                                       + comboBox_tarif.Text + ", '"
                                                       + comboBox_tip_camera.Text + "', '"
                                                       + comboBox_tip_baie.Text + "', "
                                                       + "(SELECT id_camin FROM camine  WHERE nume_camin = '" + comboBox_camin.Text + "')" +
                                                       ")";
                                        insert.ExecuteNonQuery();
                                        con.Close();
                                        MessageBox.Show("ACȚIUNE INCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                        AfisareEntitate_Camere();
                                    }
                                    else
                                    {
                                        MessageBox.Show("ERR! În căminul " + comboBox_camin.Text + " pot fi inserate doar camere \na caror număr de studenți este mai mic sau egal cu " + capacitate_camera + "!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ERR: Nu mai pot fi adăugate camere în acest cămin!");
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reintroduceți!");
                            }
                            break;

                        case "STUDENTI":
                            try
                            {
                                OleDbConnection con1 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                OleDbCommand insert = new OleDbCommand();
                                insert.Connection = con1;
                                con1.Open();
                                int studenti_maxim = 0;
                                int studenti_total = 0;
                                string decazare_maxim = "";

                                OleDbDataAdapter studenti1 = new OleDbDataAdapter("SELECT nr_studenti FROM camere "
                                                                                 + "WHERE id_camera = " + textBox_camera_studenti.Text
                                                                                 + " AND id_camin = (SELECT id_camin FROM camine  WHERE  nume_camin = '" + comboBox_camin.Text + "')", con1);
                                OleDbDataAdapter studenti2 = new OleDbDataAdapter("SELECT COUNT(d.id_student) AS NUMAR_STUDENTI "
                                                                                  + "FROM dosare d "
                                                                                  + "JOIN studenti s on s.id_student = d.id_student "
                                                                                  + "JOIN camere cam on s.id_camera = cam.id_camera "
                                                                                  + "JOIN camine c on cam.id_camin = c.id_camin "
                                                                                  + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBox_camin.Text
                                                                                  + "' AND cam.id_camera = " + textBox_camera_studenti.Text, con1);
                                OleDbDataAdapter maxim = new OleDbDataAdapter("SELECT MAX(data_decazare)AS MAXIM " +
                                                                            "FROM studenti s " +
                                                                            "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                                            "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                                            "WHERE cam.id_camera = "+ textBox_camera_studenti.Text + " AND c.nume_camin = '"+ comboBox_camin.Text + "'", con1);
                                DataTable dt3 = new DataTable();
                                DataTable dt4 = new DataTable();
                                DataTable dtdecazare = new DataTable();
                                studenti1.Fill(dt3);
                                studenti2.Fill(dt4);
                                maxim.Fill(dtdecazare);
                                foreach (DataRow dr in dt3.Rows)
                                {
                                    studenti_maxim = Convert.ToInt32(dr["nr_studenti"].ToString());

                                }
                                foreach (DataRow dr in dt4.Rows)
                                {
                                    studenti_total = Convert.ToInt32(dr["numar_studenti"].ToString());
                                }
                                foreach (DataRow dr in dtdecazare.Rows)
                                {
                                    if(dr["maxim"].ToString() == "")
                                    {
                                        decazare_maxim = "00/00/0000";
                                    }
                                    else
                                    {
                                        decazare_maxim = dr["maxim"].ToString();
                                    }
                                }
                                

                                string[] data_cazare = textBox_data_cazare.Text.Split('/');
                                string[] data_decazare = decazare_maxim.Split('/');
                                string[] an_data_decazare = data_decazare[2].Split(' ');
                                if (Convert.ToInt32(an_data_decazare[0].ToString()) < Convert.ToInt32(data_cazare[2].ToString()))
                                {
                                    flag = 1;
                                }
                                if (Convert.ToInt32(an_data_decazare[0].ToString()) == Convert.ToInt32(data_cazare[2].ToString()))
                                {
                                    if (Convert.ToInt32(data_decazare[0].ToString()) < Convert.ToInt32(data_cazare[0].ToString()))
                                    {
                                        flag = 1;
                                    }
                                    if (Convert.ToInt32(data_cazare[0].ToString()) == Convert.ToInt32(data_decazare[0].ToString()))
                                    {
                                        if (Convert.ToInt32(data_decazare[1].ToString()) <= Convert.ToInt32(data_cazare[1].ToString()))
                                        {
                                            flag = 1;
                                        }
                                    }
                                }
                                if(flag == 1)
                                {
                                    if (studenti_total < studenti_maxim)
                                    {
                                        //verific daca mai sunt locuri in acea camera
                                        insert.CommandText = "INSERT INTO Studenti (nume_student, facultate, an_studiu, nr_telefon, adresa_email, cont_banca, data_cazare, id_camera) "
                                                         + "VALUES('"
                                                         + textBox_nume_student.Text + "', '"
                                                         + comboBox_facultate.Text + "', '"
                                                         + comboBox_an_studiu.Text + "', '"
                                                         + textBox_nr_telefon.Text + "', '"
                                                         + textBox_adresa_email.Text + "', '"
                                                         + textBox_cont_bancar.Text + "', "
                                                         + "TO_DATE('" + textBox_data_cazare.Text + "', 'MM/DD/YYYY'), "
                                                         //+ "TO_DATE('" + aux.ToString() + "', 'MM/DD/YYYY'), "
                                                         + textBox_camera_studenti.Text
                                                         + ")";

                                        insert.ExecuteNonQuery();
                                        //adaugare registru si dosar pentru student
                                        OleDbCommand new_registru = new OleDbCommand("INSERT INTO registre (octombrie, noiembrie, decembrie, ianuarie, februarie, martie, aprilie, mai, iunie, iulie, id_student) " +
                                                                                     "VALUES(0,0,0,0,0,0,0,0,0,0,(SELECT id_student FROM studenti WHERE nume_student='" + textBox_nume_student.Text + "'))", con1);
                                        new_registru.ExecuteNonQuery();
                                        OleDbCommand new_dosar = new OleDbCommand("INSERT into dosare (nr_avertismente, nr_referate, status, id_student) " +
                                                                                  "VALUES(0, 0, 'Cazat', (SELECT id_student FROM studenti WHERE nume_student='" + textBox_nume_student.Text + "'))", con1);
                                        new_dosar.ExecuteNonQuery();

                                        MessageBox.Show("ACȚIUNE ÎNCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                        MessageBox.Show("NU UITAȚI SĂ INTRODUCEȚI ȘI DATELE STUDENTULUI " + textBox_nume_student.Text + "!");

                                        AfisareEntitate_Studenti();
                                        con1.Close();
                                    }
                                    else
                                    {
                                        comboBox_liber.Enabled = true;
                                        MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");

                                        afisare_camere_libere();
                                    }
                                }
                                else
                                {
                                    comboBox_liber.Enabled = true;
                                    MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");

                                    afisare_camere_libere();
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reîntroduceți!");
                            }
                            break;

                        case "DATE_STUDENTI":
                            try
                            {
                                OleDbConnection con3 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                OleDbCommand insert = new OleDbCommand();
                                insert.Connection = con3;

                                insert.CommandText = "insert into DATE_STUDENTI values('"
                                    + textBox_CNP.Text + "', '"
                                    + textBox_CI_serie.Text + "','"
                                    + textBox_CI_numar.Text + "','"
                                    + textBox_adresa.Text + "',"
                                    + textBox_nume_date_student.Text
                                    + ")";

                                con3.Open();
                                insert.ExecuteNonQuery();
                                con3.Close();
                                MessageBox.Show("ACȚIUNE ÎNCHEIATĂ CU SUCCES! \n Inserarea s-a realizat cu succes!");
                                AfisareEntitate_DateStudenti();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERR: Încercare de insert invalidă! Reintroduceți!");
                            }
                            break;


                        case "DOSARE":
                        case "REGISTRE":
                            MessageBox.Show("ERR! \n NU se poate realiza inserarea pentru aceste tipuri de entități! \n Inserarea în aceste entități este asigurată de Baza de Date \n Puteți selecta una din următoarele \n CAMERE\nSTUDENTI\nDATE_STUDENTI.");
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }
        void AfisareEntitate_Camere()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM camere WHERE id_camin = (SELECT id_camin FROM camine WHERE nume_camin = '" + comboBox_camin.Text + "')", con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
        }
        void AfisareEntitate_Studenti()
        {
            comboBox_liber.Enabled = false;
            comboBox_neachitat.Enabled = false;
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT s.id_student, s.id_camera, s.nume_student, s.facultate, s.an_studiu, s.nr_telefon, s.adresa_email, s.cont_banca, s.data_cazare, s.data_decazare, cam.nr_camera " +
                                                        "FROM studenti s " +
                                                        "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBox_camin.Text + "' " +
                                                        "ORDER BY cam.id_camera", con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
        }

        void AfisareEntitate_DateStudenti()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT d.id_student, s.nume_student, d.CNP, d.seria_CI, d.nr_CI, d.adresa_domiciliu " +
                                                        "FROM date_studenti d " +
                                                        "JOIN studenti s ON d.id_student = s.id_student " +
                                                        "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBox_camin.Text + "' " +
                                                        "ORDER BY cam.id_camera", con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
        }

        void AfisareEntitate_Dosare()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT d.id_student,s.nume_student, d.nr_avertismente, d.nr_referate, d.status " +
                                                        "FROM dosare d " +
                                                        "JOIN studenti s ON d.id_student = s.id_student " +
                                                        "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBox_camin.Text + "' " +
                                                        "ORDER BY cam.id_camera", con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
        }
        void AfisareEntitate_Registre()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            OleDbDataAdapter sda = new OleDbDataAdapter("SELECT r.id_student, s.nume_student, r.octombrie, r.noiembrie, r.noiembrie, r.decembrie, r.ianuarie, r.februarie, r.martie, r.aprilie, r.mai, r.iunie, r.iulie " +
                                                        "FROM registre r " +
                                                        "JOIN studenti s ON r.id_student = s.id_student " +
                                                        "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                        "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                        "WHERE c.nume_camin = '" + comboBox_camin.Text + "' " +
                                                        "ORDER BY cam.id_camera", con);
            DataSet ds = new DataSet();
            //string tabela = comboBoxTabele.Text;
            ds.Tables.Add(comboBox_tabele.Text);
            sda.Fill(ds, comboBox_tabele.Text);
            this.dataGridViewAdministrator.DataSource = ds;
            this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
        }
        private void button_afiseaza_Click(object sender, EventArgs e)
        {
            if (comboBox_camin.Text.ToString() != "")
            {
                if (comboBox_tabele.Text.ToString() != "")
                {
                    switch (comboBox_tabele.Text)
                    {
                        case "CAMERE":
                            groupBox_camere.Enabled = true;
                            groupBox_studenti.Enabled = false;
                            groupBox_date_studenti.Enabled = false;
                            groupBox_dosare.Enabled = false;
                            groupBox_registre.Enabled = false;
                            AfisareEntitate_Camere();
                            break;

                        case "STUDENTI":
                            groupBox_camere.Enabled = false;
                            groupBox_studenti.Enabled = true;
                            groupBox_date_studenti.Enabled = false;
                            groupBox_dosare.Enabled = false;
                            groupBox_registre.Enabled = false;
                            AfisareEntitate_Studenti();
                            break;

                        case "DATE_STUDENTI":
                            groupBox_camere.Enabled = false;
                            groupBox_studenti.Enabled = false;
                            groupBox_date_studenti.Enabled = true;
                            groupBox_dosare.Enabled = false;
                            groupBox_registre.Enabled = false;
                            AfisareEntitate_DateStudenti();
                            break;

                        case "DOSARE":
                            groupBox_camere.Enabled = false;
                            groupBox_studenti.Enabled = false;
                            groupBox_date_studenti.Enabled = false;
                            groupBox_dosare.Enabled = true;
                            groupBox_registre.Enabled = false;
                            AfisareEntitate_Dosare();
                            break;

                        case "REGISTRE":
                            groupBox_camere.Enabled = false;
                            groupBox_studenti.Enabled = false;
                            groupBox_date_studenti.Enabled = false;
                            groupBox_dosare.Enabled = false;
                            groupBox_registre.Enabled = true;
                            AfisareEntitate_Registre();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }

        }

        private void button_deconectare_Click(object sender, EventArgs e)
        {
            Log_bloc log = new Log_bloc();
            log.Show();
            this.Hide();
        }

        private void ClearData()
        {
            switch (comboBox_tabele.Text)
            {
                case "COMISIEADMITERE":
                case "CAMERE":
                    textBox_nr_camera.Text = "";
                    textBox_nr_studenti.Text = "";
                    comboBox_tarif.Text = "";
                    comboBox_tip_camera.Text = "";
                    comboBox_tip_baie.Text = "";
                    break;

                case "STUDENTI":
                    textBox_nume_student.Text = "";
                    comboBox_facultate.Text = "";
                    comboBox_an_studiu.Text = "";
                    textBox_nr_telefon.Text = "";
                    textBox_adresa_email.Text = "";
                    textBox_cont_bancar.Text = "";
                    textBox_data_cazare.Text = "";
                    textBox_camera_studenti.Text = "";
                    break;
                case "DATE_STUDENTI":
                    textBox_nume_date_student.Text = "";
                    textBox_CNP.Text = "";
                    textBox_CI_serie.Text = "";
                    textBox_CI_numar.Text = "";
                    textBox_adresa.Text = "";
                    break;
                case "DOSARE":
                    textBox_nume_dosare.Text = "";
                    textBox_nr_avertismente.Text = "";
                    textBox_nr_referate.Text = "";
                    comboBox_status.Text = "";
                    break;
                case "REGISTRE":
                    textBox_nume_registre.Text = "";
                    break;
            }
        }


        void Update_avertismente_referate()
        {
            OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
            con.Open();

            int nr_avertismente = 0;
            int nr_referate = 0;
            OleDbDataAdapter avertismente = new OleDbDataAdapter("SELECT nr_avertismente FROM dosare  WHERE id_student = " + textBox_nume_registre.Text, con);
            OleDbDataAdapter referate = new OleDbDataAdapter("SELECT nr_referate FROM dosare  WHERE id_student = " + textBox_nume_registre.Text, con);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            avertismente.Fill(dt1);
            referate.Fill(dt2);

            foreach (DataRow dr in dt1.Rows)
            {
                nr_avertismente = Convert.ToInt32(dr["nr_avertismente"].ToString());

            }
            foreach (DataRow dr in dt2.Rows)
            {
                nr_referate = Convert.ToInt32(dr["nr_referate"].ToString());
            }
            if (nr_avertismente < 3)
            {
                nr_avertismente++;
                OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE DOSARE set nr_avertismente= " + nr_avertismente +
                                                                    "  WHERE id_student = " + textBox_nume_registre.Text, con);
                UPDATE_avertismente.ExecuteNonQuery();
            }

            if (nr_avertismente == 3) //daca numarul de avertismente este egal cu 3
            {
                nr_referate++;
                //fac UPDATE la numarul de referate 
                OleDbCommand UPDATE_referate = new OleDbCommand("UPDATE DOSARE set nr_referate=" + nr_referate +
                                                                "  WHERE id_student = " + textBox_nume_registre.Text, con);
                UPDATE_referate.ExecuteNonQuery();

                OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE DOSARE set nr_avertismente= 0" +
                                                                "  WHERE id_student = " + textBox_nume_registre.Text, con);
                UPDATE_avertismente.ExecuteNonQuery();

                if (nr_referate == 3) //daca numarul de referate este egal cu 3
                {
                    //fac UPDATE la statusul studentului ca fiind decazat
                    OleDbCommand status = new OleDbCommand("UPDATE DOSARE set status= 'Decazat'" +
                                                           "  WHERE id_student = " + textBox_nume_registre.Text, con);
                    //fac UPDATE la data decazarii studentului
                    OleDbCommand decazare = new OleDbCommand("UPDATE STUDENTI set data_decazare = SYSDATE" +
                                                             "  WHERE id_student = " + textBox_nume_registre.Text, con);

                    status.ExecuteNonQuery();
                    decazare.ExecuteNonQuery();
                    textBox_nr_referate.Enabled = false;
                    textBox_nr_avertismente.Enabled = false;
                }

            }
            con.Close();
            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DOSARE s-a realizat cu succes!");
            AfisareEntitate_Dosare();

        }

        private void button_modifica_Click(object sender, EventArgs e)
        {
            if (comboBox_camin.Text.ToString() != "")
            {
                if (comboBox_tabele.Text.ToString() != "")
                {
                    if(ID != 0)
                    {
                        switch (comboBox_tabele.Text)
                        {
                            case "CAMERE":
                                groupBox_camere.Enabled = true;
                                groupBox_studenti.Enabled = false;
                                groupBox_date_studenti.Enabled = false;
                                groupBox_dosare.Enabled = false;
                                groupBox_registre.Enabled = false;

                                //fac UPDATE
                                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                OleDbCommand cmd = new OleDbCommand("UPDATE CAMERE set nr_studenti= " + textBox_nr_studenti.Text +
                                                                                   ", tarif= " + comboBox_tarif.Text +
                                                                                   ", tip_camera ='" + comboBox_tip_camera.Text +
                                                                                   "', tip_baie= '" + comboBox_tip_baie.Text +
                                                                                   "'  WHERE id_camin = (SELECT id_camin FROM camine  WHERE nume_camin= '" + comboBox_camin.Text +
                                                                                   "' AND id_camera = '" + ID + "')", con);
                                con.Open();
                                cmd.Parameters.AddWithValue("@ID_CAMERA", ID);

                                int capacitate_camera = 0; OleDbDataAdapter capacitate = new OleDbDataAdapter("SELECT capacitate_camere FROM camine WHERE nume_camin = '" + comboBox_camin.Text + "'", con);
                                DataTable dt = new DataTable();

                                capacitate.Fill(dt);

                                foreach (DataRow dr in dt.Rows)
                                {
                                    capacitate_camera = Convert.ToInt32(dr["capacitate_camere"].ToString());
                                }

                                if (Convert.ToInt32(textBox_nr_studenti.Text.ToString()) <= capacitate_camera)
                                {
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei CAMERE s-a realizat cu succes!");

                                    AfisareEntitate_Camere();
                                }
                                else
                                {
                                    MessageBox.Show("ERR! În căminul " + comboBox_camin.Text + " pot fi inserate doar camere \na caror număr de studenți este mai mic sau egal cu " + capacitate_camera + "!");
                                }


                                break;

                            case "STUDENTI":
                                groupBox_camere.Enabled = false;
                                groupBox_studenti.Enabled = true;
                                groupBox_date_studenti.Enabled = false;
                                groupBox_dosare.Enabled = false;
                                groupBox_registre.Enabled = false;
                                //fac UPDATE
                                try
                                {
                                    OleDbConnection con1 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                    con1.Open();
                                    OleDbCommand update = new OleDbCommand("UPDATE Studenti set nume_student = '" + textBox_nume_student.Text +
                                                                                             "', facultate = '" + comboBox_facultate.Text +
                                                                                             "', an_studiu = '" + comboBox_an_studiu.Text +
                                                                                             "', nr_telefon = '" + textBox_nr_telefon.Text +
                                                                                             "', adresa_email = '" + textBox_adresa_email.Text +
                                                                                             "', cont_banca = '" + textBox_cont_bancar.Text +
                                                                                             "', data_cazare = TO_DATE('" + textBox_data_cazare.Text + "', 'MM/DD/YYYY')" +
                                                                                             ", id_camera = " + textBox_camera_studenti.Text +
                                                                                             " WHERE id_student = " + ID, con1);
                                   
                                    update.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    
                                    int studenti_maxim = 0;
                                    int studenti_total = 0;

                                    OleDbDataAdapter studenti1 = new OleDbDataAdapter("SELECT nr_studenti FROM camere "
                                                                                     + "WHERE id_camera = " + textBox_camera_studenti.Text
                                                                                     + " AND id_camin = (SELECT id_camin FROM camine  WHERE  nume_camin = '" + comboBox_camin.Text + "')", con1);
                                    OleDbDataAdapter studenti2 = new OleDbDataAdapter("SELECT COUNT(d.id_student) AS NUMAR_STUDENTI "
                                                                                      + "FROM dosare d "
                                                                                      + "JOIN studenti s on s.id_student = d.id_student "
                                                                                      + "JOIN camere cam on s.id_camera = cam.id_camera "
                                                                                      + "JOIN camine c on cam.id_camin = c.id_camin "
                                                                                      + "WHERE d.status = 'Cazat' AND c.nume_camin = '" + comboBox_camin.Text
                                                                                      + "' AND cam.id_camera = " + textBox_camera_studenti.Text, con1);
                                    DataTable dt3 = new DataTable();
                                    DataTable dt4 = new DataTable();
                                    studenti1.Fill(dt3);
                                    studenti2.Fill(dt4);

                                    foreach (DataRow dr in dt3.Rows)
                                    {
                                        studenti_maxim = Convert.ToInt32(dr["nr_studenti"].ToString());

                                    }
                                    foreach (DataRow dr in dt4.Rows)
                                    {
                                        studenti_total = Convert.ToInt32(dr["numar_studenti"].ToString());
                                    }

                                    if (studenti_total < studenti_maxim)
                                    {
                                        
                                        update.ExecuteNonQuery();
                                        AfisareEntitate_Studenti();

                                    }
                                    else
                                    {
                                        comboBox_liber.Enabled = true;
                                        MessageBox.Show("ERR: Nu mai sunt locuri libere în această cameră! Reîncercați introducerea în una din camerele libere!");
                                        afisare_camere_libere();
                                    }
                                    con1.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("ERR: Încercare de modificare invalidă! Reintroduceți!");
                                }
                                break;

                            case "DATE_STUDENTI":
                                groupBox_camere.Enabled = false;
                                groupBox_studenti.Enabled = false;
                                groupBox_date_studenti.Enabled = true;
                                groupBox_dosare.Enabled = false;
                                groupBox_registre.Enabled = false;

                                //fac UPDATE
                                OleDbConnection con2 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                OleDbCommand cmd2 = new OleDbCommand("UPDATE DATE_STUDENTI set seria_CI='" + textBox_CI_serie.Text +
                                                                                       "', nr_CI='" + textBox_CI_numar.Text +
                                                                                       "', adresa_domiciliu ='" + textBox_adresa.Text +
                                                                                       "'  WHERE id_student = " + ID +
                                                                                       "AND CNP = '" + textBox_CNP.Text + "'", con2);
                                con2.Open();
                                cmd2.Parameters.AddWithValue("@ID_STUDENT", ID); //refera id_comisie
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DATE_STUDENTI s-a realizat cu succes!");
                                AfisareEntitate_DateStudenti();
                                break;

                            case "DOSARE":
                                groupBox_camere.Enabled = false;
                                groupBox_studenti.Enabled = false;
                                groupBox_date_studenti.Enabled = false;
                                groupBox_dosare.Enabled = true;
                                groupBox_registre.Enabled = false;

                                if (Convert.ToInt32(textBox_nr_avertismente.Text) <= 3)
                                {
                                    OleDbConnection con3 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                    con3.Open();

                                    //UPDATE nr_avertismente pentru student
                                    OleDbCommand UPDATE_dosar = new OleDbCommand("UPDATE DOSARE set nr_avertismente= " + textBox_nr_avertismente.Text +
                                                                                 "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                    UPDATE_dosar.ExecuteNonQuery();
                                    int nr_avertismente = 0;
                                    int nr_referate = 0;
                                    OleDbDataAdapter avertismente = new OleDbDataAdapter("SELECT nr_avertismente FROM dosare  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                    OleDbDataAdapter referate = new OleDbDataAdapter("SELECT nr_referate FROM dosare  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                    DataTable dt1 = new DataTable();
                                    DataTable dt2 = new DataTable();
                                    avertismente.Fill(dt1);
                                    referate.Fill(dt2);

                                    foreach (DataRow dr in dt1.Rows)
                                    {
                                        nr_avertismente = Convert.ToInt32(dr["nr_avertismente"].ToString());

                                    }
                                    foreach (DataRow dr in dt2.Rows)
                                    {
                                        nr_referate = Convert.ToInt32(dr["nr_referate"].ToString());
                                    }

                                    if (nr_avertismente == 3) //daca numarul de avertismente este egal cu 3
                                    {
                                        nr_referate++;
                                        //fac UPDATE la numarul de referate 
                                        OleDbCommand UPDATE_referate = new OleDbCommand("UPDATE DOSARE set nr_referate=" + nr_referate +
                                                                                        "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                        UPDATE_referate.ExecuteNonQuery();

                                        OleDbCommand UPDATE_avertismente = new OleDbCommand("UPDATE DOSARE set nr_avertismente= 0" +
                                                                                        "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                        UPDATE_avertismente.ExecuteNonQuery();

                                        if (nr_referate == 3) //daca numarul de referate este egal cu 3
                                        {
                                            //fac UPDATE la statusul studentului ca fiind decazat
                                            OleDbCommand status = new OleDbCommand("UPDATE DOSARE set status= 'Decazat'" +
                                                                                   "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                            //fac UPDATE la data decazarii studentului
                                            OleDbCommand decazare = new OleDbCommand("UPDATE STUDENTI set data_decazare = SYSDATE" +
                                                                                     "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                            textBox_nr_referate.Enabled = false;
                                            textBox_nr_avertismente.Enabled = false;
                                            //comboBox_status.Enabled = false;
                                            status.ExecuteNonQuery();
                                            decazare.ExecuteNonQuery();

                                        }

                                    }
                                    //update la status decazat/cazat
                                    if (textBox_decazare.Text.ToString() != "")
                                    {
                                            
                                            OleDbCommand status1 = new OleDbCommand("UPDATE DOSARE set status= 'Decazat'" +
                                                                                  "  WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                            //fac UPDATE la data decazarii studentului
                                            OleDbCommand decazare1 = new OleDbCommand("UPDATE STUDENTI set data_decazare = TO_DATE('" + textBox_decazare.Text + "', 'MM/DD/YYYY') " +
                                                                    "WHERE id_student = " + textBox_nume_dosare.Text, con3);
                                            status1.ExecuteNonQuery();
                                            decazare1.ExecuteNonQuery();
                                    }
                                    con3.Close();
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei DOSARE s-a realizat cu succes!");
                                    AfisareEntitate_Dosare();

                                }
                                else
                                {
                                    MessageBox.Show("Trebuie să introduceți o valoare mai mică sau egală cu 3 \n pentru numărul de avertismente!");
                                    groupBox_camere.Enabled = false;
                                    groupBox_studenti.Enabled = false;
                                    groupBox_date_studenti.Enabled = false;
                                    groupBox_dosare.Enabled = false;
                                    groupBox_registre.Enabled = false;
                                }
                                break;

                            case "REGISTRE":
                                groupBox_camere.Enabled = false;
                                groupBox_studenti.Enabled = false;
                                groupBox_date_studenti.Enabled = false;
                                groupBox_dosare.Enabled = false;
                                groupBox_registre.Enabled = true;
                                //fac UPDATE in functie de luna selectata
                                OleDbConnection con4 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                con4.Open();
                                switch (comboBox_luna.Text)
                                {
                                    case "octombrie":
                                        OleDbCommand octombrie = new OleDbCommand(" UPDATE registre set octombrie = 1 " +
                                                                                   " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        octombrie.ExecuteNonQuery();
                                        MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        break;
                                    case "noiembrie":
                                        int val_octombrie = 0;
                                        OleDbDataAdapter precedent_oct = new OleDbDataAdapter("SELECT octombrie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt1 = new DataTable();
                                        precedent_oct.Fill(dt1);
                                        foreach (DataRow dr in dt1.Rows)
                                        {
                                            val_octombrie = Convert.ToInt32(dr["octombrie"].ToString());

                                        }
                                        if (val_octombrie == 1)
                                        {
                                            OleDbCommand noiembrie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            noiembrie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "decembrie":
                                        int val_noiembrie = 0;
                                        OleDbDataAdapter precedent_noi = new OleDbDataAdapter("SELECT noiembrie FROM registre" +
                                                                                             " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt2 = new DataTable();
                                        precedent_noi.Fill(dt2);
                                        foreach (DataRow dr in dt2.Rows)
                                        {
                                            val_noiembrie = Convert.ToInt32(dr["noiembrie"].ToString());

                                        }
                                        if (val_noiembrie == 1)
                                        {
                                            OleDbCommand decembrie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            decembrie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "ianuarie":
                                        int val_decembrie = 0;
                                        OleDbDataAdapter precedent_dec = new OleDbDataAdapter("SELECT decembrie FROM registre" +
                                                                                              " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt3 = new DataTable();
                                        precedent_dec.Fill(dt3);
                                        foreach (DataRow dr in dt3.Rows)
                                        {
                                            val_decembrie = Convert.ToInt32(dr["decembrie"].ToString());

                                        }
                                        if (val_decembrie == 1)
                                        {
                                            OleDbCommand ianuarie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            ianuarie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "februarie":
                                        int val_ianuarie = 0;
                                        OleDbDataAdapter precedent_ian = new OleDbDataAdapter("SELECT ianuarie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt4 = new DataTable();
                                        precedent_ian.Fill(dt4);
                                        foreach (DataRow dr in dt4.Rows)
                                        {
                                            val_ianuarie = Convert.ToInt32(dr["ianuarie"].ToString());

                                        }
                                        if (val_ianuarie == 1)
                                        {
                                            OleDbCommand februarie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            februarie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "martie":
                                        int val_februarie = 0;
                                        OleDbDataAdapter precedent_feb = new OleDbDataAdapter("SELECT februarie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt5 = new DataTable();
                                        precedent_feb.Fill(dt5);
                                        foreach (DataRow dr in dt5.Rows)
                                        {
                                            val_februarie = Convert.ToInt32(dr["februarie"].ToString());

                                        }
                                        if (val_februarie == 1)
                                        {
                                            OleDbCommand martie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            martie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "aprilie":
                                        int val_martie = 0;
                                        OleDbDataAdapter precedent_mar = new OleDbDataAdapter("SELECT martie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt6 = new DataTable();
                                        precedent_mar.Fill(dt6);
                                        foreach (DataRow dr in dt6.Rows)
                                        {
                                            val_martie = Convert.ToInt32(dr["martie"].ToString());

                                        }
                                        if (val_martie == 1)
                                        {
                                            OleDbCommand aprilie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            aprilie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "mai":
                                        int val_aprilie = 0;
                                        OleDbDataAdapter precedent_apr = new OleDbDataAdapter("SELECT aprilie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt7 = new DataTable();
                                        precedent_apr.Fill(dt7);
                                        foreach (DataRow dr in dt7.Rows)
                                        {
                                            val_aprilie = Convert.ToInt32(dr["aprilie"].ToString());

                                        }
                                        if (val_aprilie == 1)
                                        {
                                            OleDbCommand mai = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            mai.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;

                                    case "iunie":
                                        int val_mai = 0;
                                        OleDbDataAdapter precedent_mai = new OleDbDataAdapter("SELECT mai FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt8 = new DataTable();
                                        precedent_mai.Fill(dt8);
                                        foreach (DataRow dr in dt8.Rows)
                                        {
                                            val_mai = Convert.ToInt32(dr["mai"].ToString());

                                        }
                                        if (val_mai == 1)
                                        {
                                            OleDbCommand iunie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            iunie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;
                                    case "iulie":
                                        int val_iunie = 0;
                                        OleDbDataAdapter precedent_iun = new OleDbDataAdapter("SELECT iunie FROM registre" +
                                                                                        " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                        DataTable dt9 = new DataTable();
                                        precedent_iun.Fill(dt9);
                                        foreach (DataRow dr in dt9.Rows)
                                        {
                                            val_octombrie = Convert.ToInt32(dr["iunie"].ToString());

                                        }
                                        if (val_iunie == 1)
                                        {
                                            OleDbCommand iulie = new OleDbCommand("UPDATE registre set " + comboBox_luna.Text + " = 1 " +
                                                                                      " WHERE id_student = " + textBox_nume_registre.Text, con4);
                                            iulie.ExecuteNonQuery();
                                            MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea tabelei REGISTRE s-a realizat cu succes!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Studentul nu are achitat tariful pentru luna precedentă! \n Nu puteți actualiza tariful pentru această lună!");
                                            Update_avertismente_referate();
                                        }
                                        break;
                                }

                                con4.Close();
                                MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Modificarea REGISTRE s-a realizat cu succes!");
                                AfisareEntitate_Registre();
                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Selectați un rând pentru modificare!");

                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }

        private void button_sterge_Click(object sender, EventArgs e)
        {
            if (comboBox_camin.Text.ToString() != "")
            {
                if (comboBox_tabele.Text.ToString() != "")
                {
                    if (MessageBox.Show("Doriți continuarea acestei operațiuni? \n ESTE POSIBILĂ PIERDEREA UNUI NUMĂR MARE DE DATE DIN BAZA DE DATE", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (ID != 0)
                        {
                            switch (comboBox_tabele.Text)
                            {
                                case "CAMERE":
                                    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                    con.Open();

                                    OleDbCommand sters_camera = new OleDbCommand("DELETE FROM CAMERE  WHERE id_camera= " + ID, con);
                                    sters_camera.Parameters.AddWithValue("@ID_CAMERA", ID);
                                    sters_camera.ExecuteNonQuery();
                                    con.Close();
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Ștergerea CAMEREI s-a realizat cu succes!");
                                    AfisareEntitate_Camere();
                                    ClearData(); //goleste campuri 
                                    break;

                                case "STUDENTI":
                                    OleDbConnection con1 = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                                    con1.Open();

                                    OleDbCommand sters_registru1 = new OleDbCommand("DELETE FROM REGISTRE  WHERE id_student = " + ID, con1);
                                    sters_registru1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_registru1.ExecuteNonQuery();

                                    OleDbCommand sters_dosar1 = new OleDbCommand("DELETE FROM DOSARE  WHERE id_student = " + ID, con1);
                                    sters_dosar1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_dosar1.ExecuteNonQuery();

                                    OleDbCommand sters_date_student1 = new OleDbCommand("DELETE FROM DATE_STUDENTI  WHERE id_student = " + ID, con1);
                                    sters_date_student1.Parameters.AddWithValue("@ID_STUDENT", ID);
                                    sters_date_student1.ExecuteNonQuery();

                                    OleDbCommand sters_student1 = new OleDbCommand("DELETE FROM STUDENTI  WHERE id_student = " + ID, con1);
                                    sters_student1.Parameters.AddWithValue("@ID_STUDENT", ID); //refera id_voluntar
                                    sters_student1.ExecuteNonQuery();

                                    con1.Close();
                                    MessageBox.Show("ACTIVITATE ÎNCHEIATĂ CU SUCCES! \n Ștergerea STUDENTULUI s-a realizat cu succes!");
                                    AfisareEntitate_Studenti();
                                    ClearData(); //goleste campuri 
                                    break;

                                case "DOSARE":
                                case "DATE_STUDENTI":
                                case "REGISTRE":
                                    MessageBox.Show("ERR! \n NU se poate realiza ștergerea pentru aceste tipuri de entități! \n Ștergerea din aceste entități este asigurată de Baza de Date \n Puteți selecta una din următoarele \n CAMERE\nSTUDENTI.");
                                    ClearData();
                                    break;

                            }
                        }
                        else
                        {
                            MessageBox.Show("ERR! \n Selectați un rând pentru ștergere!");
                            groupBox_camere.Enabled = false;
                            groupBox_studenti.Enabled = false;
                            groupBox_date_studenti.Enabled = false;
                            groupBox_dosare.Enabled = false;
                            groupBox_registre.Enabled = false;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Selectați tabela în care doriți să faceți operații!");
                }
            }
            else
            {
                MessageBox.Show("Selectați căminul în care doriți să faceți modificări!");
            }
        }

        private void button_curata_interfata_Click(object sender, EventArgs e)
        {
            textBox_nr_camera.Text = "";
            textBox_nr_studenti.Text = "";
            comboBox_tarif.Text = "";
            comboBox_tip_camera.Text = "";
            comboBox_tip_baie.Text = "";

            textBox_nume_student.Text = "";
            comboBox_facultate.Text = "";
            comboBox_an_studiu.Text = "";
            textBox_nr_telefon.Text = "";
            textBox_adresa_email.Text = "";
            textBox_cont_bancar.Text = "";
            textBox_data_cazare.Text = "";
            textBox_camera_studenti.Text = "";

            textBox_nume_date_student.Text = "";
            textBox_CNP.Text = "";
            textBox_CI_serie.Text = "";
            textBox_CI_numar.Text = "";
            textBox_adresa.Text = "";

            textBox_nume_dosare.Text = "";
            textBox_nr_avertismente.Text = "";
            textBox_nr_referate.Text = "";
            comboBox_status.Text = "";

            textBox_nume_registre.Text = "";
            comboBox_luna.Text = "";

            groupBox_camere.Enabled = false;
            groupBox_studenti.Enabled = false;
            groupBox_date_studenti.Enabled = false;
            groupBox_dosare.Enabled = false;
            groupBox_registre.Enabled = false;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewAdministrator_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAdministrator.Rows[e.RowIndex];
                switch (comboBox_tabele.Text)
                {
                    case "CAMERE":
                        textBox_nr_camera.Text = row.Cells["NR_CAMERA"].Value.ToString();
                        textBox_nr_studenti.Text = row.Cells["NR_STUDENTI"].Value.ToString();
                        comboBox_tarif.Text = row.Cells["TARIF"].Value.ToString();
                        comboBox_tip_camera.Text = row.Cells["TIP_CAMERA"].Value.ToString();
                        comboBox_tip_baie.Text = row.Cells["TIP_BAIE"].Value.ToString();
                        //ID = Convert.ToInt32(dataGridViewAdministrator.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ID = Convert.ToInt32(row.Cells["ID_CAMERA"].Value.ToString());
                        break;

                    case "STUDENTI":
                        textBox_nume_student.Text = row.Cells["NUME_STUDENT"].Value.ToString();
                        comboBox_facultate.Text = row.Cells["FACULTATE"].Value.ToString();
                        comboBox_an_studiu.Text = row.Cells["AN_STUDIU"].Value.ToString();
                        textBox_nr_telefon.Text = row.Cells["NR_TELEFON"].Value.ToString();
                        textBox_adresa_email.Text = row.Cells["ADRESA_EMAIL"].Value.ToString();
                        textBox_cont_bancar.Text = row.Cells["CONT_BANCA"].Value.ToString();
                        textBox_data_cazare.Text = row.Cells["DATA_CAZARE"].Value.ToString();
                        textBox_camera_studenti.Text = row.Cells["ID_CAMERA"].Value.ToString();
                        //ID = Convert.ToInt32(dataGridViewAdministrator.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;

                    case "DATE_STUDENTI":
                        textBox_nume_date_student.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        textBox_CNP.Text = row.Cells["CNP"].Value.ToString();
                        textBox_CI_serie.Text = row.Cells["SERIA_CI"].Value.ToString();
                        textBox_CI_numar.Text = row.Cells["NR_CI"].Value.ToString();
                        textBox_adresa.Text = row.Cells["ADRESA_DOMICILIU"].Value.ToString();
                        //ID = Convert.ToInt32(dataGridViewAdministrator.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;

                    case "DOSARE":
                        textBox_nume_dosare.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        textBox_nr_avertismente.Text = row.Cells["NR_AVERTISMENTE"].Value.ToString();
                        textBox_nr_referate.Text = row.Cells["NR_REFERATE"].Value.ToString();
                        comboBox_status.Text = row.Cells["STATUS"].Value.ToString();
                        //ID = Convert.ToInt32(dataGridViewAdministrator.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;
                    case "REGISTRE":
                        textBox_nume_registre.Text = row.Cells["ID_STUDENT"].Value.ToString();
                        //ID = Convert.ToInt32(dataGridViewAdministrator.Rows[e.RowIndex].Cells[0].Value.ToString());
                        ID = Convert.ToInt32(row.Cells["ID_STUDENT"].Value.ToString());
                        break;
                }
            }
        }

        private void button_restant_Click(object sender, EventArgs e)
        {
            if (comboBox_luna.Text.ToString() != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT stud.id_student, stud.nume_student, cam.nr_camera " +
                                                            "FROM studenti stud " +
                                                            "JOIN camere cam ON cam.id_camera = stud.id_camera " +
                                                            "JOIN camine c ON c.id_camin = cam.id_camin " +
                                                            "JOIN registre r ON r.id_student = stud.id_student " +
                                                            "JOIN dosare d ON d.id_student = stud.id_student " +
                                                            "WHERE d.status = 'Cazat' and c.nume_camin = '" + comboBox_camin.Text +
                                                            "' and r." + comboBox_luna.Text + "= 0 " +
                                                            "ORDER BY cam.nr_camera", con);
                DataSet ds = new DataSet();
                ds.Tables.Add(comboBox_tabele.Text);
                sda.Fill(ds, comboBox_tabele.Text);
                this.dataGridViewAdministrator.DataSource = ds;
                this.dataGridViewAdministrator.DataMember = comboBox_tabele.Text;
            }
            else
            {
                MessageBox.Show("ERR! \n Selectați o lună pentru afișare!");
            }
        }

        private void button_neachitat_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                comboBox_neachitat.Enabled = true;
                string[] luni_an = { "octombrie", "noiembrie", "decembrie", "ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie" };
                OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * FROM registre WHERE id_student = " + ID, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int idx = 0; idx < luni_an.Length; idx++)
                    {
                        if (Convert.ToInt32(dr[luni_an[idx]].ToString()) == 0)
                        {
                            comboBox_neachitat.Items.Add(luni_an[idx]);
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("ERR! \n Selectați un rând pentru afișare!");

            }
        }

        private void button_cazati_Click(object sender, EventArgs e)
        {
            if(ID != 0)
            {
                if (comboBox_cazati_decazati.Text.ToString() != "")
                {
                    OleDbConnection con = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=tema;Password=tema;Unicode=True");
                    OleDbDataAdapter sda = new OleDbDataAdapter("SELECT * " +
                                                                "FROM studenti s " +
                                                                "JOIN dosare d ON s.id_student = d.id_student " +
                                                                "JOIN camere cam ON s.id_camera = cam.id_camera " +
                                                                "JOIN camine c ON cam.id_camin = c.id_camin " +
                                                                "WHERE d.status = '"+ comboBox_cazati_decazati.Text +"' AND c.nume_camin = '" + comboBox_camin.Text + "' AND cam.id_camera = '" + ID + "' ", con);

                    DataSet ds = new DataSet();
                    ds.Tables.Add("studenti");
                    sda.Fill(ds, "studenti");
                    this.dataGridViewAdministrator.DataSource = ds;
                    this.dataGridViewAdministrator.DataMember = "studenti";
                }
                else
                {
                    MessageBox.Show("Selectați statusul studenților pe care doriți să ii vizionați!");
                }
            }
            else
            {
                MessageBox.Show("ERR! \n Selectați un rând pentru afișare!");

            }
        }

    }
}


//cazare student X pe data de 20 oct 2020
//cazare student Y pe data de 20 oct 2020
//decazare student Y pe data 14 ian 2021
//cazare student pe data de 14 ian 2021
//vreau sa modific data decazarii studentului Y ca fiind 15 ian 2021    
            //- sa nu ma lase pentru ca asta ar insemna ca pe 14 ian 2021 ar fi 3 studenti in acea camera

