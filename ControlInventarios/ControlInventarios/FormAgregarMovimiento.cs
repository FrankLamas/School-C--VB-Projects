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
    public partial class FormAgregarMovimiento : Form
    {
        double total = 0;
        public FormAgregarMovimiento()
        {
            InitializeComponent();
        }

        private void actualizarClientes()
        {
            cmbProveedor.DataSource = null;
            cmbProveedor.Items.Clear();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosClientes();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idClientes";

            try
            {
                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Aún no hay clientes agregados.", "Aviso");
            }
            cmbProveedor.Refresh();
        }

        private void FormAgregarMovimiento_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            tTotal.Text = total.ToString();
            actualizarClientes();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsDigit(e.KeyChar) || Char.Equals(e.KeyChar, '.'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void actualizarTotal(){
            double suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                suma = suma + (Convert.ToDouble(dataGridView1.Rows[i].Cells[comboBox1.Text=="Salida"?1:2].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
            }
            tTotal.Text = suma.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (op.valModelos(tModelo.Text)!=true)
                {
                    if (tCantidad.Text != "")
                    {
                        DataTable dt = op.obtenerElemto(tModelo.Text,cmbNumeración.Text,cmbColor.Text);
                        if (dt.Rows.Count>0)
                        {
                            dataGridView1.Rows.Add(dt.Rows[0]["Modelo"], dt.Rows[0]["Precio"], dt.Rows[0]["PrecioCompra"], tCantidad.Text, dt.Rows[0]["Color"], dt.Rows[0]["Numeracion"], dt.Rows[0]["idZapatos"]);
                            actualizarTotal();
                            
                        }
                        else
                        {
                            MessageBox.Show(this, "Los datos que elegiste no coinciden. Si estas seguro de ellos agrega un elemento con ellos y vuelve a intentarlo.", "Error.");
                        }
                    }
                    else
                        MessageBox.Show(this, "No has llenado el campo de cantidad. Llenalo e intenta de nuevo.");
                    
                }
                else
                {
                    MessageBox.Show(this, "El modelo que intentas agregar no existe.", "Atención");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ha ocurrido algo: "+ex.Message,"Error");
                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarElemto fae = new FormAgregarElemto();
            fae.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            actualizarTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (tTotal.Text=="" && dataGridView1.Rows.Count==0)
                {
                    MessageBox.Show(this,"Error, no se puede completar la operacion porque omitiste un valor necesario.","Error");
                }
                else
                {
                    if (cbCliente.Checked==true)
                    {
                        op.agregarMovimiento(dateTimePicker1.Text, Convert.ToDouble(tTotal.Text), comboBox1.Text,Convert.ToInt16(cmbProveedor.SelectedValue));
                        op.editarGastadoCliente(Convert.ToInt16(cmbProveedor.SelectedValue),Convert.ToDouble(tTotal.Text));
                    }else
                        op.agregarMovimiento(dateTimePicker1.Text, Convert.ToDouble(tTotal.Text), comboBox1.Text);
                    DataTable dt = op.obtenerMovimientos();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        op.agregarDetalle(Convert.ToInt16(dt.Rows[dt.Rows.Count-1]["idMovimiento"].ToString()),Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value.ToString()),Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                        op.modStock((comboBox1.Text == "Salida" ? "-" + dataGridView1.Rows[i].Cells[3].Value.ToString() : "+" + dataGridView1.Rows[i].Cells[3].Value.ToString()),dataGridView1.Rows[i].Cells[6].Value.ToString());
                        if (cbCliente.Checked == true)
                            op.editarParesCliente(Convert.ToInt16(cmbProveedor.SelectedValue),Convert.ToDouble(tTotal.Text));
                    }
                    MessageBox.Show(this, "El movimiento se guardó con éxito.", "Información");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ha ocurrido un error: "+ ex.Message,"Error");
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            actualizarTotal();
        }

        private void tModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    cmbColor.Items.Clear();
                    cmbNumeración.Items.Clear();
                    Operaciones op = new Operaciones();
                    DataTable dt = op.obtenerElemto(tModelo.Text);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cmbColor.Items.Add(dt.Rows[i]["Color"]);
                            cmbNumeración.Items.Add(dt.Rows[i]["Numeracion"]);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "El modelo que escribiste no está en la base de datos.", "Error.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error: "+ex.Message,"Error");
                throw;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTotal();
            if (comboBox1.Text=="Entrada")
            {
                cbCliente.Checked = false;
                cbCliente.Enabled = false;
                cmbProveedor.Enabled = false;
            }
            else
            {
                cbCliente.Checked = true;
                cbCliente.Enabled = true;
                cmbProveedor.Enabled = true;
            }
        }

        private void cbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCliente.Checked==false)
            {
                cmbProveedor.Enabled = false;
            }else
                cmbProveedor.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormAgregarCliente fac = new FormAgregarCliente();
            fac.ShowDialog();
            actualizarClientes();
        }
    }
}
