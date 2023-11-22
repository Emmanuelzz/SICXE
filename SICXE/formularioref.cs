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
    public partial class formularioref : Form
    {
        private int childFormNumber = 0;
        string textorichtextbox = "";
        private RichTextBox richTextBox;
        private bool importedFile = false; // Bandera para verificar si se importó un archivo
        private string importedText = null; // Variable para almacenar el contenido importado
        string[] Reservadas = new string[] { "WORD", "BYTE","RESB", "RESW","END","START","BASE"};
        string[] Reservadas2 = new string[] { "LDX", "HIO", "LDB", "+LDB", "STA", "CLEAR","ADDR","ADD","+STA","RSUB","SHIFTL" };
        int posicion = 0;
        private int tabPageNumber = 1; // Contador para nombres de pestañas
        private TabControl tabControl1;
        int calculo = 0;


        public formularioref()
        {
            InitializeComponent();
            cargarbutton.Visible = true;

        }

        private void ShowNewForm(object sender, EventArgs e)
        {

            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Size = this.ClientSize;

            tabControl1 = new TabControl();
            tabControl1.Dock = DockStyle.Fill;
            childForm.Controls.Add(tabControl1);

            // Crea un nuevo TabPage y lo agrega al TabControl
            TabPage tabPage = new TabPage();
            tabPage.Text = "EDITOR " + tabPageNumber++;

            richTextBox = new RichTextBox();

            richTextBox.Multiline = true;
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.ShortcutsEnabled = true;
            richTextBox.Enabled = true;
            richTextBox.ReadOnly = false;
            richTextBox.ContextMenuStrip = contextMenuStrip1;

            // estilo de fuente 
            Font richTextBoxFont = new Font("Consolas", 12, FontStyle.Regular);
            richTextBox.Font = richTextBoxFont;
            string texto = "/*COMPILADOR PARA ARQUITECTURA SICXE" + "\r\n" +
                         "----EMMANUEL JUÁREZ RODRÍGUEZ---------" + "\r\n" +
                         "----JOAN ZURIEL HERNANDEZ GÓMEZ-------" + "\r\n" +
                         "----ESCRIBE TU CÓDIGO PARA LA ARQUITECTURA SICXE-----*/" + "\r\n";

            richTextBox.Text = texto;


            int startIndex = 0;
            while (startIndex < texto.Length)
            {
                int comentarioInicio = texto.IndexOf("/*", startIndex);
                if (comentarioInicio == -1) break;

                int comentarioFin = texto.IndexOf("*/", comentarioInicio);
                if (comentarioFin == -1) break;


                richTextBox.Select(comentarioInicio, comentarioFin - comentarioInicio + 2);
                richTextBox.SelectionColor = Color.Green;
                richTextBox.Select(comentarioFin + 2, 0);

                startIndex = comentarioFin + 2;
            }

            // detecta los cambios de texto 
            richTextBox.TextChanged += (sender2, e2) =>
            {
                HighlightComments(richTextBox);
                //posicion = richTextBox.SelectionStart;
                //ejecucion();
            };

            tabPage.Controls.Add(richTextBox);

            // Agregar el nuevo TabPage al TabControl
            tabControl1.TabPages.Add(tabPage);

            saveToolStripButton.Visible = true;

            tabPage.Controls.Add(richTextBox);

            childForm.Dock = DockStyle.Fill;

            childForm.Show();

            if (importedFile)
            {
                richTextBox.Text = importedText;
                importedFile = false; // Restablece la bandera
            }

        }


        private void HighlightComments(RichTextBox richTextBox)
        {
            toolStrip.Focus();

            // Almacena temporalmente la selección actual
            int start = richTextBox.SelectionStart;
            int length = richTextBox.SelectionLength;

            // Texto completo en el RichTextBox
            string texto = richTextBox.Text;

            // Borra el formato existente
            richTextBox.SelectAll();
            richTextBox.SelectionColor = richTextBox.ForeColor;

            // Define una expresión regular para identificar las palabras reservadas de Reservadas
            string reservadasPattern = string.Join("|", Reservadas.Select(Regex.Escape));

            // Crear la expresión regular
            Regex regexReservadas = new Regex($@"\b({reservadasPattern})\b", RegexOptions.IgnoreCase);

            // Colorea las coincidencias de Reservadas
            foreach (Match match in regexReservadas.Matches(texto))
            {
                if (!IsInsideComment(texto, match.Index))
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = Color.Blue; // Color para Reservadas
                }
            }

            // Define una expresión regular para identificar las palabras reservadas de Reservadas2
            string reservadasPattern2 = string.Join("|", Reservadas2.Select(Regex.Escape));

            // Crea la expresión regular para Reservadas2
            Regex regexReservadas2 = new Regex($@"\b({reservadasPattern2})\b", RegexOptions.IgnoreCase);

            // Colorea las coincidencias de Reservadas2
            foreach (Match match in regexReservadas2.Matches(texto))
            {
                if (!IsInsideComment(texto, match.Index))
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = Color.Red; // Color para Reservadas2
                }
            }

            // Colorea los comentarios
            int startIndex = 0;
            while (startIndex < texto.Length)
            {
                int comentarioInicio = texto.IndexOf("/*", startIndex);
                if (comentarioInicio == -1) break;

                int comentarioFin = texto.IndexOf("*/", comentarioInicio);
                if (comentarioFin == -1) break;

                // Colorea el comentario en verde
                richTextBox.Select(comentarioInicio, comentarioFin - comentarioInicio + 2);
                richTextBox.SelectionColor = Color.Green;

                startIndex = comentarioFin + 2;
            }

            // Restaura la selección original
            richTextBox.Select(start, length);
            richTextBox.Focus();
            textorichtextbox = richTextBox.Text;
        }

        // Función para verificar si una posición dada está dentro de un comentario
        private bool IsInsideComment(string texto, int position)
        {
            int startIndex = 0;
            bool insideComment = false;

            while (startIndex < texto.Length)
            {
                int comentarioInicio = texto.IndexOf("/*", startIndex);
                if (comentarioInicio == -1) break;

                int comentarioFin = texto.IndexOf("*/", comentarioInicio);
                if (comentarioFin == -1) break;

                if (position > comentarioInicio && position < comentarioFin)
                {
                    insideComment = true;
                    break;
                }

                startIndex = comentarioFin + 2;
            }

            return insideComment;
        }









        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                importedText = File.ReadAllText(fileName);


                // Establece la bandera como verdadera
                importedFile = true;

                // Llama al método ShowNewForm para crear un nuevo formulario con el contenido del archivo
                ShowNewForm(sender, e);
            }
            else
            {
                importedFile = false; // Si el usuario cancela la operación, marca la bandera como falsa
            }
        }


        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripSeparator3_Click(object sender, EventArgs e)
        {

        }

        private void viewMenu_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            string textoSinComentarios = Regex.Replace(textorichtextbox, @"/\*.*?\*/", "", RegexOptions.Singleline);
            List<string> lineas = textoSinComentarios.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (tabControl1 != null && tabControl1.TabPages.Count == 1)
            {
                Form childForm = new Form();
                childForm.Text = "Ventana " + childFormNumber++;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Size = this.ClientSize;
                childForm.MdiParent = this;
                TabPage tabPage2 = new TabPage("ENSAMBLADOR");
                tabControl1.TabPages.Add(tabPage2);

                if (lineas.Count > 0)
                {
                    Form1 form1 = new Form1(lineas);
                    form1.TopLevel = false;
                    form1.FormBorderStyle = FormBorderStyle.None;
                    tabPage2.Controls.Add(form1);
                    form1.Dock = DockStyle.Fill;
                    form1.Show();
                    calculo = 1;
                    lineas.Clear();
                }
                else
                {
                    MessageBox.Show("PROGRAMA SIN CODIGO A COMPILAR");
                    return;
                }
            }
            else
            {
                if (tabControl1.TabPages.Count == 2 && calculo == 1)
                {
                    // Busca una instancia existente de Form1 dentro de la pestaña 2
                    Form1 form1 = null;
                    foreach (Control control in tabControl1.TabPages[1].Controls)
                    {
                        if (control is Form1)
                        {
                            form1 = (Form1)control;
                            break;
                        }
                    }

                    // Si existe una instancia de Form1, la elimína antes de crear una nueva
                    if (form1 != null)
                    {
                        form1.Dispose();
                    }

                    form1 = new Form1(lineas);
                    form1.TopLevel = false;
                    form1.FormBorderStyle = FormBorderStyle.None;
                    tabControl1.TabPages[1].Controls.Add(form1);
                    form1.Dock = DockStyle.Fill;
                    form1.Show();

                    calculo = 1;
                    lineas.Clear();
                }
            }
            //cargarbutton.Visible = true;
        }



        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PegarTexto(richTextBox);
        }

        private void PegarTexto(RichTextBox richTextBox)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (richTextBox.SelectionLength > 0)
                {
                    richTextBox.SelectedText = Clipboard.GetData(DataFormats.Text).ToString();
                }
                else
                {
                    richTextBox.Text += Clipboard.GetData(DataFormats.Text).ToString();
                }
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string nombreArchivo = saveFileDialog.FileName;

                try
                {
                    // Abre o crea un archivo de texto para escribir
                    using (StreamWriter sw = new StreamWriter(nombreArchivo))
                    {
                        // Escribe el contenido del RichTextBox en el archivo
                        sw.WriteLine(richTextBox.Text);
                    }

                    // Muestra un mensaje de éxito
                    MessageBox.Show("El contenido se ha guardado correctamente en el archivo.", "Guardar Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al guardar el archivo
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void formularioref_Load(object sender, EventArgs e)
        {

        }

        private void cargarbutton_Click(object sender, EventArgs e)
        {
            Cargador carga = new Cargador();
            carga.Show();
        }

    }
}
