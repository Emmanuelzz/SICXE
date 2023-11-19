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
        List<string> entradasobj = new List<string>();
        int entradas = 0;
        private Programaobj formularioTexto;

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
            openFileDialog.Filter = "Archivos de texto (*.obj)|*.obj";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                importedText = File.ReadAllText(fileName);

                importedFile = true;

                entradas++;

                    entradasobj.Add(entradas.ToString());
                    string[] lines = File.ReadAllLines(fileName);
                    entradasobj.AddRange(lines);
                

                MostrarContenidoFormularioTexto(entradasobj);
            }
            else
            {
                importedFile = false;
            }
        }

        private void MostrarContenidoFormularioTexto(List<string> entradasobj)
        {
            // VERIFICA SI NO SE A CREADO EL FORMULARIO
            if (formularioTexto == null || formularioTexto.IsDisposed)
            {
                // SI NO, CREAMOS LA INSTANCIA
                formularioTexto = new Programaobj();
            }

            List<string> entradamuestra = new List<string>(entradasobj);

            entradamuestra.RemoveAll(s => IsNumeric(s) && int.Parse(s) >= 1 && int.Parse(s) <= 12);

            string contenido = string.Join(Environment.NewLine, entradamuestra);

            formularioTexto.MostrarTexto(contenido);

            formularioTexto.Show();

            entradas++;
        }

        private bool IsNumeric(string input)
        {
            return int.TryParse(input, out _);
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
