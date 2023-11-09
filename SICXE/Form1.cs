using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Antlr4;
using Antlr4.Runtime;

namespace SICXE
{
    public partial class Form1 : Form
    {
        string etiqueta = "";
        string instruccion = "";
        string operando = "";
        string contP = "";
        string b = "-1";
        string programaleido = "";
        bool ex;
        string[] res = null;
        List<string> lineas;
        List<string> errores = new List<string>();

        construyearchintermedio archintermediocrea = new construyearchintermedio();
        List<List<string>> archivointermedio = new List<List<string>>();

        public Form1(List<string> programasicxe)
        {
            InitializeComponent();

            lineas = programasicxe;
            analizaPrograma();
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void analizaPrograma()
        {
            #region paso uno
            List<string> lang1 = new List<string>();
            List<string> lang2 = new List<string>();
            List<string> numlinea = new List<string>();
            List<string> colcp = new List<string>();
            List<string> coletiq = new List<string>();
            List<string> coloper = new List<string>();
            List<string> colinstr = new List<string>();
            List<string> colerr = new List<string>();
            List<string> aux = new List<string>();
            List<List<string>> tabSim = new List<List<string>>();//Lista para la tabla de simbolos
            
            List<string> formatos = new List<string>();
            List<string> modosdir = new List<string>();


            int contint = 0;
            int simbolosentabsim = 0;
            //tabSim.Add(lang1);
            //tabSim.Add(lang2);
            archivointermedio.Add(numlinea);
            archivointermedio.Add(colcp);
            archivointermedio.Add(coletiq);
            archivointermedio.Add(colinstr);
            archivointermedio.Add(coloper);
            archivointermedio.Add(colerr);
            int linea = 0;
            int ce = 0;
            string t = "";
            List<string> codObj = new List<string>();//Lista para el manejo del cp (codObj[0]) y errores (codObj[1])
            String line;
            int reng = 0;



            if (lineas.Count > 0)
            {


                codObj.Add("0000");
                codObj.Add("");

                foreach (string elemento in lineas)
                {
                    line = elemento;

                    analizadorLSLexer lex = new analizadorLSLexer(new AntlrInputStream(line));
                    //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
                    CommonTokenStream tokens = new CommonTokenStream(lex);
                    //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
                    analizadorLSParser parser = new analizadorLSParser(tokens);
                    //CREAMOS EL PARSER CON LOS TOKENS CREADOS

                    codObj[1] = "";//Se restable el valor del error para el siguiente calculo

                    string cp = codObj[0]; //obtiene el valor cp actual ya que cp apunta al siguiente
                                           //System.Console.WriteLine("Resultado linea:"+linea.ToString());

                    if (codObj[0] == "0000" && contint == 0)
                    {
                        formatos.Add("");
                        contint = 1;
                    }

                    formatos.Add("");
                    modosdir.Add("");

                    
                    var errorListener = new ErrorListener(errores);
                    parser.RemoveErrorListeners();
                    parser.AddErrorListener(errorListener);

                    //CREAMOS ESPACIO EN LISTA DE ERRORES
                    errores.Add("");

                    
                    parser.programa();//Parametros por referencia para el calculo del cp,errores y tabsim
                                          //SE VERIFICA QUE EL ANALIZADOR EMPIECE CON LA EXPRESION


                    #region CONSTRUYE LISTA DE ARCHIVO INTERMEDIO
                    //SEPARA EXPRESION PARA OBTENER SUS ELEMENTOS E INGRESARLOS A LA LISTA DEL ARCHIVO INTERMEDIO
                    separaexpresion(line);

                    if (reng != 0)
                    {
                        List<string> nuevoRenglon = new List<string>();
                        archivointermedio.Add(nuevoRenglon);
                    }
                    if (etiqueta != "" && instruccion == "" && operando == null)
                    {
                        instruccion = etiqueta;
                        etiqueta = "";
                    }
                    else
                    {
                        if (etiqueta != "" && instruccion != "" && operando == null)
                        {
                            string auxins = instruccion;
                            instruccion = etiqueta;
                            operando = auxins;
                            etiqueta = "";
                        }
                        else
                        {
                            if (etiqueta != "" && instruccion == null)
                            {
                                instruccion = etiqueta;
                                etiqueta = "";
                                modosdir[reng] = "";
                            }
                        }
                    }
                    //ESCRIBIR RENGLON EN LISTA DE LISTAS
                    for (int i = 0; i <= 8; i++)
                    {
                        if (i == 0)
                        {
                            archivointermedio[reng].Add(linea.ToString());
                        }
                        if (i == 1)
                        {
                            archivointermedio[reng].Add(formatos[reng]);
                        }
                        if (i == 2)
                        {
                            archivointermedio[reng].Add(cp);
                        }
                        if (i == 3)
                        {
                            archivointermedio[reng].Add(etiqueta);
                        }
                        if (i == 4)
                        {
                            archivointermedio[reng].Add(instruccion);
                        }
                        if (i == 5)
                        {
                            archivointermedio[reng].Add(operando);
                        }
                        if (i == 6)
                        {
                            archivointermedio[reng].Add(modosdir[reng]);
                        }
                        if (i == 7)
                        {
                            archivointermedio[reng].Add("");
                        }
                        if (i == 8)
                        {
                            archivointermedio[reng].Add(codObj[1].ToString());
                        }
                    }
                    #endregion


                    string instractual = "";
                    instractual = archivointermedio[reng][4].ToString();

                    //SOLO SI ES DIFERENTE A START O END LA LINEA, VE A CALCULAR EL CP
                    if (instractual != "START")
                    {
                        //CALCULA CP
                        archintermediocrea.calculaCP(archivointermedio, elemento, reng, formatos);
                        //BUSCA MODO DE DIRECCIONAMIENTO
                        if (archivointermedio[reng][1].ToString() != "")//VA A BUSCAR MODO DE DIRECCIONAMIENTO SI NO DIRECTIVA
                        {
                            archintermediocrea.identificaMododir(archivointermedio, elemento, reng, modosdir);
                        }
                        //INSERTA SIMBOLO EN TABSIM
                        if (archivointermedio[reng][3].ToString() != "")//SI TIENE SIMBOLO
                        {
                            archintermediocrea.añadeatabsim(archivointermedio, reng, tabSim, simbolosentabsim);
                        }
                    }
                    if(archivointermedio[reng][4]!="ORG")
                        archivointermedio[reng][8] += errores[reng];


                    reng++;

                    linea++;


                }


                #region CONSTRUYE EL DATAGRID DE TABSIM
                // MUESTRA LA TABSIM
                t = "";

                // Se cargan los datos de la tabla de simbolos en el DataGridView
                dt_TabSim.Rows.Clear();
                dt_TabSim.DataSource = null;
                dt_TabSim.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                dt_TabSim.AllowUserToAddRows = false;

                for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                {
                    dt_TabSim.Rows.Add();

                    for (int j = 0; j < tabSim[i].Count; j++) // Itera a través de los elementos de cada sublista
                    {
                        dt_TabSim.Rows[i].Cells[j].Value = tabSim[i][j];
                        t += tabSim[i][j] + "\t";
                    }
                }
                #endregion

            }
            else
            {
                MessageBox.Show("PROGRAMA SIN CODIGO A COMPILAR");
                return;
            }
            #endregion

            #region paso dos

            for (int i = 0; i < archivointermedio.Count; i++)
            {
                if (archivointermedio[i].Count != 0)
                {
                    if (archivointermedio[i][4] != "END")
                        contP = archivointermedio[i + 1][2];
                    generaCodObj(archivointermedio[i], tabSim, contP, b);
                }
            }
            Tam.Text = "Tamaño del programa:" + contP;
            dtg_archIn.Rows.Clear();
            dtg_archIn.DataSource = null;
            dtg_archIn.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dtg_archIn.AllowUserToAddRows = false;
            for (int i = 0; i < archivointermedio.Count; i++)
            {
                if (archivointermedio[i].Count != 0)
                {
                    dtg_archIn.Rows.Add();
                    for (int j = 0; j < archivointermedio[i].Count; j++)
                    {
                        dtg_archIn.Rows[i].Cells[j].Value = archivointermedio[i][j];

                    }
                }
            }
            dtg_archIn.AutoResizeColumns();
            foreach (DataGridViewColumn column in dtg_archIn.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }




            #endregion

            #region registros
            //registro H
            string n = "";
            string nombre = "";
            string primIn = "";
            int contador = 0;
            bool bandera = true;
            int index = 0;
            int indexext = 0;
            int indexint = 0;
            string tem = "";
            List<string> relocalizables = new List<string>();//lista para el majo de todos los registros M
            List<string> codobjetosregistros = new List<string>();
            nombre = registroH(archivointermedio[0][3]);//Toma el nombre del programa
            registros.Items.Add("H" + nombre + "00" + archivointermedio[0][2] + "00" + contP);//se añade el registro H
            n = "T";
            foreach (List<string> list in archivointermedio)
            {//recorre toda la matriz del archivo intermedio 
             //para generar los archivos T y M
                if (list.Count != 0)
                {
                    if (list[7] != "" && list[4] != "WORD" && list[4] != "BYTE" && primIn == "")//Toma la primera instruccion
                    {
                        primIn = list[2];
                    }
                    if (list[7] != "" && bandera)//Va generando el registro T
                    {
                        bandera = false;
                        n += "00" + list[2];
                        tem = list[7];
                    }
                    if (list[4] == "RESB" || list[4] == "RESW" || list[4] == "ORG" || contador >= 31 || list[4] == "END")//Corta el archivo T
                    {
                        if (contador != 0)
                        {
                            index = archivointermedio.IndexOf(list);
                            if (tem.Contains("*"))
                                tem = tem.Replace("*", "");
                            n += contador.ToString("X2") + tem;

                            if (tem != archivointermedio[index - 1][7])
                            {
                                if (codobjetosregistros.Count > 1)
                                {
                                    n += string.Join("", codobjetosregistros.Skip(1));
                                }
                            }
                            registros.Items.Add(n);
                            bandera = true;
                            contador = 0;
                            n = "T";
                            tem = "";
                            codobjetosregistros.Clear();
                        }
                    }
                    if (list[7] != "")//aumenta el tamaño del registro T
                    {
                        if (list[7].Contains("*"))
                        {
                            contador += list[7].Replace("*", "").Length / 2;
                            codobjetosregistros.Add(list[7].Replace("*", ""));
                        }
                        else
                        {
                            contador += list[7].Length / 2;
                            codobjetosregistros.Add(list[7]);
                        }
                    }
                    if (list[7] != "" && list[7].Contains("*"))//Añade un nuevo registro M
                    {
                        int val=0;
                        if (list[4] != "WORD")
                        {
                            val = Convert.ToInt16(list[2], 16);
                            val++;
                            string re = val.ToString("X6");
                            relocalizables.Add("M" + re + "05" + "+" + nombre);
                        }
                        else
                        {
                            val = Convert.ToInt16(list[2], 16);
                            string re = val.ToString("X6");
                            relocalizables.Add("M" + re + "06" + "+" + nombre);
                        }
                    }
                    if (list[4] == "END")//Toma el indice de la etiqueta END
                    {
                        index = archivointermedio.IndexOf(list);
                    }
                }
            }
            foreach (string m in relocalizables)
            {//Recorre todos los registros M para añadirlos al archivo
                registros.Items.Add(m);
            }


            if (archivointermedio[index][5] == "")// si la etiqueta end no tiene op
            {
                registros.Items.Add("E" + "00" + primIn);
            }
            else 
            {//si la op esta en tabsim toma el valor
                string elementoABuscar = archivointermedio[index][5];
                int index2 = -1;

                for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                {
                    index = tabSim[i].IndexOf(elementoABuscar);
                    if (index != -1)
                    {
                        index2 = 1;
                        indexext = i;
                        indexint = 1;
                        break;
                    }
                }

                if (index == -1)
                {
                    registros.Items.Add("EFFFFFF");
                    archivointermedio[index][8] = "Error: Simbolo no encontrado en TabSim";
                    dtg_archIn.Rows[index].Cells[8].Value = "Error: Simbolo no encontrado en TabSim";
                }
                else
                {
                    registros.Items.Add("E" + "00" + tabSim[indexext][indexint]);
                }
            }

            #endregion

            #region ESCRIBE ARCHIVOS
            escribearchivointermedio(tabSim);
            escriberegistrosarchivo();
            #endregion

            #region LIMPIA VALORES
            tabSim.Clear();
            archivointermedio.Clear();
            formatos.Clear();
            modosdir.Clear();
            lang1.Clear();
            lang2.Clear();
            numlinea.Clear();
            colcp.Clear();
            coletiq.Clear();
            coloper.Clear();
            colinstr.Clear();
            colerr.Clear();
            aux.Clear();
            codObj.Clear();
            #endregion
        }


        #region ESCRIBE ARCHIVO INTERMEDIO
        private void escribearchivointermedio(List<List<string>> tabSim)
        {
            string t = "";
            string path1 = Environment.CurrentDirectory;
            // Abre el archivo intermedio 
            StreamWriter ArchInt2 = new StreamWriter(path1 + "\\archivoIntermedio.txt");
            ArchInt2.WriteLine("\t\t\tArchivo Intermedio\n");
            ArchInt2.WriteLine("LINEA\tFORM\tCP\tETIQUETA   INSTR   OP\t\tMOD\tCodigo Objeto\tErrores");

            string linea2 = "";
            string cp2 = "";
            string formato2 = "";
            string etiqueta2 = "";
            string instruccion2 = "";
            string operando2 = "";
            string modo2 = "";
            string codobj2 = "";
            string errores2 = "";


            // ancho de cada columna
            int columnaAnchoLinea = 10;
            int columnaAnchoFormato = 6;
            int columnaAnchoCP = 8;
            int columnaAnchoEtiqueta = 11;
            int columnaAnchoInstruccion = 8;
            int columnaAnchoOperando = 10;
            int columnaAnchoModo = 13;
            int columnaAnchoCodObjeto = 12;
            int columnaAnchoErrores = 20;

            // Recorre el DataGridView 
            for (int i = 0; i < dtg_archIn.Rows.Count; i++)
            {
                // obtiene valores de celdas
                linea2 = dtg_archIn.Rows[i].Cells[0].Value?.ToString() ?? "";
                formato2 = dtg_archIn.Rows[i].Cells[1].Value?.ToString() ?? "";
                cp2 = dtg_archIn.Rows[i].Cells[2].Value?.ToString() ?? "";
                etiqueta2 = dtg_archIn.Rows[i].Cells[3].Value?.ToString() ?? "";
                instruccion2 = dtg_archIn.Rows[i].Cells[4].Value?.ToString() ?? "";
                operando2 = dtg_archIn.Rows[i].Cells[5].Value?.ToString() ?? "";
                modo2 = dtg_archIn.Rows[i].Cells[6].Value?.ToString() ?? "";
                codobj2 = dtg_archIn.Rows[i].Cells[7].Value?.ToString() ?? "";
                errores2 = dtg_archIn.Rows[i].Cells[8].Value?.ToString() ?? "";

                // Formatea la línea con espaciado fijo para cada columna
                string formattedLine = $"{linea2.PadRight(columnaAnchoLinea)}" +
                                       $"{formato2.PadRight(columnaAnchoFormato)}" +
                                       $"{cp2.PadRight(columnaAnchoCP)}" +
                                       $"{etiqueta2.PadRight(columnaAnchoEtiqueta)}" +
                                       $"{instruccion2.PadRight(columnaAnchoInstruccion)}" +
                                       $"{operando2.PadRight(columnaAnchoOperando)}" +
                                       $"{modo2.PadRight(columnaAnchoModo)}" +
                                       $"{codobj2.PadRight(columnaAnchoCodObjeto)}" +
                                       $"{errores2.PadRight(columnaAnchoErrores)}";

                // Escribe la línea en el archivo intermedio
                ArchInt2.WriteLine(formattedLine);
            }


            // Agrega los datos de dt_TabSim al archivo intermedio
            ArchInt2.WriteLine("\nTABSIM\n");
            t = "";
            for (int i = 0; i < tabSim[0].Count; i++)
            {
                ArchInt2.WriteLine(string.Join("\t", tabSim.Select(list => list[i])));
            }

            ArchInt2.WriteLine("\nREGISTROS\n");
            foreach (string elemento in registros.Items)
            {
                // Escribe cada elemento del ListBox en una línea del archivo
                ArchInt2.WriteLine(elemento);
            }

            // Cierra el archivo en modo append
            ArchInt2.Close();
        }
        #endregion

        #region ESCRIBE ARCHIVO DE REGISTROS
        private void escriberegistrosarchivo()
        {
            string t = "";
            string path1 = Environment.CurrentDirectory;
            // Abre el archivo intermedio 
            StreamWriter reg = new StreamWriter(path1 + "\\registros.txt");

            reg.WriteLine("\nREGISTROS\n");
            foreach (string elemento in registros.Items)
            {
                // Escribe cada elemento del ListBox en una línea del archivo
                reg.WriteLine(elemento);
            }

            // Cierra el archivo en modo append
            reg.Close();
        }
        #endregion


        #region GENERACION REGISTRO H
        public string registroH(string n)
        {
            int tamaño = 0;
            if (n.Length >= 7)
                n = n.Remove(6);
            else
            {
                tamaño = n.Length;
                while (tamaño < 7)
                {
                    n += " ";
                    tamaño++;
                }

            }
            return n;
        }
        #endregion

        #region GENERACION CODIGO OBJETO
        public string generaCodObj(List<string> archIn, List<List<string>> tabSim, string cp, string b)
        {
            string obj = "";
            string codop = "";
            string reg1 = "";
            string reg2 = "";
            string[] partes;
            int num = 0;
            string tem = "";
            string dir = "";
            string desp = "";
            int index = -1;
            int indexext = 0;
            int indexint = 0;
            bool c = false;
            bool m = false;
            string TA = "";
            int des = 0;
            int num1 = 0;
            int num2 = 0;
            int vienecsimb = 0;
            string cpsimb = "";
            if (archIn[1] != "" && archIn[8].ToString() != "ERROR DE SINTAXIS" && archIn[4] != "RSUB" && archIn[8].ToString() != "Instruccion no existe")
            {
                vienecsimb = 0;
                cpsimb = "";
                switch (archIn[1])
                {//identifica el formato 
                    case "1":
                        archIn[7] = formato1(archIn[4]);
                        break;
                    case "2":
                        codop = formato2(archIn[4]);
                        if (archIn[5].Contains(","))
                        {
                            partes = archIn[5].Split(',');
                            reg1 = registro(partes[0]);
                            reg2 = registro(partes[1]);
                            if (codop != "" && reg1 != "" && reg2 != "")
                                archIn[7] = codop + reg1 + reg2;
                            else if (reg2 == "")
                            {
                                num = Convert.ToInt32(partes[1]);
                                num = num - 1;
                                reg2 = num.ToString("X");
                                archIn[7] = codop + reg1 + reg2;
                            }
                        }
                        else
                        {
                            reg1 = registro(archIn[5]);
                            if (codop != "" && reg1 != "")
                                archIn[7] = codop + reg1 + "0";
                        }
                        break;
                    case "3":
                        switch (archIn[6])
                        {
                            case "SIMPLE":
                                codop = formato3(archIn[4]);
                                num = Convert.ToInt32(codop, 16);
                                num = num + 3;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (archIn[5].Contains(","))
                                {
                                    partes = archIn[5].Split(',');
                                    if (partes[partes.Length - 1] == "X")//SI ES INDEXADO
                                    {
                                        if (!(partes[0].Contains("+") | partes[0].Contains("-") | partes[0].Contains("*") | partes[0].Contains("/") | partes[0].Contains("(") | partes[0].Contains(")")))
                                        {
                                            c = validaC(partes[0]);
                                            m = validaM(partes[0]);
                                        }
                                        else
                                        {
                                            string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                            res = r.Split(',');
                                            partes[0] = res[0]+"H";
                                            c = validaC(partes[0]);
                                            m = validaM(partes[0]);
                                            if (res[2] == "E")
                                                archIn[8] += "Error: Expresion";
                                        }
                                        if (c)// c,X
                                        {
                                            obj += "8";
                                            if (partes[0].Contains("H"))//si es un valor en hexadecimal
                                            {
                                                tem = partes[0].Replace("H", "");
                                                num = Convert.ToInt32(tem, 16);
                                                desp = num.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else//si es un valor en decimal
                                            {
                                                tem = partes[0];
                                                num = Convert.ToInt32(tem);
                                                desp = num.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                        }
                                        else if (m) //m,X
                                        {
                                            string elementoABuscar = partes[0];
                                            index = -1;

                                            for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                            {
                                                index = tabSim[i].IndexOf(elementoABuscar);
                                                if (index != -1)
                                                {
                                                    index = 1;
                                                    indexext = i;
                                                    indexint = 1;
                                                    break;
                                                }
                                            }
                                            if (index != -1) //si TA es un simolo en tabsim
                                            {

                                                TA = tabSim[indexext][indexint];//Obtiene la direccion objetivo
                                                //relativo a cp o a la base
                                                if (relativoCp(TA + "H", contP))//si es relativo al cp
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(contP, 16);
                                                    des = num1 - num2; //desp =TA-(CP)
                                                    obj += "A";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else if (relativoBase(TA + "H")) //Si es relativo a la base
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(b, 16);
                                                    des = num1 - num2; //desp=TA-(B)
                                                    obj += "C";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else
                                                {//No es relativo ni al cp ni a la base
                                                    obj += "EFFF";
                                                    archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                    archIn[7] = obj;
                                                }

                                            }
                                            else if (valida(partes[0]))//si TA es un valor mayor a 4095
                                            {
                                                if (partes[0].Contains("H")) //si esta en hexadecimal
                                                {
                                                    TA = partes[0].Replace("H", "");
                                                    //relativo a cp o a la base
                                                    if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                                    {
                                                        num1 = Convert.ToInt32(TA, 16);
                                                        num2 = Convert.ToInt32(contP, 16);
                                                        des = num1 - num2; //desp =TA-(CP)
                                                        obj += "A";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else if (relativoBase(TA + "H"))//si es relativo a la base
                                                    {
                                                        num1 = Convert.ToInt32(TA, 16);
                                                        num2 = Convert.ToInt32(b, 16);
                                                        des = num1 - num2;//desp=TA-(B)
                                                        obj += "C";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else//Si no es relativo ni a cp ni a la base
                                                    {
                                                        obj += "EFFF";
                                                        archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                        archIn[7] = obj;
                                                    }
                                                }
                                                else
                                                {//si esta en decimal
                                                    TA = partes[0];
                                                    //relativo a cp o a la base
                                                    if (relativoCp(TA, contP))//Si es relativo al cp
                                                    {
                                                        num1 = Convert.ToInt32(TA);
                                                        num2 = Convert.ToInt32(contP, 16);
                                                        des = num1 - num2; //desp =TA-(CP)
                                                        obj += "A";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else if (relativoBase(TA))//si es relativo a la base
                                                    {
                                                        num1 = Convert.ToInt32(TA);
                                                        num2 = Convert.ToInt32(b, 16);
                                                        des = num1 - num2;//desp=TA-(B)
                                                        obj += "C";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else//Si no es relativo ni a cp ni a la base
                                                    {
                                                        obj += "EFFF";
                                                        archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                        archIn[7] = obj;
                                                    }
                                                }
                                            }
                                            else //si no es un simbolo y no es un valor mayor a 4095
                                            {
                                                obj += "EFFF";
                                                archIn[8] += " Error: Simbolo no encontrado";
                                                archIn[7] = obj;
                                            }
                                        }
                                        else
                                        {
                                            obj += "EFFF";
                                            archIn[8] += " Error: Operando Fuera de Rango";
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        obj += "EFFF";
                                        archIn[8] += " Error: Modo de direccionamiento no existe";
                                        archIn[7] = obj;
                                    }
                                }
                                else
                                { //Si no es indexado
                               
                                    if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                    {
                                        /*c = validaC(archIn[5]);
                                        m = validaM(archIn[5]);*/
                                        int simbolosreng2 = 0;
                                        for (int i = 0; i < tabSim.Count; i++)
                                        {
                                            if (tabSim[i][0] == archIn[5].ToString())
                                            {
                                                simbolosreng2 = i;
                                            }
                                        }
                                        if (tabSim[simbolosreng2][2] == "R")
                                        {
                                            m = true;
                                        }
                                        else
                                        {
                                            c = true;
                                            vienecsimb = 1;
                                            cpsimb = tabSim[simbolosreng2][1];
                                        }
                                        ex = false;
                                    }
                                    else
                                    {
                                        string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                        res = r.Split(',');
                                        if(res[1]=="R")
                                        {
                                            m = true;
                                        }
                                        else
                                        {
                                            c = true;
                                        }
                                        //c = validaC(res[0]+"H");
                                        //m = validaM(res[0] +"H");
                                        ex = true;
                                        if (res[2] == "E")
                                            archIn[8] += "Error: Expresion";
                                    }
                                    if (c)// c
                                    {
                                        if (vienecsimb == 1)
                                        {
                                            num = Convert.ToInt32(cpsimb, 16);
                                            desp = num.ToString("X3");
                                            obj += 0;
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else
                                        {
                                            obj += "0";
                                            if (!ex)
                                            {
                                                if (archIn[5].Contains("H")) //si es un valor en hexadecimal
                                                {
                                                    tem = archIn[5].Replace("H", "");
                                                    num = Convert.ToInt32(tem, 16);
                                                    desp = num.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else //si es un valor en decimal
                                                {
                                                    tem = archIn[5];
                                                    num = Convert.ToInt32(tem);
                                                    desp = num.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                            }
                                            else
                                            {
                                                tem = res[0];
                                                num = Convert.ToInt32(tem, 16);
                                                desp = num.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                        }
                                    }
                                    else if (m) //m
                                    {
                                        if (!ex)
                                        {
                                            string elementoABuscar = archIn[5];
                                            index = -1;

                                            for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                            {
                                                index = tabSim[i].IndexOf(elementoABuscar);
                                                if (index != -1)
                                                {
                                                    index = 1;
                                                    indexext = i;
                                                    indexint = 1;
                                                    break;
                                                }
                                            }
                                            if (index != -1) //si TA es un simolo en tabsim
                                            {
                                                TA = tabSim[indexext][indexint];//Obtiene la direccion objetivo
                                                                                //relativo a cp o a la base
                                                if (relativoCp(TA + "H", contP))//si es relativo al cp
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(contP, 16);
                                                    des = num1 - num2; //desp =TA-(CP)
                                                    obj += "2";
                                                    if(des<0)
                                                        desp = (des & 0xFFF).ToString("X3");
                                                    else
                                                        desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else if (relativoBase(TA + "H")) //Si es relativo a la base
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(b, 16);
                                                    des = num1 - num2; //desp=TA-(B)
                                                    obj += "4";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else
                                                {//No es relativo ni al cp ni a la base
                                                    obj += "6FFF";
                                                    archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                    archIn[7] = obj;
                                                }

                                            }
                                            else if (valida(archIn[5])) //si TA es un valor mayor 4095
                                            {
                                                if (archIn[5].Contains("H"))//si es en hexadecimal
                                                {
                                                    TA = archIn[5].Replace("H", "");
                                                    //relativo a cp o a la base
                                                    if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                                    {
                                                        num1 = Convert.ToInt32(TA, 16);
                                                        num2 = Convert.ToInt32(contP, 16);
                                                        des = num1 - num2; //desp =TA-(CP)
                                                        obj += "2";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else if (relativoBase(TA + "H"))//si es relativo a la base
                                                    {
                                                        num1 = Convert.ToInt32(TA, 16);
                                                        num2 = Convert.ToInt32(b, 16);
                                                        des = num1 - num2;//desp=TA-(B)
                                                        obj += "4";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else//Si no es relativo ni a cp ni a la base
                                                    {
                                                        obj += "6FFF";
                                                        archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                        archIn[7] = obj;
                                                    }
                                                }
                                                else
                                                { //si es en decimal
                                                    TA = archIn[5];
                                                    //relativo a cp o a la base
                                                    if (relativoCp(TA, contP))//Si es relativo al cp
                                                    {
                                                        num1 = Convert.ToInt32(TA);
                                                        num2 = Convert.ToInt32(contP, 16);
                                                        des = num1 - num2; //desp =TA-(CP)
                                                        obj += "2";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else if (relativoBase(TA))//si es relativo a la base
                                                    {
                                                        num1 = Convert.ToInt32(TA);
                                                        num2 = Convert.ToInt32(b, 16);
                                                        des = num1 - num2;//desp=TA-(B)
                                                        obj += "4";
                                                        desp = des.ToString("X3");
                                                        obj += desp;
                                                        archIn[7] = obj;
                                                    }
                                                    else//Si no es relativo ni a cp ni a la base
                                                    {
                                                        obj += "6FFF";
                                                        archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                        archIn[7] = obj;
                                                    }

                                                }

                                            }
                                            else//Si no es un simbolo ni un valor mayor 4095
                                            {
                                                obj += "6FFF";
                                                archIn[8] += " Error: Simbolo no encontrado";
                                                archIn[7] = obj;
                                            }
                                        }
                                        else
                                        {
                                            TA = res[0];
                                            //relativo a cp o a la base
                                            if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(contP, 16);
                                                des = num1 - num2; //desp =TA-(CP)
                                                obj += "2";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else if (relativoBase(TA + "H"))//si es relativo a la base
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(b, 16);
                                                des = num1 - num2;//desp=TA-(B)
                                                obj += "4";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else//Si no es relativo ni a cp ni a la base
                                            {
                                                obj += "6FFF";
                                                archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                archIn[7] = obj;
                                            }
                                            if (res[2] == "E")
                                                archIn[8] += "Error: Expresion";
                                        }
                                    }
                                    else
                                    {
                                        obj += "6FFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }
                                }
                                break;
                            case "INMEDIATO":
                                codop = formato3(archIn[4].Replace("+", ""));
                                num = Convert.ToInt32(codop, 16);
                                num = num + 1;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                {
                                    c = validaC(archIn[5].Replace("#", ""));
                                    m = validaM(archIn[5].Replace("#", ""));
                                    ex = false;
                                }
                                else
                                {
                                    string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                    res = r.Split(',');
                                    if (res[1] == "R")
                                    {
                                        m = true;
                                    }
                                    else
                                    {
                                        c = true;
                                    }
                                    //c = validaC(res[0] + "H");
                                    //m = validaM(res[0] + "H");
                                    ex = true;
                                    if (res[2] == "E")
                                        archIn[8] += "Error: Expresion";
                                }
                                if (c)// #c
                                {
                                    obj += "0";
                                    if (!ex)
                                    {
                                        if (archIn[5].Contains("H"))
                                        {
                                            tem = archIn[5].Replace("#", "");
                                            tem = tem.Replace("H", "");
                                            num = Convert.ToInt32(tem, 16);
                                            desp = num.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else
                                        {
                                            tem = archIn[5].Replace("#", "");
                                            num = Convert.ToInt32(tem);
                                            desp = num.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        tem = res[0];
                                        num = Convert.ToInt32(tem, 16);
                                        desp = num.ToString("X3");
                                        obj += desp;
                                        archIn[7] = obj;
                                    }
                                }
                                else if (m) //#m
                                {
                                    if (!ex)
                                    {
                                        string elementoABuscar = archIn[5].Replace("#", "");
                                        index = -1;

                                        for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                        {
                                            index = tabSim[i].IndexOf(elementoABuscar);
                                            if (index != -1)
                                            {
                                                index = 1;
                                                indexext = i;
                                                indexint = 1;
                                                break;
                                            }
                                        }
                                        if (index != -1) //Si es un simbolo en tabsim
                                        {
                                            TA = tabSim[indexext][indexint];//Obtiene la direccion objetivo
                                                                            //relativo a cp o a la base
                                            if (relativoCp(TA + "H", contP))//si es relativo al cp
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(contP, 16);
                                                des = num1 - num2; //desp =TA-(CP)
                                                obj += "2";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else if (relativoBase(TA + "H")) //Si es relativo a la base
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(b, 16);
                                                des = num1 - num2; //desp=TA-(B)
                                                obj += "4";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else
                                            {//No es relativo ni al cp ni a la base
                                                obj += "6FFF";
                                                archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                archIn[7] = obj;
                                            }

                                        }
                                        else if (valida(archIn[5].Replace("#", "")))//si TA es un valor mayor 4095
                                        {
                                            if (archIn[5].Contains("H")) //si esta en hexadecimal
                                            {
                                                TA = archIn[5].Replace("#", "");
                                                TA = TA.Replace("H", "");
                                                //relativo a cp o a la base
                                                if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(contP, 16);
                                                    des = num1 - num2; //desp =TA-(CP)
                                                    obj += "2";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else if (relativoBase(TA + "H"))//si es relativo a la base
                                                {
                                                    num1 = Convert.ToInt32(TA, 16);
                                                    num2 = Convert.ToInt32(b, 16);
                                                    des = num1 - num2;//desp=TA-(B)
                                                    obj += "4";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else//Si no es relativo ni a cp ni a la base
                                                {
                                                    obj += "6FFF";
                                                    archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                    archIn[7] = obj;
                                                }
                                            }
                                            else
                                            { //si esta en decimal
                                                TA = archIn[5].Replace("#", "");
                                                //relativo a cp o a la base
                                                if (relativoCp(TA, contP))//Si es relativo al cp
                                                {
                                                    num1 = Convert.ToInt32(TA);
                                                    num2 = Convert.ToInt32(contP, 16);
                                                    des = num1 - num2; //desp =TA-(CP)
                                                    obj += "2";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else if (relativoBase(TA))//si es relativo a la base
                                                {
                                                    num1 = Convert.ToInt32(TA);
                                                    num2 = Convert.ToInt32(b, 16);
                                                    des = num1 - num2;//desp=TA-(B)
                                                    obj += "4";
                                                    desp = des.ToString("X3");
                                                    obj += desp;
                                                    archIn[7] = obj;
                                                }
                                                else//Si no es relativo ni a cp ni a la base
                                                {
                                                    obj += "6FFF";
                                                    archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                    archIn[7] = obj;
                                                }
                                            }

                                        }
                                        else//Si no es un simbolo ni un valor mayor 4095
                                        {
                                            obj += "6FFF";
                                            archIn[8] += " Error: Simbolo no encontrado";
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        TA = res[0];
                                        //relativo a cp o a la base
                                        if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                        {
                                            num1 = Convert.ToInt32(TA, 16);
                                            num2 = Convert.ToInt32(contP, 16);
                                            des = num1 - num2; //desp =TA-(CP)
                                            obj += "2";
                                            desp = (des & 0xFFF).ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else if (relativoBase(TA + "H"))//si es relativo a la base
                                        {
                                            num1 = Convert.ToInt32(TA, 16);
                                            num2 = Convert.ToInt32(b, 16);
                                            des = num1 - num2;//desp=TA-(B)
                                            obj += "4";
                                            desp = des.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else//Si no es relativo ni a cp ni a la base
                                        {
                                            obj += "6FFF";
                                            archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                            archIn[7] = obj;
                                        }
                                    }
                                }
                                else
                                {
                                    obj += "6FFF";
                                    archIn[8] += " Error: Operando Fuera de Rango";
                                    archIn[7] = obj;
                                }
                                break;
                            case "INDIRECTO":
                                codop = formato3(archIn[4]);
                                num = Convert.ToInt32(codop, 16);
                                num = num + 2;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                {
                                    c = validaC(archIn[5].Replace("@", ""));
                                    m = validaM(archIn[5].Replace("@", ""));
                                    ex = false;
                                }
                                else
                                {
                                    string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                    res = r.Split(',');
                                    if (res[1] == "R")
                                    {
                                        m = true;
                                    }
                                    else
                                    {
                                        c = true;
                                    }
                                    //c = validaC(res[0] + "H");
                                    //m = validaM(res[0] + "H");
                                    ex = true;
                                    if (res[2] == "E")
                                        archIn[8] += "Error: Expresion";
                                }
                                if (c)// c
                                {
                                    obj += "0";
                                    if (!ex)
                                    {
                                        if (archIn[5].Contains("H"))
                                        {
                                            tem = archIn[5].Replace("@", "");
                                            tem = tem.Replace("H", "");
                                            num = Convert.ToInt32(tem, 16);
                                            desp = num.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else
                                        {
                                            tem = archIn[5].Replace("@", "");
                                            num = Convert.ToInt32(tem);
                                            desp = num.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        tem = res[0];
                                        num = Convert.ToInt32(tem, 16);
                                        desp = num.ToString("X3");
                                        obj += desp;
                                        archIn[7] = obj;
                                    }
                                }
                                else if (m) //m
                                {
                                    if (!ex)
                                    {
                                        string elementoABuscar = archIn[5].Replace("@", "");
                                        index = -1;

                                        for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                        {
                                            index = tabSim[i].IndexOf(elementoABuscar);
                                            if (index != -1)
                                            {
                                                index = 1;
                                                indexext = i;
                                                indexint = 1;
                                                break;
                                            }
                                        }
                                        if (index != -1) //Si es un simbolo en tabsim
                                        {
                                            TA = tabSim[1][index];//Obtiene la direccion objetivo
                                                                  //relativo a cp o a la base
                                            if (relativoCp(TA + "H", contP))//si es relativo al cp
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(contP, 16);
                                                des = num1 - num2; //desp =TA-(CP)
                                                obj += "2";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else if (relativoBase(TA + "H")) //Si es relativo a la base
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(b, 16);
                                                des = num1 - num2; //desp=TA-(B)
                                                obj += "4";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else
                                            {//No es relativo ni al cp ni a la base
                                                obj += "6FFF";
                                                archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                archIn[7] = obj;
                                            }

                                        }
                                        else if (archIn[5].Contains("H"))//si TA es un valor mayor 4095
                                        {
                                            TA = archIn[5].Replace("@", "");
                                            TA = TA.Replace("H", "");
                                            //relativo a cp o a la base
                                            if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(contP, 16);
                                                des = num1 - num2; //desp =TA-(CP)
                                                obj += "2";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else if (relativoBase(TA + "H"))//si es relativo a la base
                                            {
                                                num1 = Convert.ToInt32(TA, 16);
                                                num2 = Convert.ToInt32(b, 16);
                                                des = num1 - num2;//desp=TA-(B)
                                                obj += "4";
                                                desp = des.ToString("X3");
                                                obj += desp;
                                                archIn[7] = obj;
                                            }
                                            else//Si no es relativo ni a cp ni a la base
                                            {
                                                obj += "6FFF";
                                                archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                                archIn[7] = obj;
                                            }

                                        }
                                        else//Si no es un simbolo ni un valor mayor 4095
                                        {
                                            obj += "6FFF";
                                            archIn[8] += " Error: Simbolo no encontrado";
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        TA = res[0];
                                        //relativo a cp o a la base
                                        if (relativoCp(TA + "H", contP))//Si es relativo al cp
                                        {
                                            num1 = Convert.ToInt32(TA, 16);
                                            num2 = Convert.ToInt32(contP, 16);
                                            des = num1 - num2; //desp =TA-(CP)
                                            obj += "2";
                                            desp = des.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else if (relativoBase(TA + "H"))//si es relativo a la base
                                        {
                                            num1 = Convert.ToInt32(TA, 16);
                                            num2 = Convert.ToInt32(b, 16);
                                            des = num1 - num2;//desp=TA-(B)
                                            obj += "4";
                                            desp = des.ToString("X3");
                                            obj += desp;
                                            archIn[7] = obj;
                                        }
                                        else//Si no es relativo ni a cp ni a la base
                                        {
                                            obj += "6FFF";
                                            archIn[8] += " Error: No es relativo ni al CP ni a la Base";
                                            archIn[7] = obj;
                                        }
                                    }
                                }
                                else
                                {
                                    obj += "6FFF";
                                    archIn[8] += " Error: Operando Fuera de Rango";
                                    archIn[7] = obj;
                                }
                                break;
                        }
                        break;
                    case "4":
                        switch (archIn[6])
                        {
                            case "SIMPLE":
                                codop = formato3(archIn[4].Replace("+", ""));
                                num = Convert.ToInt32(codop, 16);
                                num = num + 3;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (archIn[5].Contains(","))
                                {

                                    partes = archIn[5].Split(',');

                                    if (partes[partes.Length - 1] == "X")//SI ES INDEXADO
                                    {
                                        if (!(partes[0].Contains("+") | partes[0].Contains("-") | partes[0].Contains("*") | partes[0].Contains("/") | partes[0].Contains("(") | partes[0].Contains(")")))
                                        {
                                            m = validaM(partes[0]);
                                        }
                                        else
                                        {
                                            string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                            res = r.Split(',');
                                            partes[0] = res[0] + "H";
                                            m = validaM(partes[0]);
                                            if (res[2] == "E")
                                                archIn[8] += "Error: Expresion";
                                        }
                                        if (m) //m,X
                                        {
                                            string elementoABuscar = partes[0];
                                            index = -1;

                                            for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                            {
                                                index = tabSim[i].IndexOf(elementoABuscar);
                                                if (index != -1)
                                                {
                                                    index = 1;
                                                    indexext = i;
                                                    indexint = 1;
                                                    break;
                                                }
                                            }
                                            if (index != -1) // Si es un simbolo en tabsim
                                            {
                                                obj += "9";
                                                dir = tabSim[indexext][indexint];
                                                num = Convert.ToInt32(dir, 16);
                                                dir = num.ToString("X5");
                                                obj += dir + "*";
                                                archIn[7] = obj;
                                            }
                                            else if (valida(partes[0])) //si es un valor mayor a 4095
                                            {
                                                if (partes[0].Contains("H"))
                                                {
                                                    obj += "9";
                                                    dir = partes[0].Replace("H", "");
                                                    num = Convert.ToInt32(dir, 16);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }
                                                else
                                                {
                                                    obj += "9";
                                                    dir = partes[0];
                                                    num = Convert.ToInt32(dir);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }

                                            }
                                            else
                                            {
                                                obj += "FFFFFF";
                                                archIn[8] += " Error: Simbolo no encontrado";
                                                archIn[7] = obj;
                                            }
                                        }
                                        else
                                        {
                                            obj += "FFFFFF";
                                            archIn[8] += " Error: Operando Fuera de Rango";
                                            archIn[7] = obj;
                                        }

                                    }
                                    else
                                    {
                                        obj += "FFFFFF";
                                        archIn[8] += " Error: Modo de direccionamiento no existe";
                                        archIn[7] = obj;
                                    }
                                }
                                else //no es indexado pero si extendido
                                {
                                    if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                    {
                                        c = validaC(archIn[5]);
                                        m = validaM(archIn[5]);
                                        ex = false;
                                    }
                                    else
                                    {
                                        string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                        res = r.Split(',');
                                        c = validaC(res[0] + "H");
                                        m = validaM(res[0] + "H");
                                        ex = true;
                                        if (res[2] == "E")
                                            archIn[8] += "Error: Expresion";
                                    }
                                    if (m)//m
                                    {
                                        if (!ex)
                                        {
                                            string elementoABuscar = archIn[5];
                                            index = -1;

                                            for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                            {
                                                index = tabSim[i].IndexOf(elementoABuscar);
                                                if (index != -1)
                                                {
                                                    index = 1;
                                                    indexext = i;
                                                    indexint = 1;
                                                    break;
                                                }
                                            }
                                            if (index != -1) //si es un simbolo en tabsim
                                            {
                                                obj += "1";
                                                dir = tabSim[indexext][indexint];
                                                num = Convert.ToInt32(dir, 16);
                                                dir = num.ToString("X5");
                                                obj += dir + "*";
                                                archIn[7] = obj;
                                            }
                                            else if (valida(archIn[5])) //si es un valor mayor a 4095
                                            {
                                                if (archIn[5].Contains("H"))
                                                {
                                                    obj += "1";
                                                    dir = archIn[5].Replace("H", "");
                                                    num = Convert.ToInt32(dir, 16);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }
                                                else
                                                {
                                                    obj += "1";
                                                    dir = archIn[5];
                                                    num = Convert.ToInt32(dir);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }
                                            }
                                            else
                                            {
                                                obj += "7FFFFF";
                                                archIn[8] += " Error: Simbolo no encontrado";
                                                archIn[7] = obj;
                                            }
                                        }
                                        else
                                        {
                                            TA = res[0]+"H";
                                            if (valida(TA)) //si es un valor mayor a 4095
                                            {
                                                if (TA.Contains("H"))
                                                {
                                                    obj += "1";
                                                    dir = TA.Replace("H", "");
                                                    num = Convert.ToInt32(dir, 16);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }
                                                else
                                                {
                                                    obj += "1";
                                                    dir = TA;
                                                    num = Convert.ToInt32(dir);
                                                    dir = num.ToString("X5");
                                                    obj += dir;
                                                    archIn[7] = obj;
                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        obj += "7FFFFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }
                                }
                                break;
                            case "INMEDIATO":
                                codop = formato3(archIn[4].Replace("+", ""));
                                num = Convert.ToInt32(codop, 16);
                                num = num + 1;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                {
                                    m = validaM(archIn[5].Replace("#", ""));
                                    ex = false;
                                }
                                else
                                {
                                    string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                    res = r.Split(',');
                                    m = validaM(res[0] + "H");
                                    ex = true;
                                    if (res[2] == "E")
                                        archIn[8] += "Error: Expresion";
                                }
                                if (!ex)
                                {
                                    if (m)//#m
                                    {
                                        string elementoABuscar = archIn[5].Replace("#", "");
                                        index = -1;

                                        for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                        {
                                            index = tabSim[i].IndexOf(elementoABuscar);
                                            if (index != -1)
                                            {
                                                index = 1;
                                                indexext = i;
                                                indexint = 1;
                                                break;
                                            }
                                        }
                                        if (index != -1) //si es un simbolo en tabsim
                                        {
                                            obj += "1";
                                            dir = tabSim[indexext][indexint];
                                            num = Convert.ToInt32(dir, 16);
                                            dir = num.ToString("X5");
                                            obj += dir + "*";
                                            archIn[7] = obj;
                                        }
                                        else if (valida(archIn[5].Replace("#", ""))) //si es un valor mayor a 4095
                                        {
                                            if (archIn[5].Contains("H"))//si esta en hexadecimal
                                            {
                                                obj += "1";
                                                dir = archIn[5].Replace("#", "");
                                                dir = dir.Replace("H", "");
                                                num = Convert.ToInt32(dir, 16);
                                                dir = num.ToString("X5");
                                                obj += dir;
                                                archIn[7] = obj;
                                            }
                                            else
                                            {// si esta en decimal
                                                obj += "1";
                                                dir = archIn[5].Replace("#", "");
                                                num = Convert.ToInt32(dir);
                                                dir = num.ToString("X5");
                                                obj += dir;
                                                archIn[7] = obj;
                                            }
                                        }
                                        else
                                        {
                                            obj += "7FFFFF";
                                            archIn[8] += " Error: Simbolo no encontrado";
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        obj += "7FFFFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }
                                }
                                else
                                {
                                    TA = res[0] + "H";
                                    if (valida(archIn[5].Replace("#", ""))) //si es un valor mayor a 4095
                                    {
                                        if (archIn[5].Contains("H"))//si esta en hexadecimal
                                        {
                                            obj += "1";
                                            dir = archIn[5].Replace("#", "");
                                            dir = dir.Replace("H", "");
                                            num = Convert.ToInt32(dir, 16);
                                            dir = num.ToString("X5");
                                            obj += dir;
                                            archIn[7] = obj;
                                        }
                                        else
                                        {// si esta en decimal
                                            obj += "1";
                                            dir = archIn[5].Replace("#", "");
                                            num = Convert.ToInt32(dir);
                                            dir = num.ToString("X5");
                                            obj += dir;
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        obj += "7FFFFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }

                                }
                                break;
                            case "INDIRECTO":
                                codop = formato3(archIn[4].Replace("+", ""));
                                num = Convert.ToInt32(codop, 16);
                                num = num + 2;
                                codop = num.ToString("X2");
                                obj += codop;
                                if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                                {
                                    m = validaM(archIn[5].Replace("@", ""));
                                    ex = false;
                                }
                                else
                                {
                                    string r = archintermediocrea.resExpre(archivointermedio, int.Parse(archIn[0]), tabSim, 0);
                                    res = r.Split(',');
                                    m = validaM(res[0] + "H");
                                    ex = true;
                                    if (res[2] == "E")
                                        archIn[8] += "Error: Expresion";
                                }
                                if (!ex)
                                {
                                    if (m)//m
                                    {
                                        string elementoABuscar = archIn[5].Replace("@", "");
                                        index = -1;

                                        for (int i = 0; i < tabSim.Count; i++) // Itera a través de las sublistas
                                        {
                                            index = tabSim[i].IndexOf(elementoABuscar);
                                            if (index != -1)
                                            {
                                                index = 1;
                                                indexext = i;
                                                indexint = 1;
                                                break;
                                            }
                                        }

                                        if (index != -1) //si es un simbolo en tabsim
                                        {
                                            obj += "1";
                                            dir = tabSim[indexext][indexint];
                                            num = Convert.ToInt32(dir, 16);
                                            dir = num.ToString("X5");
                                            obj += dir + "*";
                                            archIn[7] = obj;
                                        }
                                        else if (valida(archIn[5].Replace("@", ""))) //si es un valor mayor a 4095
                                        {
                                            if (archIn[5].Contains("H"))//si esta en hexadecimal
                                            {
                                                obj += "1";
                                                dir = archIn[5].Replace("@", "");
                                                dir = dir.Replace("H", "");
                                                num = Convert.ToInt32(dir, 16);
                                                dir = num.ToString("X5");
                                                obj += dir;
                                                archIn[7] = obj;
                                            }
                                            else
                                            {//si esta en decimal
                                                obj += "1";
                                                dir = archIn[5].Replace("@", "");
                                                num = Convert.ToInt32(dir);
                                                dir = num.ToString("X5");
                                                obj += dir;
                                                archIn[7] = obj;
                                            }
                                        }
                                        else // Si no es un simbolo ni un valor mayor a 4095
                                        {
                                            obj += "7FFFFF";
                                            archIn[8] += " Error: Simbolo no encontrado";
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        obj += "7FFFFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }
                                }
                                else
                                {
                                    TA = res[0] + "H";
                                    if (valida(TA.Replace("@", ""))) //si es un valor mayor a 4095
                                    {
                                        if (TA.Contains("H"))//si esta en hexadecimal
                                        {
                                            obj += "1";
                                            dir = TA.Replace("@", "");
                                            dir = dir.Replace("H", "");
                                            num = Convert.ToInt32(dir, 16);
                                            dir = num.ToString("X5");
                                            obj += dir;
                                            archIn[7] = obj;
                                        }
                                        else
                                        {//si esta en decimal
                                            obj += "1";
                                            dir = TA.Replace("@", "");
                                            num = Convert.ToInt32(dir);
                                            dir = num.ToString("X5");
                                            obj += dir;
                                            archIn[7] = obj;
                                        }
                                    }
                                    else
                                    {
                                        obj += "7FFFFF";
                                        archIn[8] += " Error: Operando Fuera de Rango";
                                        archIn[7] = obj;
                                    }
                                }
                                break;
                        }
                        break;
                }
            }
            else if (archIn[4] != "START" && archIn[4] != "BASE" && archIn[4] != "END" && !archIn[8].Contains("Sintaxis") && archIn[4] != "RSUB" && !archIn[8].Contains("Instruccion"))
            {
                switch (archIn[4])
                {
                    case "WORD":
                        if (!(archIn[5].Contains("+") | archIn[5].Contains("-") | archIn[5].Contains("*") | archIn[5].Contains("/") | archIn[5].Contains("(") | archIn[5].Contains(")")))
                        {
                            if (archIn[5].Contains("H")) //si es un valor en Hexadecimal
                            {
                                tem = archIn[5].Replace("H", "");
                                num = Convert.ToInt32(tem, 16);
                                obj += num.ToString("X6");
                                archIn[7] = obj;
                            }
                            else
                            {//si es un valor en decimal
                                tem = archIn[5];
                                num = Convert.ToInt32(tem);
                                obj += num.ToString("X6");
                                archIn[7] = obj;
                            }
                        }
                        else
                        {
                            string r = archintermediocrea.resExpre(archivointermedio,int.Parse(archIn[0]), tabSim, 0);
                            string[] res = r.Split(',');
                            if (res[2] == "E")
                                archIn[8] += "Error: Expresion";
                            if (res[1] == "A")
                            {
                                tem = res[0];
                                num = Convert.ToInt32(tem,16);
                                obj += (num & 0xFFFFFF).ToString("X6");
                                archIn[7] = obj;
                            }
                            else
                            {
                                tem = res[0];
                                num = Convert.ToInt32(tem,16);
                                obj += (num & 0xFFFFFF).ToString("X6");
                                archIn[7] = obj+"*";
                            }
                        }
                        break;
                    case "BYTE":
                        if (archIn[5].Contains("H")) //si hexadecimal
                        {
                            tem = archIn[5].Replace("H", "");
                            tem = tem.Replace("'", "");
                            num = Convert.ToInt32(tem, 16);
                            obj += num.ToString("X6");
                            archIn[7] = obj;
                        }
                        else if (archIn[5].Contains("C"))
                        {//si es en caracteres
                            tem = archIn[5].Replace("C", "");
                            tem = tem.Replace("'", "");
                            byte[] ASCIIvalues = Encoding.ASCII.GetBytes(tem);
                            foreach (var value in ASCIIvalues)
                            {
                                obj += value.ToString("X2");
                            }
                            archIn[7] = obj;
                        }
                        break;
                }
            }
            else if (archIn[4] == "BASE" && !archIn[8].Contains("ERROR DE SINTAXIS") && archIn[4] != "RSUB" && !archIn[8].Contains("Instruccion no existe"))
            {
                index = tabSim[0].IndexOf(archIn[5]);
                if (index != -1) //si es un simbolo en tabsim
                {
                    b = tabSim[1][index];
                }
                else if (archIn[5].Contains("H"))
                { //si es un valor en hexadecimal
                    tem = archIn[5].Replace("H", "");
                    num = Convert.ToInt32(tem, 16);
                    b = num.ToString("X4");
                }
            }
            else if (archIn[4] == "RSUB")
            {
                obj = "4C0000";
                archIn[7] = obj;
            }
            return obj;
        }
        #endregion



        #region METODOS UTILES Y VALIDACIONES
        public void separaexpresion(string s)
        {

            string[] partes = s.Split(' '); // Dividir la cadena en partes usando espacios en blanco
                                            //string form = formatos[formatos.Count];
            Array.Resize(ref partes, partes.Length + 2);
            partes[partes.Length - 1] = "";

            etiqueta = partes[0]; // Obtener la ETIQUETA
            instruccion = partes[1]; // Obtener la INSTR
            operando = partes[2]; // Obtener el OPERANDO
            if (partes.Length > 3 && partes[3] != null && partes[3] != "")
                operando += partes[3];

        }

        public string formato1(string s)
        {
            string codop = "";
            if (s == "HIO")
                codop = "F4";
            if (s == "FIX")
                codop = "C4";
            if (s == "FLOAT")
                codop = "C0";
            if (s == "NORM")
                codop = "C8";
            if (s == "SIO")
                codop = "F0";
            if (s == "TIO")
                codop = "F8";
            return codop;
        }
        public string formato2(string s)
        {
            string codop = "";
            if (s == "CLEAR")
                codop = "B4";
            if (s == "SHIFTL")
                codop = "A4";
            if (s == "ADDR")
                codop = "90";
            if (s == "COMPR")
                codop = "A0";
            if (s == "DIVR")
                codop = "9C";
            if (s == "MULR")
                codop = "98";
            if (s == "RMO")
                codop = "AC";
            if (s == "SHIFTR")
                codop = "A8";
            if (s == "SUBR")
                codop = "94";
            if (s == "SVC")
                codop = "B0";
            if (s == "TIXR")
                codop = "B8";
            return codop;
        }

        public string formato3(string s)
        {
            string codop = "";
            if (s == "LDX")
                codop = "04";
            if (s == "LDB")
                codop = "68";
            if (s == "STA")
                codop = "0C";
            if (s == "ADD")
                codop = "18";
            if (s == "RSUB")
                codop = "4C";
            if (s == "RSUB")
                codop = "4C";
            if (s == "ADDF")
                codop = "58";
            if (s == "AND")
                codop = "40";
            if (s == "COMP")
                codop = "28";
            if (s == "COMPF")
                codop = "88";
            if (s == "DIV")
                codop = "24";
            if (s == "DIVF")
                codop = "64";
            if (s == "J")
                codop = "3C";
            if (s == "JEQ")
                codop = "30";
            if (s == "JGT")
                codop = "34";
            if (s == "JLT")
                codop = "38";
            if (s == "JSUB")
                codop = "48";
            if (s == "LDA")
                codop = "00";
            if (s == "LDCH")
                codop = "50";
            if (s == "LDF")
                codop = "70";
            if (s == "LDS")
                codop = "6C";
            if (s == "LDT")
                codop = "74";
            if (s == "LPS")
                codop = "D0";
            if (s == "MUL")
                codop = "20";
            if (s == "MULF")
                codop = "60";
            if (s == "OR")
                codop = "44";
            if (s == "RD")
                codop = "D8";
            if (s == "SSK")
                codop = "EC";
            if (s == "STB")
                codop = "78";
            if (s == "STCH")
                codop = "54";
            if (s == "STF")
                codop = "80";
            if (s == "STI")
                codop = "D4";
            if (s == "STS")
                codop = "7C";
            if (s == "STSW")
                codop = "E8";
            if (s == "STT")
                codop = "84";
            if (s == "STX")
                codop = "10";
            if (s == "SUB")
                codop = "1C";
            if (s == "SUBF")
                codop = "5C";
            if (s == "TIX")
                codop = "2C";
            if (s == "WD")
                codop = "DC";
            return codop;
        }

        public string registro(string s)
        {
            string reg = "";
            if (s == "A")
                reg = "0";
            if (s == "X")
                reg = "1";
            if (s == "L")
                reg = "2";
            if (s == "S")
                reg = "4";
            if (s == "T")
                reg = "5";
            if (s == "F")
                reg = "6";
            return reg;
        }

        public bool validaC(string s)
        {
            int num = -1;
            if (s.Contains("H"))
            {
                s = s.Replace("H", "");
                num = Convert.ToInt32(s, 16);
            }
            else
            {
                try
                {
                    num = Convert.ToInt32(s);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            if (num >= 0 && num <= 4095)
                return true;
            else
                return false;

        }

        public bool validaM(string s)
        {
            int num = 0;
            if (s.Contains("H"))
            {
                try
                {
                    num = Convert.ToInt32(s.Replace("H",""));
                    //if (num <= 4095)
                        return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
            else
            {
                try
                {
                    num = Convert.ToInt32(s);
                    if (num <= 4095)
                        return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
            return true;
        }

        public bool valida(string s)
        {
            string tem = "";
            int num = 0;
            if (s.Contains("H"))
            {
                tem = s.Replace("H", "");
                try
                {
                    num = Convert.ToInt32(tem, 16);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (num > 4095)
                    return true;
                else
                    return false;
            }
            else
            {
                try
                {
                    num = Convert.ToInt32(s);
                }
                catch (Exception e)
                {
                    return false;
                }
                if (num > 4095)
                    return true;
                else
                    return false;
            }

        }
        public string hexaBin(string hex)
        {
            // Convierte el valor hexadecimal a un valor entero
            int valorEntero = Convert.ToInt32(hex, 16);

            // Convierte el valor entero a binario
            string valorBinario = Convert.ToString(valorEntero, 2);

            return valorBinario;
        }

        public bool relativoCp(string TA, string contP)
        {
            int desp = 0;
            int num1 = 0;
            int num2 = 0;
            if (TA.Contains("H"))
            {
                TA = TA.Replace("H", "");
                num1 = Convert.ToInt32(TA, 16);
            }
            else
                num1 = Convert.ToInt32(TA);

            num2 = Convert.ToInt32(contP, 16);
            desp = num1 - num2;
            if (-2048 <= desp && desp <= 2047)
                return true;
            else
                return false;
        }

        public bool relativoBase(string TA)
        {
            if (b != "")
            {
                int desp = 0;
                int num1 = 0;
                int num2 = 0;
                if (TA.Contains("H"))
                {
                    TA = TA.Replace("H", "");
                    num1 = Convert.ToInt32(TA, 16);
                }
                else
                    num1 = Convert.ToInt32(TA);

                if (b == "-1")
                    num2 = -1;
                else
                    num2 = Convert.ToInt32(b, 16);
                desp = num1 - num2;
                if (desp >= 0 && desp <= 4095)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        
        /*
        public void indentificaError(string l)
        {
            string[] t = l.Split(' ');

            if (t.Length > 2)
            {
                if (instrucciones.Contains(t[1]) | directivas.Contains(t[1]))
                {
                    this.codObj[1] = "Error:Sintaxis";
                }
                else
                    this.codObj[1] = "Error:Instruccion no existe";
            }
            else
            {
                if (instrucciones.Contains(t[0]) | directivas.Contains(t[0]))
                {
                    this.codObj[1] = "Error:Sintaxis";
                }
                else
                    this.codObj[1] = "Error:Instruccion no existe";

            }
        }*/
    }
    #endregion


    
    #region MANEJADOR ERRORES
    public class ErrorListener : BaseErrorListener
    {
        private List<string> errores;

        public ErrorListener(List<string> errores)
        {
            this.errores = errores;
            //errores.Add("LEXICO");
        }

        public override void SyntaxError(
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,

            RecognitionException e)
        {
            string error = $"Error en línea {line}:{charPositionInLine} - {msg}";
            if (charPositionInLine<=5)
            {
                    errores[errores.Count - 1] = "Instruccion no existe";
                
            }
            else
            {

                errores[errores.Count - 1] = "ERROR DE SINTAXIS";
                
            }
        }
    }
    #endregion
    



}
