using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using org.mariuszgromada.math.mxparser;
using Antlr4.Runtime;

namespace SICXE
{
    class CalculoExpresiones
    {
        List<string> listaabsyrel = new List<string>();
        List<string> cpstabsim = new List<string>();
        public CalculoExpresiones()
        {

        }

        public string analizaexpresion(List<string> listaabsyrel,string expresion)
        {
            string tipo = "";
            bool absoluto = false;
            //PRIMERO ANALIZAMOS SI TODOS SON ABSOLUTOS
            absoluto=absolutos(listaabsyrel);
            if (absoluto)
            {
                return tipo="A";
            }
            //OBTENEMOS EXPRESION CON VALORES ABS Y REL
            expresion = SustituirPalabras(expresion, listaabsyrel);
            string expresionSimplificada = SimplificarExpresion(expresion);
            string expresionatomicatipos = SimplificarExpresionatomica(expresionSimplificada);
            int conteo = ContarRConSignoSuma(expresionatomicatipos);
            if(conteo==1)
            {
                tipo = "R";
            }
            return tipo;

        }

        public bool absolutos(List<string> listaabsyrel)
        {
            bool absolutos = false;
            for (int i = 1; i < listaabsyrel.Count; i += 2)
            {
                if (listaabsyrel[i] != "A")
                {
                    return absolutos = false; // Si encontramos un elemento que no es "A", la expresión no es absoluta
                }
            }
            return absolutos=true;
        }

        static string SustituirPalabras(string expresion, List<string> listaabsyrel)
        {
            int contador = 0; // CONTADOR PARA CADA POSICION DE EXPRESION
            string expresionSinElementos = Regex.Replace(expresion, @"[a-zA-Z]+|\d+", match =>
            {
                // SE ELIMINAN TODAS LAS PALABRAS Y NUMEROS DE LA EXPRESION PARA ASI DEJARLA CON NUMEROS
                // QUE ES LO QUE HACE AQUI, SE REEMPLAZA CON EL CONTADOR 
                contador++;
                return contador.ToString();
            });

            //AQUI TENEMOS LA EXPRESION CON NUMEROS EN VEZ DE CON SUS PALABRAS
            for (int i = 1; i < listaabsyrel.Count; i += 2)
            {
                //SE REEMPLAZA EL NUMERO POR EL VALOR PAR (OSEA RELATIVO O ABSOLUTO) DE LA EXPRESION
                string numeroAReemplazar = (i / 2 + 1).ToString();
                expresionSinElementos = Regex.Replace(expresionSinElementos, @"\b" + numeroAReemplazar + @"\b", listaabsyrel[i]);
            }

            string expresioncontipos = expresionSinElementos;
            return expresioncontipos;//REGRESAMOS EXPRESION CON VALORES ABS Y REL
        }

        static bool EsNumero(string palabra)
        {
            return double.TryParse(palabra, out _);
        }

        static string SimplificarExpresion(string expresion)
        {
            string expresionSimplificada = expresion;

            // CASOS PARA SIMPLIFICAR
            expresionSimplificada = expresionSimplificada
                .Replace("-(-", "+")
                .Replace("-(-R-R", "+R+R")
                .Replace("-(+R-R", "-R+R")
                .Replace("-(+R+R", "-R-R")
                .Replace("+(-R-R", "-R-R")
                .Replace("+(+R-R", "+R-R")
                .Replace("+(-R+R", "-R+R")
                .Replace("-(-A-R", "+A+R")
                .Replace("-(+A-R", "-A+R")
                .Replace("-(+A+R", "-A-R")
                .Replace("+(-A-R", "-A-R")
                .Replace("+(+A-R", "+A-R")
                .Replace("+(-A+R", "-A+R")
                .Replace("-(-R-A", "+R+A")
                .Replace("-(+R-A", "-R+A")
                .Replace("-(+R+A", "-R-A")
                .Replace("+(-R-A", "-R-A")
                .Replace("+(+R-A", "+R-A")
                .Replace("+(-R+A", "-R+A");
                
            return expresionSimplificada;
        }

