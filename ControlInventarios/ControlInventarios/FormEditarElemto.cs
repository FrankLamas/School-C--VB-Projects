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
    public partial class FormEditarElemto : Form
    {
        int id;
        string foto;

        public FormEditarElemto(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizarProveedores()
        {
            cmbProveedor.Items.Clear();
            Operaciones op = new Operaciones();
            DataTable dt = op.datosProveedor();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "idProveedor";

            cmbProveedor.SelectedIndex = 0;
            cmbProveedor.Refresh();
        }
        
        private void FormEditarElemto_Load(object sender, EventArgs e)
        {
            actualizarProveedores();

            cmbTipo.SelectedIndex = 0;
            cmbNum1.SelectedIndex = 0;
            cmbNum2.SelectedIndex = 40;
            Operaciones op = new Operaciones();
            DataTable dt = op.obtenerElemto(id);
            tModelo.Text = dt.Rows[0]["Modelo"].ToString();

            tFoto.Text = dt.Rows[0]["Foto"].ToString();
            foto = tFoto.Text;
            tColor.Text = dt.Rows[0]["Color"].ToString();
            tStock.Text = dt.Rows[0]["Stock"].ToString();
            cmbTipo.Text = dt.Rows[0]["Tipo"].ToString();
            tPrecio.Text = dt.Rows[0]["Precio"].ToString();
            tPrecioCompra.Text = dt.Rows[0]["PrecioCompra"].ToString();
            cmbProveedor.Text = dt.Rows[0]["Nombre"].ToString();
            string[] num = dt.Rows[0]["Numeracion"].ToString().Split('-');
            cmbNum1.Text = num[0];
            cmbNum2.Text = num[1];
            pictureBox1.ImageLocation = tFoto.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            tModelo.Text = "";
            tPrecio.Text = "";
            tColor.Text = "";
            tStock.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (tModelo.Text != "" && tColor.Text != "" && tPrecio.Text != "" && tStock.Text != "" && tPrecioCompra.Text != "" && cmbProveedor.Text != "")
                    {
                        //DataTable modelo = op.obtenerElemto(tModelo.Text, cmbNum1.Text + "-" + cmbNum2.Text,tColor.Text);

                        //if (modelo.Rows.Count>0)
                        //{
                        //    MessageBox.Show(this, "El modelo como es capturado ya existe. Prueba con datos diferentes", "Información");
                        //}
                        //else
                        //{
                            if (foto != tFoto.Text)
                            {
                                Test();
                            }
                            op.editarElemto(id, tModelo.Text, tFoto.Text == foto ? foto : Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg", cmbNum1.Text + "-" + cmbNum2.Text, Convert.ToInt16(tStock.Text), cmbTipo.Text, Convert.ToDouble(tPrecio.Text), tColor.Text,Convert.ToDouble(tPrecioCompra.Text),Convert.ToInt16(cmbProveedor.SelectedValue));
                            //System.IO.File.Copy(tFoto.Text, Application.StartupPath + @"/Imagenes/" + tModelo.Text + ".jpg", true);
                            if (foto != tFoto.Text)
                            {
                                Test();
                            }
                            MessageBox.Show(this, "Se guardó exitosamente.", "Información");
                            this.Close();
                        //}
                    }
                    else
                    {
                        MessageBox.Show(this, "Debes llenar todos los campos", "Atención");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error: " + ex.Message, "Ecepcepción");
            }
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

        private void tPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            FormAgregarProveedor fap = new FormAgregarProveedor();
            fap.ShowDialog();
            actualizarProveedores();
        }


    }
}
