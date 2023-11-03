using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;



namespace SICXE
{


    class construyearchintermedio
    {
        List<List<string>> archivointermedio = new List<List<string>>();
        List<string> formatos = new List<string>();
        List<string> cps = new List<string>();
        List<string> modosdir = new List<string>();
        List<List<string>> tabsim = new List<List<string>>();
        string valu = "";
        string l = "";
        int simbolosreng = 0;

        public construyearchintermedio()
        {
            cps.Add("0000");
            cps.Add("0000");
        }

        #region CALCULACP
        public void calculaCP(List<List<string>> archivointermedio,string lineacodigo,int renglon, List<string> formatos)
        {

            string evaluainstr = "";
            int cp = 0;

            if (archivointermedio[renglon][4].ToString() != "")
            {
                if (archivointermedio[renglon][4].ToString()[0] == '+')//SI ES FORMATO EXTENDIDO
                {
                    cps.Add("");
                    archivointermedio[renglon][1] = "4";
                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                    cp += 4;
                    cps[renglon] = cp.ToString("X4");
                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                    return;
                }
                else
                {
                    //SI ES UNA DIRECTIVA ORG
                    if (archivointermedio[renglon][4].ToString() == "ORG")
                    {
                        //formatos[reng] = "RB";
                        string va = archivointermedio[renglon][5].ToString();

                        //string[] li = this.l.Split(' ');
                        //string va = li[li.Length - 1];
                        if (va.Contains("H"))
                        {
                            va = va.Replace("H", "");
                            int n = Convert.ToInt32(va, 16);
                            cp = n;
                            cps[renglon] = cp.ToString("X4");
                            archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                        }
                        else
                        {
                            int n = Convert.ToInt32(va);
                            cp = n;
                            cps[renglon] = cp.ToString("X4");
                            archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                        }
                        return;
                    }
                    else
                    {
                        evaluainstr = instruccionesevalua(archivointermedio[renglon][4].ToString());
                    }
                }


                if (evaluainstr != "") //SI ES UNA INSTRUCCIÓN
                {
                    cps.Add("");
                    switch (evaluainstr)
                    {
                        case "F1":
                            archivointermedio[renglon][1] = "1";
                            cp = Convert.ToInt32(cps[renglon - 1], 16);
                            cp += 1;
                            cps[renglon] = cp.ToString("X4");
                            archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                            break;
                        case "F2":
                            archivointermedio[renglon][1] = "2";
                            cp = Convert.ToInt32(cps[renglon - 1], 16);
                            cp += 2;
                            cps[renglon] = cp.ToString("X4");
                            archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                            break;
                        case "F3":
                                archivointermedio[renglon][1] = "3";
                                cp = Convert.ToInt32(cps[renglon - 1], 16);
                                cp += 3;
                                cps[renglon]= cp.ToString("X4");
                                archivointermedio[renglon][2] = cps[renglon-1].ToString();
                            break;
                    }
                }
                else
                {
                    evaluainstr =directivaevalua(archivointermedio[renglon][4].ToString());

                    if (evaluainstr != "")
                    {
                        cps.Add("");
                        switch (evaluainstr)
                        {
                            case "WORD":
                                cp = Convert.ToInt32(cps[renglon - 1], 16);
                                cp += 3;
                                cps[renglon] = cp.ToString("X4");
                                archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                break;

                            case "BYTE":
                                if (archivointermedio[renglon][5].ToString()[0] == 'X')
                                {
                                    int num = 0;
                                    //string[] lista = this.l.Split(' ');
                                    //string v = lista[lista.Length - 1];
                                    string v = archivointermedio[renglon][5].ToString();
                                    v = v.Replace("'", "");
                                    char[] c = v.ToCharArray();
                                    if (c.Length % 2 == 0)
                                        num = c.Length / 2;
                                    else
                                        num = (c.Length + 1) / 2;

                                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                                    cp += num;
                                    cps[renglon] = cp.ToString("X4");
                                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                    break;
                                }
                                else
                                {
                                   if(archivointermedio[renglon][5].ToString()[0] == 'C')
                                   {
                                        //formatos[reng] = "C";
                                        //string[] list = this.l.Split(' ');
                                        //string val = list[list.Length - 1];
                                        string val = archivointermedio[renglon][5].ToString();
                                        val = val.Replace("'", "");
                                        char[] car = val.ToCharArray();
                                        int numero = car.Length;

                                        cp = Convert.ToInt32(cps[renglon - 1], 16);
                                        cp += numero-1;
                                        cps[renglon] = cp.ToString("X4");
                                        archivointermedio[renglon][2] = cps[renglon - 1].ToString();
              
                                    }
                                }

                                break;

                            case "RESB":

                                //formatos[reng] = "RB";
                                string va = archivointermedio[renglon][5].ToString();

                                //string[] li = this.l.Split(' ');
                                //string va = li[li.Length - 1];
                                if (va.Contains("H"))
                                {
                                    va = va.Replace("H", "");
                                    int n = Convert.ToInt32(va, 16);
                                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                                    cp += n;
                                    cps[renglon] = cp.ToString("X4");
                                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                }
                                else
                                {
                                    int n = Convert.ToInt32(va);
                                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                                    cp += n;
                                    cps[renglon] = cp.ToString("X4");
                                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                }

                                break;

                            case "RESW":
                                valu = archivointermedio[renglon][5].ToString();
                                if (valu.Contains("H"))
                                {
                                    valu = valu.Replace("H", "");
                                    int n = Convert.ToInt32(valu, 16);
                                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                                    cp += n*3;
                                    cps[renglon] = cp.ToString("X4");
                                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                }
                                else
                                {
                                    int n = Convert.ToInt32(valu);
                                    cp = Convert.ToInt32(cps[renglon - 1], 16);
                                    cp += n*3;
                                    cps[renglon] = cp.ToString("X4");
                                    archivointermedio[renglon][2] = cps[renglon - 1].ToString();
                                }
                                break;

                            case "BASE"://NO AUMENTA EL CP, POR LO TANTO EL CP PASA A SER EL MISMO QUE EL DE LA LINEA ANTERIOR
                                cps[renglon] = cps[renglon-1];
                                archivointermedio[renglon][2] = cps[renglon];
                                break;
                            case "EQU"://NO AUMENTA EL CP, POR LO TANTO EL CP PASA A SER EL MISMO QUE EL DE LA LINEA ANTERIOR
                                cps[renglon] = cps[renglon - 1];
                                archivointermedio[renglon][2] = cps[renglon];
                                break;
                            case "END"://NO AUMENTA EL CP, POR LO TANTO EL CP PASA A SER EL MISMO QUE EL DE LA LINEA ANTERIOR
                                cps[renglon] = cps[renglon - 1];
                                archivointermedio[renglon][2] = cps[renglon];
                                break;
                        }
                    }
                    else
                    {//CUANDO HAY ERROR LEXICO
                        cps.Add("");
                        cps[renglon] = cps[renglon - 1];
                        archivointermedio[renglon][2] = cps[renglon];
                    }
                }
            }

        }
        #endregion

