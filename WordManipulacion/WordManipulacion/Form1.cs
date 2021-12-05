using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using word = Microsoft.Office.Interop.Word;

namespace WordManipulacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ruta = Application.StartupPath + "\\Evaluacion.docx";
            object ObjMiss = System.Reflection.Missing.Value;
            word.Application objWord = new word.Application();
            word.Document wdoc = objWord.Documents.Open(ruta,ObjMiss,ObjMiss,ObjMiss);
            wdoc.Activate();
        }
    }
}
