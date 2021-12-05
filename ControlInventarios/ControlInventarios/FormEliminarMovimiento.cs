using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventarios
{
    public partial class FormEliminarMovimiento : Form
    {
        string fecha;
        int id;
        public FormEliminarMovimiento(string fecha, int id)
        {
            this.fecha = fecha;
            this.id = id;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEliminarMovimiento_Load(object sender, EventArgs e)
        {
            label2.Text = "¿Estas seguro de eliminar el movimiento del " + fecha + "?, si lo eliminas cambias el stock de los productos del movimiento.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones op = new Operaciones();
                DataTable dtmovimiento = op.obtenerMovimiento(Convert.ToInt16(id));
                string tipo = dtmovimiento.Rows[0]["Tipo"].ToString();
                DataTable detalles = op.obtenerDetalles(Convert.ToInt16(id));
                for (int i = 0; i < detalles.Rows.Count; i++)
                {
                    op.modStock((tipo == "Salida" ? "+" + detalles.Rows[i]["Cantidad"] : "-" + detalles.Rows[i]["Cantidad"]), detalles.Rows[i]["idZapatos"].ToString());
                }
                op.eliminarDetalle(Convert.ToInt16(id));
                op.eliminarMovimiento(Convert.ToInt16(id));
                MessageBox.Show(this,"Se ha eliminado con éxito.","Información");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ha ocurrido un error: "+ex.Message,"Error");
                throw;
            }

        }
    }
}