        #region AÑADEMODO
        public void identificaMododir(List<List<string>> archivointermedio, string lineacodigo, int renglon, List<string> modosdir)
        {
            string formato = archivointermedio[renglon][1].ToString();
            string rsubcaso = archivointermedio[renglon][4].ToString();
            int bandera = 0;

            if (formato == "3" || formato == "4")
            {
                if (rsubcaso != "RSUB" && rsubcaso != "rsub")
                {
                    char operandomodo = archivointermedio[renglon][5].ToString()[0];

                    switch (operandomodo)
                    {
                        case '#':
                            archivointermedio[renglon][6] = "INMEDIATO";
                            bandera = 1;
                            break;
                        case '@':
                            archivointermedio[renglon][6] = "INDIRECTO";
                            bandera = 1;
                            break;
                    }
                    if (bandera == 0)
                    {
                        archivointermedio[renglon][6] = "SIMPLE";
                    }
                }
            }

        }
        #endregion

        #region CREATABSIM
        public void añadeatabsim(List<List<string>> archivointermedio,int renglon, List<List<string>> tabsim,int simbreng)
        {
            string simbolo = archivointermedio[renglon][3].ToString();
            List<string> nuevoRenglon = new List<string>();

            bool simboloEncontrado = false;//VARIABLE PARA ENCONTRAR EL SIMBOLO EN TABSIM
            bool error = false;

            //SI EL SIMBOLO VIENE DE UNA INSTRUCCION EQU
            if(archivointermedio[renglon][4].ToString()=="EQU")
            {
                string expresion = archivointermedio[renglon][5].ToString();
                error=identificaelementosexpresion(archivointermedio, renglon, tabsim, simbolosreng,simbolo,expresion);

                if(error==true)//ERROR EXPRESION INVALIDA
                {
                    //---INSERTA SIMBOLO PERO CON FFFF COMO ERROR Y DE TIPO ABSOLUTO---

                    tabsim.Add(nuevoRenglon);//AÑADE UN NUEVO RENGLÓN
                    simbolosreng++;//AUMENTA EL INDICE DEL RENGLÓN
                    tabsim[simbolosreng - 1].Add(simbolo);//AÑADE EL SIMBOLO AL RENGLÓN
                    tabsim[simbolosreng - 1].Add("FFFF");//JUNTO CON SU CP
                    tabsim[simbolosreng - 1].Add("A");//Y EL TIPO DE LA EXPRESION
                    archivointermedio[renglon][8] = "ERROR: Expresion invalida"; 
                    return;
                }
            }

                if (tabsim.Count > 0)//SI YA EXISTEN ELEMENTOS EN TABSIM...ENCUENTRALO PARA NO INSERTAR REPETIDO
                {
                    simboloEncontrado=buscatabsimsim(simbolo, simboloEncontrado, tabsim);
                }
                else
                {
                    if (!simboloEncontrado || tabsim.Count==0)//SI NO ESTÁ REPETIDO O NO EXISTE INSERTA EL INDICE
                    {
                        tabsim.Add(nuevoRenglon);//AÑADE UN NUEVO RENGLÓN
                        simbolosreng++;//AUMENTA EL INDICE DEL RENGLÓN
                        tabsim[simbolosreng - 1].Add(simbolo);//AÑADE EL SIMBOLO AL RENGLÓN
                        tabsim[simbolosreng - 1].Add(archivointermedio[renglon][2]);//JUNTO CON SU CP
                        tabsim[simbolosreng - 1].Add("A");//Y EL TIPO DE LA EXPRESION
                        return;
                    }
                }
                tabsim.Add(nuevoRenglon);
                simbolosreng++;
                tabsim[simbolosreng - 1].Add(simbolo);
                tabsim[simbolosreng - 1].Add(archivointermedio[renglon][2]);
                tabsim[simbolosreng - 1].Add("A");//Y EL TIPO DE LA EXPRESION

        }
        #endregion

