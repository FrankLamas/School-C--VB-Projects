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
    public partial class FormEditarMovimiento : Form
    {
        double total = 0;
        string id,tipo="";
        public FormEditarMovimiento(string id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarElemto fae = new FormAgregarElemto();
            fae.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarTotal()
        {
            double suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                suma = suma + (Convert.ToDouble(dataGridView1.Rows[i].Cells[comboBox1.Text == "Salida" ? 1 : 2].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
            }
            tTotal.Text = suma.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (op.valModelos(tModelo.Text) != true)
                {
                    if (tCantidad.Text != "")
                    {
                        DataTable dt = op.obtenerElemto(tModelo.Text);
                        dataGridView1.Rows.Add(dt.Rows[0]["Modelo"], dt.Rows[0]["Precio"], tCantidad.Text, dt.Rows[0]["Color"], dt.Rows[0]["Numeracion"], dt.Rows[0]["idZapatos"]);
                        actualizarTotal();
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
                MessageBox.Show(this, "Ha ocurrido algo: " + ex.Message, "Error");
                throw;
            }
        }

        private void FormEditarMovimiento_Load(object sender, EventArgs e)
        {
            actualizarClientes();
            comboBox1.SelectedIndex = 0;
            Operaciones op = new Operaciones();
            DataTable dtmovimiento = op.obtenerMovimiento(Convert.ToInt16(id));
            total = Convert.ToDouble(dtmovimiento.Rows[0]["Total"]);
            tTotal.Text = total.ToString();
            
            comboBox1.Text = dtmovimiento.Rows[0]["Tipo"].ToString();
            tipo = dtmovimiento.Rows[0]["Tipo"].ToString();
            dateTimePicker1.Text = dtmovimiento.Rows[0]["Fecha"].ToString();
            if (tipo == "Entrada" || dtmovimiento.Rows[0]["idClientes"].ToString()=="")
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
                cmbProveedor.SelectedValue = dtmovimiento.Rows[0]["idClientes"]; 
            } 
            DataTable dtDetalles = op.obtenerDetalles(Convert.ToInt16(id));
            for (int i = 0; i < dtDetalles.Rows.Count; i++)
            {
                DataTable dt = op.obtenerElemto(Convert.ToInt16(dtDetalles.Rows[i]["idZapatos"].ToString()));
                dataGridView1.Rows.Add(dt.Rows[0]["Modelo"], dt.Rows[0]["Precio"],dt.Rows[0]["PrecioCompra"], dtDetalles.Rows[i]["Cantidad"], dt.Rows[0]["Color"], dt.Rows[0]["Numeracion"], dt.Rows[0]["idZapatos"]);
            }
            actualizarTotal();

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

        private void button1_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (tTotal.Text == "" && dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Error, no se puede completar la operacion porque omitiste un valor necesario.", "Error");
                }
                else
                {
                    DataTable detalles = op.obtenerDetalles(Convert.ToInt16(id));
                    DataTable dtMov = op.obtenerMovimiento(Convert.ToInt16(id));
                    for (int i = 0; i < detalles.Rows.Count; i++)
                    {
                        op.modStock((tipo == "Salida" ? "+" + detalles.Rows[i]["Cantidad"] : "-" + detalles.Rows[i]["Cantidad"]), detalles.Rows[i]["idZapatos"].ToString());
                        if (tipo == "Salida" && dtMov.Rows[0]["idClientes"].ToString()!="")
                            op.editarParesCliente(Convert.ToInt16(dtMov.Rows[0]["idClientes"]), Convert.ToDouble("-" + detalles.Rows[i]["Cantidad"].ToString()));
                    }
                    if (dtMov.Rows[0]["idClientes"].ToString() != "")
                        op.editarGastadoCliente(Convert.ToInt16(dtMov.Rows[0]["idClientes"]), Convert.ToDouble("-" + dtMov.Rows[0]["Total"].ToString()));


                    op.eliminarDetalle(Convert.ToInt16(id));
                    op.eliminarMovimiento(Convert.ToInt16(id));
                    if (cbCliente.Checked == true)
                    {
                        op.agregarMovimiento(Convert.ToInt16(id),dateTimePicker1.Text, Convert.ToDouble(tTotal.Text), comboBox1.Text, Convert.ToInt16(cmbProveedor.SelectedValue));
                        op.editarGastadoCliente(Convert.ToInt16(cmbProveedor.SelectedValue), Convert.ToDouble(tTotal.Text));
                    }
                    else
                        op.agregarMovimiento(Convert.ToInt16(id),dateTimePicker1.Text, Convert.ToDouble(tTotal.Text), comboBox1.Text);
                    DataTable dt = op.obtenerMovimientos();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        op.agregarDetalle(Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["idMovimiento"].ToString()), Convert.ToInt16(dataGridView1.Rows[i].Cells[6].Value.ToString()), Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value.ToString()));
                        op.modStock((comboBox1.Text == "Salida" ? "-" + dataGridView1.Rows[i].Cells[3].Value.ToString() : "+" + dataGridView1.Rows[i].Cells[3].Value.ToString()), dataGridView1.Rows[i].Cells[6].Value.ToString());
                        if (cbCliente.Checked == true)
                            op.editarParesCliente(Convert.ToInt16(cmbProveedor.SelectedValue), Convert.ToDouble(tTotal.Text));
                    }
                    MessageBox.Show(this,"El movimiento se guardó con éxito.","Información");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ha ocurrido un error: " + ex.Message, "Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            actualizarTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
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
                MessageBox.Show(this, "Error: " + ex.Message, "Error");
                throw;
            }
        }

        private void tCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (op.valModelos(tModelo.Text) != true)
                {
                    if (tCantidad.Text != "")
                    {
                        DataTable dt = op.obtenerElemto(tModelo.Text, cmbNumeración.Text, cmbColor.Text);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.Rows.Add(dt.Rows[0]["Modelo"], dt.Rows[0]["Precio"],dt.Rows[0]["PrecioCompra"], tCantidad.Text, dt.Rows[0]["Color"], dt.Rows[0]["Numeracion"], dt.Rows[0]["idZapatos"]);
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
                MessageBox.Show(this, "Ha ocurrido algo: " + ex.Message, "Error");
                throw;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormAgregarCliente fac = new FormAgregarCliente();
            fac.ShowDialog();
            actualizarClientes();
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

            cmbProveedor.SelectedIndex = 0;
            cmbProveedor.Refresh();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTotal();
            if (comboBox1.Text == "Entrada")
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
            if (cbCliente.Checked == false)
            {
                cmbProveedor.Enabled = false;
            }
            else
                cmbProveedor.Enabled = true;
        }
    }
}
