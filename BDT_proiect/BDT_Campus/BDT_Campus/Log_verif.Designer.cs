
namespace BDT_Campus
{
    partial class Log_verif
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
            this.button_refuz = new System.Windows.Forms.Button();
            this.textBox_identitate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_confirmare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_rol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_refuz
            // 
            this.button_refuz.Location = new System.Drawing.Point(158, 297);
            this.button_refuz.Name = "button_refuz";
            this.button_refuz.Size = new System.Drawing.Size(125, 40);
            this.button_refuz.TabIndex = 16;
            this.button_refuz.Text = "Nu sunt eu";
            this.button_refuz.UseVisualStyleBackColor = true;
            this.button_refuz.Click += new System.EventHandler(this.button_refuz_Click);
            // 
            // textBox_identitate
            // 
            this.textBox_identitate.Location = new System.Drawing.Point(101, 145);
            this.textBox_identitate.Name = "textBox_identitate";
            this.textBox_identitate.Size = new System.Drawing.Size(235, 20);
            this.textBox_identitate.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(149, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Sunteți conectat ca";
            // 
            // button_confirmare
            // 
            this.button_confirmare.Location = new System.Drawing.Point(158, 251);
            this.button_confirmare.Name = "button_confirmare";
            this.button_confirmare.Size = new System.Drawing.Size(125, 40);
            this.button_confirmare.TabIndex = 13;
            this.button_confirmare.Text = "Confirmare";
            this.button_confirmare.UseVisualStyleBackColor = true;
            this.button_confirmare.Click += new System.EventHandler(this.button_confirmare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pentru a finaliza înregistrarea vă rugăm selectați funcția dumneavoastră";
            // 
            // comboBox_rol
            // 
            this.comboBox_rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rol.FormattingEnabled = true;
            this.comboBox_rol.Location = new System.Drawing.Point(51, 212);
            this.comboBox_rol.Name = "comboBox_rol";
            this.comboBox_rol.Size = new System.Drawing.Size(330, 21);
            this.comboBox_rol.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirmarea Identității";
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(12, 415);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(95, 23);
            this.button_exit.TabIndex = 17;
            this.button_exit.Text = "Ieșire";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Log_verif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_refuz);
            this.Controls.Add(this.textBox_identitate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_confirmare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_rol);
            this.Controls.Add(this.label2);
            this.Name = "Log_verif";
            this.Text = "Log_verif";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_refuz;
        private System.Windows.Forms.TextBox textBox_identitate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_confirmare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_rol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_exit;
    }
}