        public bool buscatabsimsim(string simbolo,bool simboloEncontrado,List<List<string>> tabsim)
        {
            foreach (List<string> sublista in tabsim)//VA A BUSCAR SIMBOLO EN TABSIM
            {
                if (sublista[0] == simbolo)//SI LO ENCUENTRA
                {
                    return simboloEncontrado = true;//AVISA QUE LO ENCONTRASTE
                }
            }
            simboloEncontrado = false;//SI DESPUES DE BUSCARLO NO REGRESAMOS, ENTONCES NO LO ENCONTRAMOS :´(
            return simboloEncontrado;
        }

            public bool identificaelementosexpresion(List<List<string>> archivointermedio, int renglon, List<List<string>> tabsim, int simbreng,string simbolo,string expresion)
            {
            bool simboloEncontrado = false;
            string operadoresaignorar = @"[\(\)\+\-\*\/]";
            string[] elementos = Regex.Split(expresion, operadoresaignorar);
            bool error = false;
            List<string> listaabsyrel = new List<string>();

            foreach (string elemento in elementos)
            {
                if (EsNumero(elemento))//SI ES UN NUMERO...
                {
                    listaabsyrel.Add(elemento);
                    listaabsyrel.Add("A");
                }
                else//SI ES UN SIMBOLO...
                {
                    if (tabsim.Count > 0)
                    {
                        simboloEncontrado = buscatabsimsim(simbolo, simboloEncontrado, tabsim);
                    }
                    else//SI TABSIM ESTÁ VACIO, ENTONCES YA NO ANALICES MAS Y REGRESA ERROR
                    {
                        return error = true;
                    }
 
                }
            }
            return error = false;
        }

