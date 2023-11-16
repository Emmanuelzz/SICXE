using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SICXE
{
    public partial class Programaobj : Form
    {
        public Programaobj()
        {
            InitializeComponent();
        }


        public void MostrarTexto(string texto)
        {
            // Muestra el contenido del archivo de texto en el RichTextBox
            richTextBox1.Text = texto;
        }
    }
}
