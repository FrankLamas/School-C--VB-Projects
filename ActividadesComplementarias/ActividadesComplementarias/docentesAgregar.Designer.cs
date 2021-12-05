namespace ActividadesComplementarias
{
    partial class docentesAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(docentesAgregar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.tID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bCancelar = new System.Windows.Forms.PictureBox();
            this.bAceptar = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tNombre);
            this.groupBox1.Controls.Add(this.tID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(77, 136);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(400, 26);
            this.tNombre.TabIndex = 5;
            this.tNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNombre_KeyPress);
            // 
            // tID
            // 
            this.tID.Location = new System.Drawing.Point(77, 59);
            this.tID.Name = "tID";
            this.tID.Size = new System.Drawing.Size(400, 26);
            this.tID.TabIndex = 4;
            this.tID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bCancelar);
            this.groupBox2.Controls.Add(this.bAceptar);
            this.groupBox2.Location = new System.Drawing.Point(501, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selección";
            // 
            // bCancelar
            // 
            this.bCancelar.Image = global::ActividadesComplementarias.Properties.Resources.cancelar;
            this.bCancelar.Location = new System.Drawing.Point(52, 126);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(76, 72);
            this.bCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bCancelar.TabIndex = 8;
            this.bCancelar.TabStop = false;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bAceptar
            // 
            this.bAceptar.Image = global::ActividadesComplementarias.Properties.Resources.comprobado;
            this.bAceptar.Location = new System.Drawing.Point(52, 35);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(76, 72);
            this.bAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bAceptar.TabIndex = 7;
            this.bAceptar.TabStop = false;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingresa los datos y da click en el botón para guardar.";
            // 
            // docentesAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "docentesAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Docente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAceptar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.TextBox tID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox bCancelar;
        private System.Windows.Forms.PictureBox bAceptar;
        private System.Windows.Forms.Label label3;
    }
}