        static bool EsNumero(string s)
        {
            double numero;
            return double.TryParse(s, out numero);//CONVIERTE LA CADENA EN UN NUMERO, SI TIENE EXITO DEVULEVE TRUE
        }

        #region BIBLIOTECAS DE INSTRUCCIONES Y DIRECTIVAS

        #region DIRECTIVAS
        public string directivaevalua(string s)
        {
            string evaluacion = "";
            if (s == "WORD")
            {
                evaluacion = "WORD";
                return evaluacion;
            }
            if (s == "BYTE")
            {
                evaluacion = "BYTE";
                return evaluacion;
            }
            if (s == "RESB")
            {
                evaluacion = "RESB";
                return evaluacion;
            }
            if (s == "RESW")
            {
                evaluacion = "RESW";
                return evaluacion;
            }
            if (s == "BASE")
            {
                evaluacion = "BASE";
                return evaluacion;
            }
            if (s == "END")
            {
                evaluacion = "END";
                return evaluacion;
            }
            if (s == "EQU")
            {
                evaluacion = "END";
                return evaluacion;
            }
            return evaluacion;
        }
        #endregion

        #region INSTRUCCIONES

        #region EVALUA INSTRUCCIONES
        public string instruccionesevalua(string s)
        {
            string evaluacion = "";

            evaluacion = evaluaf1(s);

            if (evaluacion == "")
            {
                evaluacion = evaluaf2(s);
            }

            if (evaluacion == "")
            {
                evaluacion = evaluaf3(s);
            }

            return evaluacion;
        }

        #endregion

        #region INSTRUCCIONES FORMATO 1
        public string evaluaf1(string s)
        {
            string evaluacion = "";
            if (s == "FIX")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            if (s == "FLOAT")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            if (s == "HIO")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            if (s == "NORM")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            if (s == "SIO")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            if (s == "TIO")
            {
                evaluacion = "F1";
                return evaluacion;
            }
            return evaluacion;
        }
        #endregion

        #region INSTRUCCIONES FORMATO 2
        public string evaluaf2(string s)
        {
            string evaluacion = "";
            if (s == "ADDR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "CLEAR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "COMPR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "DIVR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "MULR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "RMO")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "SHIFTL")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "SHIFTR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "SUBR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "SVC")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            if (s == "TIXR")
            {
                evaluacion = "F2";
                return evaluacion;
            }
            return evaluacion;
        }
        #endregion

        #region INSTRUCCIONES FORMATO 3
        public string evaluaf3(string s)
        {
            string evaluacion = "";
            if (s == "ADD")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "ADDF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "AND")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "COMP")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "COMPF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "DIV")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "DIVF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "J")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "JEQ")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "JGT")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "JLT")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "JSUB")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDA")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDB")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDCH")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDL")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDS")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDT")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LDX")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "LPS")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "MUL")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "MULF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "OR")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "RD")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "RSUB")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "SSK")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STA")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STB")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STCH")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STI")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STL")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STS")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STT")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "STX")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "SUB")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "SUBF")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "TD")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "TIX")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            if (s == "WD")
            {
                evaluacion = "F3";
                return evaluacion;
            }
            return evaluacion;
        }
        #endregion

        #endregion

        #endregion


    }



}
