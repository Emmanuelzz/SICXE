using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace SICXE
{
    public partial class Cargador : Form
    {
        private bool importedFile = false;
        private string importedText = null;

        public Cargador()
        {
            InitializeComponent();
            agregarenglones();
        }

        public void agregarenglones()
        {
            dataGridView1.Rows.Add("1000");
            dataGridView1.Rows.Add("1010");
            dataGridView1.Rows.Add("1020");
            dataGridView1.Rows.Add("1030");
            dataGridView1.Rows.Add("1040");
            textBox1.Text = "1000";
        }

        private void botonabrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                importedText = File.ReadAllText(fileName);

                importedFile = true;


                MostrarContenidoFormularioTexto(importedText);
            }
            else
            {
                importedFile = false; 
            }
        }

        private void MostrarContenidoFormularioTexto(string texto)
        {

            Programaobj formularioTexto = new Programaobj();

            formularioTexto.MostrarTexto(texto);

          
            formularioTexto.ShowDialog();
        }

        private void cambiardir_Click(object sender, EventArgs e)
        {
            string nuevoValor = textBox1.Text;


            dataGridView1.Rows[0].Cells[0].Value = nuevoValor;

  
            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (int.Parse(nuevoValor) + 10 * i).ToString();
            }
        }



    }
}
