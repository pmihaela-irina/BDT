
namespace BDT_Campus
{
    partial class Manager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewManager = new System.Windows.Forms.DataGridView();
            this.button_deconectare = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_identitate = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.comboBox_luna = new System.Windows.Forms.ComboBox();
            this.textBox_presedinte = new System.Windows.Forms.TextBox();
            this.textBox_admin = new System.Windows.Forms.TextBox();
            this.textBox_prodecan = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button_sterge = new System.Windows.Forms.Button();
            this.button_modifica = new System.Windows.Forms.Button();
            this.button_afiseaza_studenti = new System.Windows.Forms.Button();
            this.button_afisare_camere = new System.Windows.Forms.Button();
            this.button_afisare_bani = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_afiseaza = new System.Windows.Forms.Button();
            this.comboBox_camin = new System.Windows.Forms.ComboBox();
            this.comboBox_tabele = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_liber = new System.Windows.Forms.ComboBox();
            this.button_detalii = new System.Windows.Forms.Button();
            this.groupBox_camine = new System.Windows.Forms.GroupBox();
            this.groupBox_conducere = new System.Windows.Forms.GroupBox();
            this.button_adauga = new System.Windows.Forms.Button();
            this.button_curata_interfata = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).BeginInit();
            this.groupBox_camine.SuspendLayout();
            this.groupBox_conducere.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Interfața Manager";
            // 
            // dataGridViewManager
            // 
            this.dataGridViewManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManager.Location = new System.Drawing.Point(11, 363);
            this.dataGridViewManager.Name = "dataGridViewManager";
            this.dataGridViewManager.Size = new System.Drawing.Size(1015, 222);
            this.dataGridViewManager.TabIndex = 3;
            this.dataGridViewManager.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_deconectare
            // 
            this.button_deconectare.Location = new System.Drawing.Point(12, 9);
            this.button_deconectare.Margin = new System.Windows.Forms.Padding(2);
            this.button_deconectare.Name = "button_deconectare";
            this.button_deconectare.Size = new System.Drawing.Size(90, 20);
            this.button_deconectare.TabIndex = 93;
            this.button_deconectare.Text = "Deconectare";
            this.button_deconectare.UseVisualStyleBackColor = true;
            this.button_deconectare.Click += new System.EventHandler(this.button_deconectare_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(106, 9);
            this.button_exit.Margin = new System.Windows.Forms.Padding(2);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(91, 20);
            this.button_exit.TabIndex = 21;
            this.button_exit.Text = "Ieșire";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_identitate
            // 
            this.textBox_identitate.Location = new System.Drawing.Point(791, 10);
            this.textBox_identitate.Name = "textBox_identitate";
            this.textBox_identitate.Size = new System.Drawing.Size(235, 20);
            this.textBox_identitate.TabIndex = 106;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(651, 12);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(134, 18);
            this.label45.TabIndex = 105;
            this.label45.Text = "Sunteți conectat ca";
            // 
            // comboBox_luna
            // 
            this.comboBox_luna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_luna.FormattingEnabled = true;
            this.comboBox_luna.Location = new System.Drawing.Point(237, 74);
            this.comboBox_luna.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_luna.Name = "comboBox_luna";
            this.comboBox_luna.Size = new System.Drawing.Size(126, 21);
            this.comboBox_luna.TabIndex = 125;
            // 
            // textBox_presedinte
            // 
            this.textBox_presedinte.Location = new System.Drawing.Point(199, 104);
            this.textBox_presedinte.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_presedinte.Name = "textBox_presedinte";
            this.textBox_presedinte.Size = new System.Drawing.Size(116, 20);
            this.textBox_presedinte.TabIndex = 124;
            // 
            // textBox_admin
            // 
            this.textBox_admin.Location = new System.Drawing.Point(199, 79);
            this.textBox_admin.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_admin.Name = "textBox_admin";
            this.textBox_admin.Size = new System.Drawing.Size(116, 20);
            this.textBox_admin.TabIndex = 123;
            // 
            // textBox_prodecan
            // 
            this.textBox_prodecan.Location = new System.Drawing.Point(199, 56);
            this.textBox_prodecan.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_prodecan.Name = "textBox_prodecan";
            this.textBox_prodecan.Size = new System.Drawing.Size(116, 20);
            this.textBox_prodecan.TabIndex = 122;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(45, 107);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(142, 13);
            this.label18.TabIndex = 121;
            this.label18.Text = "Nume și prenume Președinte";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(43, 82);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 13);
            this.label19.TabIndex = 120;
            this.label19.Text = "Nume și prenume Administrator";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(43, 59);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(138, 13);
            this.label20.TabIndex = 118;
            this.label20.Text = "Nume și prenume Prodecan";
            // 
            // button_sterge
            // 
            this.button_sterge.Location = new System.Drawing.Point(339, 146);
            this.button_sterge.Margin = new System.Windows.Forms.Padding(2);
            this.button_sterge.Name = "button_sterge";
            this.button_sterge.Size = new System.Drawing.Size(107, 41);
            this.button_sterge.TabIndex = 117;
            this.button_sterge.Text = "Șterge";
            this.button_sterge.UseVisualStyleBackColor = true;
            this.button_sterge.Click += new System.EventHandler(this.button_sterge_Click);
            // 
            // button_modifica
            // 
            this.button_modifica.Location = new System.Drawing.Point(194, 146);
            this.button_modifica.Margin = new System.Windows.Forms.Padding(2);
            this.button_modifica.Name = "button_modifica";
            this.button_modifica.Size = new System.Drawing.Size(107, 41);
            this.button_modifica.TabIndex = 119;
            this.button_modifica.Text = "Modifică";
            this.button_modifica.UseVisualStyleBackColor = true;
            this.button_modifica.Click += new System.EventHandler(this.button_modifica_Click);
            // 
            // button_afiseaza_studenti
            // 
            this.button_afiseaza_studenti.Location = new System.Drawing.Point(5, 128);
            this.button_afiseaza_studenti.Margin = new System.Windows.Forms.Padding(2);
            this.button_afiseaza_studenti.Name = "button_afiseaza_studenti";
            this.button_afiseaza_studenti.Size = new System.Drawing.Size(221, 43);
            this.button_afiseaza_studenti.TabIndex = 116;
            this.button_afiseaza_studenti.Text = "Afișare studenți cazați ordonați după camere";
            this.button_afiseaza_studenti.UseVisualStyleBackColor = true;
            this.button_afiseaza_studenti.Click += new System.EventHandler(this.button_afiseaza_studenti_Click);
            // 
            // button_afisare_camere
            // 
            this.button_afisare_camere.Location = new System.Drawing.Point(5, 101);
            this.button_afisare_camere.Margin = new System.Windows.Forms.Padding(2);
            this.button_afisare_camere.Name = "button_afisare_camere";
            this.button_afisare_camere.Size = new System.Drawing.Size(221, 23);
            this.button_afisare_camere.TabIndex = 115;
            this.button_afisare_camere.Text = "Afișare camere libere";
            this.button_afisare_camere.UseVisualStyleBackColor = true;
            this.button_afisare_camere.Click += new System.EventHandler(this.button_afisare_camere_Click);
            // 
            // button_afisare_bani
            // 
            this.button_afisare_bani.Location = new System.Drawing.Point(5, 74);
            this.button_afisare_bani.Margin = new System.Windows.Forms.Padding(2);
            this.button_afisare_bani.Name = "button_afisare_bani";
            this.button_afisare_bani.Size = new System.Drawing.Size(221, 23);
            this.button_afisare_bani.TabIndex = 114;
            this.button_afisare_bani.Text = "Afișare suma totală încasată pe luna";
            this.button_afisare_bani.UseVisualStyleBackColor = true;
            this.button_afisare_bani.Click += new System.EventHandler(this.button_afisare_bani_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 17);
            this.label7.TabIndex = 113;
            this.label7.Text = "Modificare date conducere  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(2, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 13);
            this.label2.TabIndex = 111;
            this.label2.Text = "Selectați căminul în care doriți să vizionați date";
            // 
            // button_afiseaza
            // 
            this.button_afiseaza.Location = new System.Drawing.Point(252, 122);
            this.button_afiseaza.Margin = new System.Windows.Forms.Padding(2);
            this.button_afiseaza.Name = "button_afiseaza";
            this.button_afiseaza.Size = new System.Drawing.Size(97, 24);
            this.button_afiseaza.TabIndex = 109;
            this.button_afiseaza.Text = "Afișează";
            this.button_afiseaza.UseVisualStyleBackColor = true;
            this.button_afiseaza.Click += new System.EventHandler(this.button_afiseaza_Click);
            // 
            // comboBox_camin
            // 
            this.comboBox_camin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_camin.FormattingEnabled = true;
            this.comboBox_camin.Location = new System.Drawing.Point(5, 34);
            this.comboBox_camin.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_camin.Name = "comboBox_camin";
            this.comboBox_camin.Size = new System.Drawing.Size(227, 21);
            this.comboBox_camin.TabIndex = 112;
            // 
            // comboBox_tabele
            // 
            this.comboBox_tabele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tabele.FormattingEnabled = true;
            this.comboBox_tabele.Location = new System.Drawing.Point(12, 125);
            this.comboBox_tabele.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_tabele.Name = "comboBox_tabele";
            this.comboBox_tabele.Size = new System.Drawing.Size(227, 21);
            this.comboBox_tabele.TabIndex = 108;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Selectați tabela pe care doriți să o vizionați";
            // 
            // comboBox_liber
            // 
            this.comboBox_liber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_liber.FormattingEnabled = true;
            this.comboBox_liber.Location = new System.Drawing.Point(237, 103);
            this.comboBox_liber.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_liber.Name = "comboBox_liber";
            this.comboBox_liber.Size = new System.Drawing.Size(126, 21);
            this.comboBox_liber.TabIndex = 126;
            // 
            // button_detalii
            // 
            this.button_detalii.Location = new System.Drawing.Point(376, 103);
            this.button_detalii.Margin = new System.Windows.Forms.Padding(2);
            this.button_detalii.Name = "button_detalii";
            this.button_detalii.Size = new System.Drawing.Size(124, 23);
            this.button_detalii.TabIndex = 127;
            this.button_detalii.Text = "Afișare detalii cameră";
            this.button_detalii.UseVisualStyleBackColor = true;
            this.button_detalii.Click += new System.EventHandler(this.button_detalii_Click);
            // 
            // groupBox_camine
            // 
            this.groupBox_camine.Controls.Add(this.button_detalii);
            this.groupBox_camine.Controls.Add(this.comboBox_liber);
            this.groupBox_camine.Controls.Add(this.label2);
            this.groupBox_camine.Controls.Add(this.comboBox_luna);
            this.groupBox_camine.Controls.Add(this.comboBox_camin);
            this.groupBox_camine.Controls.Add(this.button_afiseaza_studenti);
            this.groupBox_camine.Controls.Add(this.button_afisare_camere);
            this.groupBox_camine.Controls.Add(this.button_afisare_bani);
            this.groupBox_camine.Location = new System.Drawing.Point(11, 151);
            this.groupBox_camine.Name = "groupBox_camine";
            this.groupBox_camine.Size = new System.Drawing.Size(518, 176);
            this.groupBox_camine.TabIndex = 128;
            this.groupBox_camine.TabStop = false;
            // 
            // groupBox_conducere
            // 
            this.groupBox_conducere.Controls.Add(this.button_curata_interfata);
            this.groupBox_conducere.Controls.Add(this.button_adauga);
            this.groupBox_conducere.Controls.Add(this.textBox_presedinte);
            this.groupBox_conducere.Controls.Add(this.textBox_admin);
            this.groupBox_conducere.Controls.Add(this.textBox_prodecan);
            this.groupBox_conducere.Controls.Add(this.label18);
            this.groupBox_conducere.Controls.Add(this.label19);
            this.groupBox_conducere.Controls.Add(this.label20);
            this.groupBox_conducere.Controls.Add(this.button_sterge);
            this.groupBox_conducere.Controls.Add(this.button_modifica);
            this.groupBox_conducere.Controls.Add(this.label7);
            this.groupBox_conducere.Location = new System.Drawing.Point(544, 105);
            this.groupBox_conducere.Name = "groupBox_conducere";
            this.groupBox_conducere.Size = new System.Drawing.Size(482, 222);
            this.groupBox_conducere.TabIndex = 129;
            this.groupBox_conducere.TabStop = false;
            // 
            // button_adauga
            // 
            this.button_adauga.Location = new System.Drawing.Point(48, 146);
            this.button_adauga.Margin = new System.Windows.Forms.Padding(2);
            this.button_adauga.Name = "button_adauga";
            this.button_adauga.Size = new System.Drawing.Size(107, 41);
            this.button_adauga.TabIndex = 125;
            this.button_adauga.Text = "Adaugă";
            this.button_adauga.UseVisualStyleBackColor = true;
            this.button_adauga.Click += new System.EventHandler(this.button_adauga_Click);
            // 
            // button_curata_interfata
            // 
            this.button_curata_interfata.Location = new System.Drawing.Point(339, 62);
            this.button_curata_interfata.Margin = new System.Windows.Forms.Padding(2);
            this.button_curata_interfata.Name = "button_curata_interfata";
            this.button_curata_interfata.Size = new System.Drawing.Size(107, 41);
            this.button_curata_interfata.TabIndex = 126;
            this.button_curata_interfata.Text = "Curăță înterfața";
            this.button_curata_interfata.UseVisualStyleBackColor = true;
            this.button_curata_interfata.Click += new System.EventHandler(this.button_curata_interfata_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 597);
            this.Controls.Add(this.groupBox_conducere);
            this.Controls.Add(this.groupBox_camine);
            this.Controls.Add(this.button_afiseaza);
            this.Controls.Add(this.comboBox_tabele);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_identitate);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.button_deconectare);
            this.Controls.Add(this.dataGridViewManager);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_exit);
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManager)).EndInit();
            this.groupBox_camine.ResumeLayout(false);
            this.groupBox_camine.PerformLayout();
            this.groupBox_conducere.ResumeLayout(false);
            this.groupBox_conducere.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewManager;
        private System.Windows.Forms.Button button_deconectare;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TextBox textBox_identitate;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox comboBox_luna;
        private System.Windows.Forms.TextBox textBox_presedinte;
        private System.Windows.Forms.TextBox textBox_admin;
        private System.Windows.Forms.TextBox textBox_prodecan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button_sterge;
        private System.Windows.Forms.Button button_modifica;
        private System.Windows.Forms.Button button_afiseaza_studenti;
        private System.Windows.Forms.Button button_afisare_camere;
        private System.Windows.Forms.Button button_afisare_bani;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_afiseaza;
        private System.Windows.Forms.ComboBox comboBox_camin;
        private System.Windows.Forms.ComboBox comboBox_tabele;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_liber;
        private System.Windows.Forms.Button button_detalii;
        private System.Windows.Forms.GroupBox groupBox_camine;
        private System.Windows.Forms.GroupBox groupBox_conducere;
        private System.Windows.Forms.Button button_adauga;
        private System.Windows.Forms.Button button_curata_interfata;
    }
}