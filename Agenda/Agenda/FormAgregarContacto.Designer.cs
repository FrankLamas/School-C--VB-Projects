namespace Agenda
{
    partial class FormAgregarContacto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarContacto));
            this.tID = new System.Windows.Forms.TextBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tDomicilio = new System.Windows.Forms.TextBox();
            this.tTelefono = new System.Windows.Forms.TextBox();
            this.grDatos = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tCorreo = new System.Windows.Forms.TextBox();
            this.grOpciones = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grDatos.SuspendLayout();
            this.grOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tID
            // 
            this.tID.Location = new System.Drawing.Point(101, 44);
            this.tID.Name = "tID";
            this.tID.Size = new System.Drawing.Size(325, 26);
            this.tID.TabIndex = 1;
            this.tID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.tID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tID_KeyPress);
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(101, 82);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(325, 26);
            this.tNombre.TabIndex = 2;
            this.tNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNombre_KeyPress);
            // 
            // tDomicilio
            // 
            this.tDomicilio.Location = new System.Drawing.Point(101, 128);
            this.tDomicilio.Name = "tDomicilio";
            this.tDomicilio.Size = new System.Drawing.Size(325, 26);
            this.tDomicilio.TabIndex = 3;
            this.tDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDomicilio_KeyPress);
            // 
            // tTelefono
            // 
            this.tTelefono.Location = new System.Drawing.Point(101, 172);
            this.tTelefono.MaxLength = 10;
            this.tTelefono.Name = "tTelefono";
            this.tTelefono.Size = new System.Drawing.Size(325, 26);
            this.tTelefono.TabIndex = 4;
            this.tTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tTelefono_KeyPress);
            // 
            // grDatos
            // 
            this.grDatos.Controls.Add(this.label5);
            this.grDatos.Controls.Add(this.label4);
            this.grDatos.Controls.Add(this.label3);
            this.grDatos.Controls.Add(this.label2);
            this.grDatos.Controls.Add(this.label1);
            this.grDatos.Controls.Add(this.tCorreo);
            this.grDatos.Controls.Add(this.tID);
            this.grDatos.Controls.Add(this.tNombre);
            this.grDatos.Controls.Add(this.tTelefono);
            this.grDatos.Controls.Add(this.tDomicilio);
            this.grDatos.Location = new System.Drawing.Point(16, 78);
            this.grDatos.Name = "grDatos";
            this.grDatos.Size = new System.Drawing.Size(442, 290);
            this.grDatos.TabIndex = 5;
            this.grDatos.TabStop = false;
            this.grDatos.Text = "Datos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Correo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Domicilio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // tCorreo
            // 
            this.tCorreo.Location = new System.Drawing.Point(101, 221);
            this.tCorreo.Name = "tCorreo";
            this.tCorreo.Size = new System.Drawing.Size(325, 26);
            this.tCorreo.TabIndex = 5;
            this.tCorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCorreo_KeyPress);
            // 
            // grOpciones
            // 
            this.grOpciones.Controls.Add(this.pictureBox2);
            this.grOpciones.Controls.Add(this.pictureBox1);
            this.grOpciones.Location = new System.Drawing.Point(464, 78);
            this.grOpciones.Name = "grOpciones";
            this.grOpciones.Size = new System.Drawing.Size(115, 290);
            this.grOpciones.TabIndex = 0;
            this.grOpciones.TabStop = false;
            this.grOpciones.Text = "Opciones";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Agenda.Properties.Resources.cancelar;
            this.pictureBox2.Location = new System.Drawing.Point(17, 153);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Agenda.Properties.Resources.comprobado;
            this.pictureBox1.Location = new System.Drawing.Point(17, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(383, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Captura los datos y da click en el botón para guardar.";
            // 
            // FormAgregarContacto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 383);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grOpciones);
            this.Controls.Add(this.grDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAgregarContacto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Contacto";
            this.grDatos.ResumeLayout(false);
            this.grDatos.PerformLayout();
            this.grOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tID;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tDomicilio;
        private System.Windows.Forms.TextBox tTelefono;
        private System.Windows.Forms.GroupBox grDatos;
        private System.Windows.Forms.GroupBox grOpciones;
        private System.Windows.Forms.TextBox tCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}