namespace ActividadesComplementarias
{
    partial class frmOperacionesAsignarAlumnoATaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperacionesAsignarAlumnoATaller));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbDisponibleA = new System.Windows.Forms.Label();
            this.lbDisponible = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTaller = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tSemestre = new System.Windows.Forms.TextBox();
            this.tCarrera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPeriodo1 = new System.Windows.Forms.ComboBox();
            this.cmbPeriodo2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbPeriodo2);
            this.groupBox1.Controls.Add(this.cmbPeriodo1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lbDisponibleA);
            this.groupBox1.Controls.Add(this.lbDisponible);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cmbTaller);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(416, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignación";
            // 
            // lbDisponibleA
            // 
            this.lbDisponibleA.AutoSize = true;
            this.lbDisponibleA.Location = new System.Drawing.Point(316, 71);
            this.lbDisponibleA.Name = "lbDisponibleA";
            this.lbDisponibleA.Size = new System.Drawing.Size(96, 17);
            this.lbDisponibleA.TabIndex = 4;
            this.lbDisponibleA.Text = "No Disponible";
            this.lbDisponibleA.Visible = false;
            // 
            // lbDisponible
            // 
            this.lbDisponible.AutoSize = true;
            this.lbDisponible.Location = new System.Drawing.Point(316, 110);
            this.lbDisponible.Name = "lbDisponible";
            this.lbDisponible.Size = new System.Drawing.Size(96, 17);
            this.lbDisponible.TabIndex = 3;
            this.lbDisponible.Text = "No Disponible";
            this.lbDisponible.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 69);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // cmbTaller
            // 
            this.cmbTaller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaller.FormattingEnabled = true;
            this.cmbTaller.Location = new System.Drawing.Point(118, 107);
            this.cmbTaller.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTaller.Name = "cmbTaller";
            this.cmbTaller.Size = new System.Drawing.Size(193, 24);
            this.cmbTaller.TabIndex = 2;
            this.cmbTaller.SelectedIndexChanged += new System.EventHandler(this.cmbTaller_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Talller Asignado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. de control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(805, 48);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(82, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selección";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::ActividadesComplementarias.Properties.Resources.cancelar;
            this.pictureBox2.Location = new System.Drawing.Point(5, 78);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ActividadesComplementarias.Properties.Resources.comprobado;
            this.pictureBox1.Location = new System.Drawing.Point(5, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ingresa los datos y presiona el botón.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre Alumno";
            // 
            // tNombre
            // 
            this.tNombre.Enabled = false;
            this.tNombre.Location = new System.Drawing.Point(120, 30);
            this.tNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(248, 22);
            this.tNombre.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tSemestre);
            this.groupBox3.Controls.Add(this.tCarrera);
            this.groupBox3.Controls.Add(this.tNombre);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(432, 50);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(373, 134);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Alumno";
            // 
            // tSemestre
            // 
            this.tSemestre.Enabled = false;
            this.tSemestre.Location = new System.Drawing.Point(120, 107);
            this.tSemestre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tSemestre.Name = "tSemestre";
            this.tSemestre.Size = new System.Drawing.Size(248, 22);
            this.tSemestre.TabIndex = 8;
            // 
            // tCarrera
            // 
            this.tCarrera.Enabled = false;
            this.tCarrera.Location = new System.Drawing.Point(120, 68);
            this.tCarrera.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tCarrera.Name = "tCarrera";
            this.tCarrera.Size = new System.Drawing.Size(248, 22);
            this.tCarrera.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Carrera";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Semestre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Periodo";
            // 
            // cmbPeriodo1
            // 
            this.cmbPeriodo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo1.FormattingEnabled = true;
            this.cmbPeriodo1.Items.AddRange(new object[] {
            "AGO/DIC",
            "ENE/JUL"});
            this.cmbPeriodo1.Location = new System.Drawing.Point(118, 29);
            this.cmbPeriodo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPeriodo1.Name = "cmbPeriodo1";
            this.cmbPeriodo1.Size = new System.Drawing.Size(127, 24);
            this.cmbPeriodo1.TabIndex = 6;
            // 
            // cmbPeriodo2
            // 
            this.cmbPeriodo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo2.FormattingEnabled = true;
            this.cmbPeriodo2.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cmbPeriodo2.Location = new System.Drawing.Point(260, 29);
            this.cmbPeriodo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPeriodo2.Name = "cmbPeriodo2";
            this.cmbPeriodo2.Size = new System.Drawing.Size(127, 24);
            this.cmbPeriodo2.TabIndex = 7;
            // 
            // frmOperacionesAsignarAlumnoATaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 192);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmOperacionesAsignarAlumnoATaller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Alumno A Taller";
            this.Load += new System.EventHandler(this.frmOperacionesAsignarAlumnoATaller_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTaller;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbDisponibleA;
        private System.Windows.Forms.Label lbDisponible;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tSemestre;
        private System.Windows.Forms.TextBox tCarrera;
        private System.Windows.Forms.ComboBox cmbPeriodo2;
        private System.Windows.Forms.ComboBox cmbPeriodo1;
        private System.Windows.Forms.Label label7;
    }
}