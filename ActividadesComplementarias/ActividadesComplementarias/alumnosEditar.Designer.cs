namespace ActividadesComplementarias
{
    partial class alumnosEditar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(alumnosEditar));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bSalir = new System.Windows.Forms.PictureBox();
            this.bBuscar = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tID = new System.Windows.Forms.TextBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tSeguro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tSemestre = new System.Windows.Forms.ComboBox();
            this.tCarrera = new System.Windows.Forms.ComboBox();
            this.tSangre = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBuscar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ingresa No. de Control y da click en el icono para buscar y despues en editar.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.bSalir);
            this.groupBox2.Controls.Add(this.bBuscar);
            this.groupBox2.Location = new System.Drawing.Point(534, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(99, 256);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecionar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::ActividadesComplementarias.Properties.Resources.editar__1_;
            this.pictureBox1.Location = new System.Drawing.Point(16, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // bSalir
            // 
            this.bSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSalir.Image = global::ActividadesComplementarias.Properties.Resources.espalda;
            this.bSalir.Location = new System.Drawing.Point(16, 173);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(56, 59);
            this.bSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bSalir.TabIndex = 12;
            this.bSalir.TabStop = false;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // bBuscar
            // 
            this.bBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBuscar.Image = global::ActividadesComplementarias.Properties.Resources.buscar_una_persona_simbolo_de_interfaz_de_una_lupa_en_forma_de_hombre;
            this.bBuscar.Location = new System.Drawing.Point(16, 37);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(56, 61);
            this.bBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bBuscar.TabIndex = 11;
            this.bBuscar.TabStop = false;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tSangre);
            this.groupBox1.Controls.Add(this.tCarrera);
            this.groupBox1.Controls.Add(this.tSemestre);
            this.groupBox1.Controls.Add(this.tID);
            this.groupBox1.Controls.Add(this.tNombre);
            this.groupBox1.Controls.Add(this.tSeguro);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(21, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 256);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // tID
            // 
            this.tID.Location = new System.Drawing.Point(129, 34);
            this.tID.Name = "tID";
            this.tID.Size = new System.Drawing.Size(372, 26);
            this.tID.TabIndex = 9;
            this.tID.TextChanged += new System.EventHandler(this.tID_TextChanged);
            this.tID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tID_KeyPress);
            // 
            // tNombre
            // 
            this.tNombre.Enabled = false;
            this.tNombre.Location = new System.Drawing.Point(129, 70);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(372, 26);
            this.tNombre.TabIndex = 8;
            this.tNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNombre_KeyPress);
            // 
            // tSeguro
            // 
            this.tSeguro.Enabled = false;
            this.tSeguro.Location = new System.Drawing.Point(129, 188);
            this.tSeguro.Name = "tSeguro";
            this.tSeguro.Size = new System.Drawing.Size(372, 26);
            this.tSeguro.TabIndex = 7;
            this.tSeguro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tSeguro_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tipo de Sangre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "IMSS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Semestre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Carrera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. de Control";
            // 
            // tSemestre
            // 
            this.tSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSemestre.Enabled = false;
            this.tSemestre.FormattingEnabled = true;
            this.tSemestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.tSemestre.Location = new System.Drawing.Point(129, 146);
            this.tSemestre.Name = "tSemestre";
            this.tSemestre.Size = new System.Drawing.Size(121, 28);
            this.tSemestre.TabIndex = 11;
            // 
            // tCarrera
            // 
            this.tCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tCarrera.Enabled = false;
            this.tCarrera.FormattingEnabled = true;
            this.tCarrera.Items.AddRange(new object[] {
            "Lic. Administración",
            "Ing. Informática",
            "Ing. Industrial",
            "Ing. Gestión Empresarial",
            "Ing. Electromecánica",
            "Ing. Civil"});
            this.tCarrera.Location = new System.Drawing.Point(129, 107);
            this.tCarrera.Name = "tCarrera";
            this.tCarrera.Size = new System.Drawing.Size(372, 28);
            this.tCarrera.TabIndex = 12;
            // 
            // tSangre
            // 
            this.tSangre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSangre.Enabled = false;
            this.tSangre.FormattingEnabled = true;
            this.tSangre.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.tSangre.Location = new System.Drawing.Point(129, 225);
            this.tSangre.Name = "tSangre";
            this.tSangre.Size = new System.Drawing.Size(121, 28);
            this.tSangre.TabIndex = 13;
            // 
            // alumnosEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "alumnosEditar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Alumnos";
            this.Load += new System.EventHandler(this.alumnosEditar_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBuscar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox bSalir;
        private System.Windows.Forms.PictureBox bBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tID;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tSeguro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tSangre;
        private System.Windows.Forms.ComboBox tCarrera;
        private System.Windows.Forms.ComboBox tSemestre;

    }
}