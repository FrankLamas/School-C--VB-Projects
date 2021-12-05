namespace Agenda
{
    partial class MenuP
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuP));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarContactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contactosToolStripMenuItem
            // 
            this.contactosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarContactoToolStripMenuItem,
            this.modificarContactoToolStripMenuItem,
            this.eliminarContactoToolStripMenuItem,
            this.buscarContactoToolStripMenuItem,
            this.mostrarContactosToolStripMenuItem});
            this.contactosToolStripMenuItem.Image = global::Agenda.Properties.Resources.contactos;
            this.contactosToolStripMenuItem.Name = "contactosToolStripMenuItem";
            this.contactosToolStripMenuItem.Size = new System.Drawing.Size(120, 29);
            this.contactosToolStripMenuItem.Text = "Contactos";
            // 
            // agregarContactoToolStripMenuItem
            // 
            this.agregarContactoToolStripMenuItem.Image = global::Agenda.Properties.Resources.agregar_usuario;
            this.agregarContactoToolStripMenuItem.Name = "agregarContactoToolStripMenuItem";
            this.agregarContactoToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.agregarContactoToolStripMenuItem.Text = "Agregar Contacto";
            this.agregarContactoToolStripMenuItem.Click += new System.EventHandler(this.agregarContactoToolStripMenuItem_Click);
            // 
            // modificarContactoToolStripMenuItem
            // 
            this.modificarContactoToolStripMenuItem.Image = global::Agenda.Properties.Resources.lapiz;
            this.modificarContactoToolStripMenuItem.Name = "modificarContactoToolStripMenuItem";
            this.modificarContactoToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.modificarContactoToolStripMenuItem.Text = "Modificar Contacto";
            this.modificarContactoToolStripMenuItem.Click += new System.EventHandler(this.modificarContactoToolStripMenuItem_Click);
            // 
            // eliminarContactoToolStripMenuItem
            // 
            this.eliminarContactoToolStripMenuItem.Image = global::Agenda.Properties.Resources.usuario;
            this.eliminarContactoToolStripMenuItem.Name = "eliminarContactoToolStripMenuItem";
            this.eliminarContactoToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.eliminarContactoToolStripMenuItem.Text = "Eliminar Contacto";
            this.eliminarContactoToolStripMenuItem.Click += new System.EventHandler(this.eliminarContactoToolStripMenuItem_Click);
            // 
            // buscarContactoToolStripMenuItem
            // 
            this.buscarContactoToolStripMenuItem.Image = global::Agenda.Properties.Resources.investigacion;
            this.buscarContactoToolStripMenuItem.Name = "buscarContactoToolStripMenuItem";
            this.buscarContactoToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.buscarContactoToolStripMenuItem.Text = "Buscar Contacto";
            this.buscarContactoToolStripMenuItem.Click += new System.EventHandler(this.buscarContactoToolStripMenuItem_Click);
            // 
            // mostrarContactosToolStripMenuItem
            // 
            this.mostrarContactosToolStripMenuItem.Image = global::Agenda.Properties.Resources.lista;
            this.mostrarContactosToolStripMenuItem.Name = "mostrarContactosToolStripMenuItem";
            this.mostrarContactosToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.mostrarContactosToolStripMenuItem.Text = "Mostrar Contactos";
            this.mostrarContactosToolStripMenuItem.Click += new System.EventHandler(this.mostrarContactosToolStripMenuItem_Click);
            // 
            // MenuP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 301);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pantalla Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MenuP_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarContactoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarContactosToolStripMenuItem;
    }
}