        static string SimplificarExpresionatomica(string expresion)
        {
            // REGLA "R-R" por "A"
            expresion = Regex.Replace(expresion, @"R-R", "A");
            expresion = Regex.Replace(expresion, @"-R+R", "A");
            return expresion;
        }

        static int ContarRConSignoSuma(string expresion)
        {
            // CUENTA LA CANTIDAD DE RELATIVOS POSITIVOS
            MatchCollection matches = Regex.Matches(expresion, @"\+R");
            return matches.Count;
        }

        public string SustituyeValoresExp(string expresion, List<string> cpstabsim)
        {
            expresion = acomodalaexpr(expresion);
            int contador = 0; // USA UN CONTADOR PARA LOS ELEMENTOS DE LA LISTA
                              //ESTA EXPRESION REGULAR REEMPLAZA CADA PALABRA DE LA EXPRESION POR SU CP QUE ESTÁ EN LA LISTA CPSTABSIM
            string expresionalgebraica = Regex.Replace(expresion, @"(?<![0-9])[a-zA-Z]+", match =>
            {
                // Reemplaza cada palabra por el elemento actual de la lista cpstabsim
                if (contador < cpstabsim.Count && !string.IsNullOrEmpty(cpstabsim[contador]))
                {
                    string elementoReemplazo = cpstabsim[contador];
                    contador++; // Incrementa el contador para el siguiente elemento
                    return elementoReemplazo;
                }
                return match.Value; // Si la lista se agota o el elemento es vacío, deja la palabra original
            });





            return expresionalgebraica;//REGRESAMOS EXPRESION CON VALORES ABS Y REL
        }

        public string acomodalaexpr(string expresion)
        {

            string expresionFormateada = Regex.Replace(expresion, @"\d+H|\d+", match =>
            {
                // Llama a la función formateanumero para formatear el número
                return formateanumero(match.Value);
            });


            return expresionFormateada;
        }

        public string formateanumero(string valor)
        {
            if (valor.Contains("H"))
            {
                valor = valor.Replace("H", "");
                int n = Convert.ToInt32(valor, 16);
                string valorhex = "";

                valorhex = n.ToString("X4");
                return valorhex;
            }
            else
            {
                int n = Convert.ToInt32(valor);
                string valordec = "";
                valordec = n.ToString("X4");
                return valordec;
            }
        }

        public string Evaluaexpresionalgebraica(string expresionalgebraica)
        {

             expresionalgebraica = Regex.Replace(expresionalgebraica, @"(?<![0-9])[0-9A-Fa-f]+", match =>
            {
                // Reemplaza cada número por su equivalente decimal
                string elementoReemplazo = ConvertHexToDecimal(match.Value);
                return elementoReemplazo;
            });

            AnalizadorExpresionesLexer lex = new AnalizadorExpresionesLexer(new AntlrInputStream(expresionalgebraica));
            CommonTokenStream tokens = new CommonTokenStream(lex);
            AnalizadorExpresionesParser parser = new AnalizadorExpresionesParser(tokens);

            var result = parser.compileUnit();

            // Obtén el valor de resultado de la expresión
            double value = result.value;

            //CONVIERTE A HEX UN VALOR
            string valorhex = ConvertToHex(value);

            return valorhex;//REGRESAMOS EXPRESION CON VALORES ABS Y REL
        }

        string ConvertHexToDecimal(string hexValue)
        {
            // CONVIERTE DE HEXADECIMAL A DECIMAL

            int decimalValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            return decimalValue.ToString();
        }

        string ConvertToHex(double value)
        {
            // CONVIERTE DE HEXADECIMAL A DECIMAL

            int n = Convert.ToInt32(value);
            string valorhex = "";
            valorhex = n.ToString("X4");

            return valorhex;
        }


    }
}
