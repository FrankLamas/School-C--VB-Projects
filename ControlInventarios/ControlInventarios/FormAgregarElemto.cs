using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlInventarios
{
    public partial class FormAgregarElemto : Form
    {
        public FormAgregarElemto()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tStock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tModelo.Text = "";
            tPrecio.Text = "";
            tColor.Text = "";
            tStock.Text = "0";
            tPrecioCompra.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog();
            BuscarImagen.Filter = "Arichivos de Imagen|*.jpg";
            BuscarImagen.FileName = "";
            //BuscarImagen.InitialDirectory = "C:\\";
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                tFoto.Text = BuscarImagen.FileName;
                string direccion = BuscarImagen.FileName;
                pictureBox1.ImageLocation = direccion;
            }
        }
        private void Test()
        {
            using (var image = Image.FromFile(@tFoto.Text))
            using (var newImage = ScaleImage(image, 300, 400))
            {
                if (System.IO.File.Exists(Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg"))
                    System.IO.File.Delete(Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg");
                newImage.Save(Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg", ImageFormat.Jpeg);
            }
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            try
            {
                if (tModelo.Text != "" && tColor.Text != "" && tPrecio.Text != "" && tStock.Text != "" && tPrecioCompra.Text!="" && cmbProveedor.Text!="")
                {
                    DataTable modelo = op.obtenerElemto(tModelo.Text, cmbNum1.Text + "-" + cmbNum2.Text, tColor.Text);

                    if (modelo.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "El modelo como es capturado ya existe. Prueba con datos diferentes", "Información");
                    }
                    else
                    {

                        op.agregarElemto(tModelo.Text, tFoto.Text == "" ? Application.StartupPath + @"\Imagenes\nd.jpg" : Application.StartupPath + @"\Imagenes\" + tModelo.Text + ".jpg", cmbNum1.Text + "-" + cmbNum2.Text, Convert.ToInt16(tStock.Text), cmbTipo.Text, Convert.ToDouble(tPrecio.Text), tColor.Text,Convert.ToDouble(tPrecioCompra.Text),Convert.ToInt16(cmbProveedor.SelectedValue));
                        //System.IO.File.Copy(tFoto.Text, Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg", true);
                        if (tFoto.Text != "")
                            Test();
                        MessageBox.Show(this, "Se guardó exitosamente.", "Información");
                        tModelo.Text = "";
                        tPrecio.Text = "";
                        tColor.Text = "";
                        tStock.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show(this, "Debes llenar todos los campos", "Atención");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"Error: "+ex.Message,"Ecepcepción");
            }
            
        }

        private void actualizarProveedores() {
            cmbProveedor.DataSource = null;
            cmbProveedor.Items.Clear();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosProveedor();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idProveedor";
            try
            {
                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(this,"Aún no hay proveedores agregados.","Aviso");
            }
            cmbProveedor.Refresh();
        }

        private void FormAgregarElemto_Load(object sender, EventArgs e)
        {
            
            cmbTipo.SelectedIndex = 0;
            cmbNum1.SelectedIndex = 0;
            cmbNum2.SelectedIndex = 40;
            actualizarProveedores();
        }

        private void tPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Back) || Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor fap = new FormAgregarProveedor();
            fap.ShowDialog();
            actualizarProveedores();
        }
    }
}
