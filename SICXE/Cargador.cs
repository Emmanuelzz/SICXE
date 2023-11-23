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
        public List<string> ren = new List<string>();
        public string dirIni = "";
        List<string> entradamuestra;
        List<List<string>> tabse = new List<List<string>>();
        List<List<string>> mapa = new List<List<string>>();

        public Cargador()
        {
            InitializeComponent();
            agregarenglones();
            renglonTabse(tabse);
        }

        public void agregarenglones()
        {
            dataGridView1.Rows.Add("1000");
            ren.Add("1000");
            renglonMapa(mapa, "1000");
            dataGridView1.Rows.Add("1010");
            ren.Add("1010");
            renglonMapa(mapa, "1010");
            dataGridView1.Rows.Add("1020");
            ren.Add("1020");
            renglonMapa(mapa, "1020");
            dataGridView1.Rows.Add("1030");
            ren.Add("1030");
            renglonMapa(mapa, "1030");
            dataGridView1.Rows.Add("1040");
            ren.Add("1040");
            renglonMapa(mapa, "1040");
            textBox1.Text = "1000";
            dirIni = "1000";
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

            entradamuestra = new List<string>(entradasobj);

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
            dirIni = nuevoValor;
            ren.Add("");
            renglonMapa(mapa, "");
            char ultimocaracter = nuevoValor[nuevoValor.Count()-1];

            if (ultimocaracter != '0')//SI EL ULTIMO CARACTER NO ES ENTERO...ENTONCES HAZLO ENTERO
            {
                int pos = nuevoValor.Count() - 1;

                StringBuilder sb = new StringBuilder(nuevoValor);
                sb[pos] = '0';
                nuevoValor = sb.ToString();
            }
            dataGridView1.Rows[0].Cells[0].Value = nuevoValor;
            ren[0] = nuevoValor;
            mapa[0][0] = nuevoValor;

            for (int i = 1; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (int.Parse(nuevoValor) + 10 * i).ToString();
                ren[i] = (int.Parse(nuevoValor) + 10 * i).ToString();
                mapa[i][0]= (int.Parse(nuevoValor) + 10 * i).ToString();
            }
        }

        private void ejecutar_Click(object sender, EventArgs e)
        {
            string dirsc = "", lonsc = "",direj="",inicio="",fin="";
            List<string> relocalizacion = new List<string>();
            int i = 0;
            int index = 0,j=0,indice=0;
            string tem = "",aux="";
            string colDir="";
            bool band = false;
            bool siguiente=false;
            #region Paso1
            dirsc = dirIni;
            while (i < entradamuestra.Count) {
                tem = entradamuestra[i];
                lonsc = tem.Substring(13);
                if (buscaTabse(tem, true,ref indice))
                    band = true;//error
                else
                {
                    tabse[tabse.Count - 1][0] = tem.Substring(1, 6);
                    tabse[tabse.Count - 1][2] = dirsc;
                    tabse[tabse.Count - 1][3] = tem.Substring(13);
                    renglonTabse(tabse);
                }
                while (tem.Substring(0, 1) != "E") {
                    if (tem.Substring(0, 1) == "D") {
                        string texto = tem.Substring(1);
                        var palabras = texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .SelectMany(word => SplitByLength(word, 6))
                           .ToList();
                        band = false;
                        foreach (var palabra in palabras)
                        {
                            if (siguiente)
                            {
                                siguiente = false;
                                continue;
                            }
                            if (!band)
                            {
                                if (buscaTabse(palabra, false,ref indice))
                                {
                                    //error
                                    siguiente = true;
                                    continue;

                                }
                                else
                                {
                                    tabse[tabse.Count - 1][1] = palabra;
                                    band = true;
                                }
                            }
                            else
                            {
                                tabse[tabse.Count - 1][2] = (Convert.ToInt32(palabra,16)+Convert.ToInt32(dirsc,16)).ToString("X6");
                                renglonTabse(tabse);
                                band = false;
                            }

                        }
                    }
                    i++;
                    tem = entradamuestra[i];
                }
                dirsc = (Convert.ToInt32(dirsc, 16) + Convert.ToInt32(lonsc, 16)).ToString("X4");
               i++;
            }
            #endregion
            #region Paso2
            i = 0;
            dirsc = dirIni;
            direj = dirIni;
            while (i < entradamuestra.Count)
            {
                tem = entradamuestra[i];
                lonsc = tem.Substring(13);
                while (tem.Substring(0, 1) != "E")
                {
                    if (tem.Substring(0, 1) == "T")
                    {
                        string texto = tem.Substring(9);
                        var palabras = texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                           .SelectMany(word => SplitByLength(word, 2))
                           .ToList();

                        int direccion = Convert.ToInt32(tem.Substring(1, 6),16) + Convert.ToInt32(dirsc, 16);
                        if (direccion % 2 == 0)
                        {
                            index = ren.IndexOf(direccion.ToString("X4"));
                            j = 1;
                            if (index < 0)
                            {
                                index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                                j = columna(direccion.ToString("X4")[3]);
                                if (index < 0)
                                {
                                    renglonMapa(mapa, direccion.ToString("X4").Remove(3) + "0");
                                    ren.Add(direccion.ToString("X4").Remove(3) + "0");
                                    ren.Sort();
                                    index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                                    j = columna(direccion.ToString("X4")[3]);
                                }
                            }
                           
                        }
                        else {
                            index = ren.IndexOf(direccion.ToString("X4").Remove(3)+"0");
                            if (index < 0)
                            {
                                renglonMapa(mapa, direccion.ToString("X4").Remove(3) + "0");
                                ren.Add(direccion.ToString("X4").Remove(3) + "0");
                                ren.Sort();
                                index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                            }
                            j = columna(direccion.ToString("X4")[3]);
                        }
                        // Imprimir las palabras de 6 caracteres
                        foreach (var palabra in palabras)
                        {
                            if(inicio=="")
                                inicio=index.ToString()+","+j.ToString();
                            mapa[index][j] = palabra;
                            j++;
                            if (j > 16) {
                                j = 1;
                                index++;
                                if (index > ren.Count-1)
                                {
                                    renglonMapa(mapa, (Convert.ToInt32(ren[ren.Count - 1], 16) + Convert.ToInt32("10", 16)).ToString("X4"));
                                    ren.Add((Convert.ToInt32(ren[ren.Count - 1], 16) + Convert.ToInt32("10", 16)).ToString("X4"));
                                }
                            }
                        }
                    }
                    else if(tem.Substring(0, 1) == "M")
                    {
                        if (!buscaTabse(tem.Substring(10), false, ref indice))
                        {
                            band = true;//error
                        }
                        else
                        {
                            aux = "";
                            string valor = tabse[indice][2];
                            int direccion = Convert.ToInt32(tem.Substring(1, 6), 16) + Convert.ToInt32(dirsc, 16);
                            if (direccion % 2 == 0)
                            {
                                index = ren.IndexOf(direccion.ToString("X4"));
                                j = 1;
                                if (index < 0)
                                {
                                    index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                                    if (index < 0)
                                    {
                                        renglonMapa(mapa, direccion.ToString("X4").Remove(3) + "0");
                                        ren.Add(direccion.ToString("X4").Remove(3) + "0");
                                        ren.Sort();
                                        index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                                    }
                                    j = columna(direccion.ToString("X4")[3]);
                                    
                                }

                            }
                            else
                            {
                                index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");
                                if (index < 0)
                                {
                                    renglonMapa(mapa, direccion.ToString("X4").Remove(3) + "0");
                                    ren.Add(direccion.ToString("X4").Remove(3) + "0");
                                    ren.Sort();
                                    index = ren.IndexOf(direccion.ToString("X4").Remove(3) + "0");

                                }
                                j = columna(direccion.ToString("X4")[3]);
                            }
                            int b = j;
                            int c = index;
                            for (int a = 0; a < 3; a++) {
                                aux += mapa[c][b];
                                b++;
                                if (b > 16) {
                                    b = 1;
                                    c++;
                                }
                            }
                            if (aux != "")
                            {
                                if(tem.Substring(9, 1) == "+")
                                    aux = (Convert.ToInt32(aux, 16) + Convert.ToInt32(valor, 16)).ToString("X6");
                                else
                                    aux = (Convert.ToInt32(aux, 16) - Convert.ToInt32(valor, 16)).ToString("X6");
                            }
                            else
                            {
                                aux = (Convert.ToInt32(valor, 16)).ToString("X6");
                            }
                            b = j;
                            c = index;
                            relocalizacion.Add(index.ToString() + ","+j.ToString());
                            int x = 0;
                            for (int a = 0; a < 3; a++)
                            {
                                mapa[c][b]= aux.Substring(x, 2);
                                b++;
                                x += 2;
                                if (b > 16)
                                {
                                    b = 1;
                                    c++;
                                }
                            }
                        }
                    }
                    i++;
                    tem = entradamuestra[i];
                }
                if (tem.Substring(1)!="")
                    direj = (Convert.ToInt32(dirsc, 16) + Convert.ToInt32(tem.Substring(1), 16)).ToString("X6");
                dirsc =(Convert.ToInt32(dirsc,16) + Convert.ToInt32(lonsc,16)).ToString("X6");
                i++;
            }
            fin = index.ToString() + "," + (j + 2).ToString();
            #endregion

            #region CargaTabse
            for (i = 0; i < tabse.Count; i++) {
                dataGridView2.Rows.Add();
                for (j = 0; j < 4; j++) {
                    dataGridView2.Rows[i].Cells[j].Value = tabse[i][j];
                }
            }
            #endregion
            #region cargaDataGrid
            dataGridView1.Rows.Clear();
            for (i = 0; i < ren.Count; i++)
            {
                dataGridView1.Rows.Add();
                for (j = 0; j < 17; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mapa[i][j];
                }
            }
            string[] indices = inicio.Split(',');
            dataGridView1.Rows[int.Parse(indices[0])].Cells[int.Parse(indices[1])].Style.BackColor = System.Drawing.Color.Green;
            indices = fin.Split(',');
            dataGridView1.Rows[int.Parse(indices[0])].Cells[int.Parse(indices[1])].Style.BackColor = System.Drawing.Color.Red;
            foreach (string r in relocalizacion) {
                indices = r.Split(',');
                int b = int.Parse(indices[1]);
                int c = int.Parse(indices[0]);
                for (i = 0; i < 3; i++) {
                    dataGridView1.Rows[c].Cells[b].Style.BackColor = System.Drawing.Color.Yellow;
                    b++;
                    if (b > 16) {
                        b = 1;
                        c++;
                    }
                }
            }
            #endregion


        }
        public void renglonTabse(List<List<string>> tabse) {
            List<string> renTabse = new List<string>();
            for (int i = 0; i < 4; i++) {
                renTabse.Add("");
            }
            tabse.Add(renTabse);
        }

        public void renglonMapa(List<List<string>> mapa,string s) {
            List<string> renMapa = new List<string>();
            renMapa.Add(s);
            for (int i = 1; i < 17; i++)
            {
                renMapa.Add("");
            }
            mapa.Add(renMapa);
        }
        public bool buscaTabse(string s,bool sec,ref int index) {
            if(sec)
                s = s.Substring(1, 6);
            foreach (List<string> renglon in tabse) {
                if (renglon[0].Replace(" ","").Contains(s.Replace(" ",""))|| renglon[1].Replace(" ", "").Contains(s.Replace(" ", "")))
                {
                    index = tabse.IndexOf(renglon);
                    return true;
                }
            }
            return false;
        }

        static IEnumerable<string> SplitByLength(string str, int length)
        {
            for (int i = 0; i < str.Length; i += length)
            {
                yield return str.Substring(i, Math.Min(length, str.Length - i));
            }
        }

        public int columna(char s) {
            if (s == '0')
                return 1;
            if (s == '1')
                return 2;
            if (s == '2')
                return 3;
            if (s == '3')
                return 4;
            if (s == '4')
                return 5;
            if (s == '5')
                return 6;
            if (s == '6')
                return 7;
            if (s == '7')
                return 8;
            if (s == '8')
                return 9;
            if (s == '9')
                return 10;
            if (s == 'A')
                return 11;
            if (s == 'B')
                return 12;
            if (s == 'C')
                return 13;
            if (s == 'D')
                return 14;
            if (s == 'E')
                return 15;
            if (s == 'F')
                return 16;
            return -1;
        }

       
    }
}
