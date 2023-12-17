using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Icnea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = "";
            string opcion = "";
            bool seguir = false;
            bool end = false;
            int resultado = 0;
            int numero = 0;
            List<int> listaNumeros = new List<int>();
            bool resultadoValido = false;
            bool numeroValido = false;
            bool cadenaValida = false;
            int cantidadNumeros = 0;
            int contador = 0;

            while (!end)
            {
                if (opcion == "" && !seguir)
                {
                    seguir = false;
                    Console.Clear();
                    Console.WriteLine("########################################");
                    Console.WriteLine("################ MENU ##################");
                    Console.WriteLine("########################################");
                    Console.WriteLine("\n");
                    Console.WriteLine("##  1.Convertidor ASCII");
                    Console.WriteLine("##  2.Permutaciones");
                    Console.WriteLine("##  3.Sumas pequeñas");
                    Console.WriteLine("##  4.Salir");
                    Console.WriteLine("\n\nElige una opción..");
                    opcion = Console.ReadLine();
                }
                

                while (opcion == "1" || seguir)
                {

                    Console.Clear();
                    Console.WriteLine("#####################################");
                    Console.WriteLine("#########  Convertidor ASCII ########");
                    Console.WriteLine("#####################################");
                    Console.WriteLine("\n\n");
                    //COMPRUEBO QUE LA CADENA INTRODUCIDA SEA VÁLIDA
                    while (!cadenaValida)
                    {
                        try
                        {
                            Console.WriteLine("Dame una cadena..");
                            cadena = Console.ReadLine();
                            foreach (var item in cadena)
                            {
                                int.Parse(item.ToString());
                            }
                            cadenaValida = true;
                        }
                        catch
                        {
                            cadenaValida = false;
                            Console.WriteLine("Eso no es una cadena válida, contiene caracteres no numéricos...");
                        }

                    }


                    //LLAMO A LA FUNCION PASANDOLE LA CADENA
                    convertirAscii(cadena);

                    cadenaValida = false;
                    opcion = "";
                    seguir = false;

                    Console.WriteLine("\n\nSeguir probando?..(s/Cualquier tecla)");

                    if (Console.ReadLine() == "s") seguir = true;

                }
                while (opcion == "2" || seguir)
                {
                    Console.Clear();
                    Console.WriteLine("####################################");
                    Console.WriteLine("##########  Permutaciones ##########");
                    Console.WriteLine("####################################");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Dame una cadena..");
                    cadena = Console.ReadLine();

                    Permutaciones(cadena);

                    opcion = "";
                    seguir = false;

                    Console.WriteLine("\n\nSeguir probando?..(s/Cualquier tecla)");
                    if (Console.ReadLine() == "s") seguir = true;
                }
                while (opcion == "3" || seguir)
                {
                    opcion = "";
                    Console.Clear();
                    Console.WriteLine("####################################");
                    Console.WriteLine("######### Sumas pequeñas ###########");
                    Console.WriteLine("####################################");
                    Console.WriteLine("\n\n");

                    //VOY PIDIENDO TODOS LOS DATOS Y VERIFICANDO QUE SEAN VALIDOS
                    while (!resultadoValido)
                    {
                        try
                        {
                            Console.WriteLine("Dame un número para el resultado..");
                            resultado = int.Parse(Console.ReadLine());
                            resultadoValido = true;
                        }
                        catch
                        {
                            Console.WriteLine("Eso no es un número válido...");
                            resultadoValido = false;
                        }
                    }

                    while (!numeroValido)
                    {
                        try
                        {
                            Console.WriteLine("Cuantos números quieres introducir? (min.3 núm.)..");
                            cantidadNumeros = int.Parse(Console.ReadLine());
                            numeroValido = true;
                            if(cantidadNumeros < 3)
                            {
                                Console.WriteLine("La cantidad de números min. es 3...");
                                numeroValido = false;
                            }
                            else
                            {
                                Console.WriteLine($"\nDebes introducir {cantidadNumeros} números válidos..");
                            }
                            
                        }
                        catch
                        {
                            Console.WriteLine("Eso no es una cantidad válida...");
                            numeroValido = false;
                        }
                    }

                    numeroValido = false;

                    while (!numeroValido || contador < cantidadNumeros)
                    {
                        try
                        {
                            Console.WriteLine($"\nDame el número {contador + 1}..");
                            numero = int.Parse(Console.ReadLine());
                            numeroValido = true;
                            listaNumeros.Add(numero);
                            contador++;
                        }
                        catch
                        {
                            Console.WriteLine("Eso no es un número válido...");
                            numeroValido = false;
                        }
                    }

                    //SACO EN PANTALLA EL RESULTADO DE LOS DATOS INTRODUCIDOS
                    Console.WriteLine("\n#################################");
                    Console.WriteLine($"Número para el resultado: {resultado}");
                    Console.WriteLine($"Números válidos introducidos: {cantidadNumeros}");
                    string texto = "Números introducidos: ";
                    texto += string.Join(", ", listaNumeros);
                    Console.WriteLine(texto);
                    Console.WriteLine("#################################");

                    //PASO A LA FUNCION EL RESULTADDO A OBTENER Y LA LISTA DE NUMEROS INTRODUCIDOS PARA HACER LAS SUMAS
                    Sumas(resultado, listaNumeros);

                    //INICIALIZO VARIAS VARIABLES EN CASO DE QUE SE QUIERAN HACER MAS INTENTOS
                    contador = 0;
                    numero = 0;
                    resultado = 0;
                    cantidadNumeros = 0;
                    numeroValido = false;
                    listaNumeros.Clear();
                    resultadoValido = false;
                    opcion = "";
                    seguir = false;

                    Console.WriteLine("\n\nSeguir probando?..(s/cualquier tecla)");
                    if (Console.ReadLine() == "s") seguir = true;
                }

                if (opcion == "4")
                {
                    end = true;
                }
            }
            return;
        }

        private static void convertirAscii(string frase1)
        {
            string numero = "0";
            string numeroT = "";
            string texto = "";

            List<byte> listaNumeros = new List<byte>();

            //RECORRO LA CADENA HACIENDO CODIGOS DE 3 DIGITOS Y HACIENDO LAS COMPROBACIONES, UTILIZO LA VARIABLE numero Y EN CUANTO PASA LAS VALIDACIONES LO AÑANDO AL LIST
            for (int i = 0; i < frase1.Length; i++)
            {
                if (numero == "")
                {
                    numero = "0";
                }

                //COMPRUEBO QUE EL NUMERO ALMACENADO SEA MENOR DE 255 Y QUE TENGA UN MAX. DE 3 DIGITOS
                if (int.Parse(numero) < 255 && numero.Length <= 3)
                {
                    if (numero == "0")
                    {
                        numero = "";
                    }
                    numeroT = numero;
                    numero += frase1[i];

                    //UTILIZO UNA VARIABLE AUX. numeroT PARA COMPROBAR SI SOBREPASA EL 255 EL NUMERO RECIEN MODIFICADO, TENGO QUE COMPROBAR ANTES Y DESPUES QUE EL CODIGO DE 3 DIGITOS NO SOBREPASE LOS 255,
                    //EN ESE CASO AÑADO EL numeroT, Y GUARDO EN numero EL DIGITO EN EL QUE ESTA EL BUCLE
                    if (int.Parse(numero) > 255)
                    {
                        texto += numeroT + " ";
                        listaNumeros.Add(byte.Parse(numeroT));
                        numero = "";
                        numero += frase1[i];
                    }

                    //CUANDO LLEGA AL FINAL DE LA CADENA LO COMPRUEBO PARA AÑANDIR LOS DIGITOS QUE FALTAN AL LA LIST
                    if (i == frase1.Length - 1)
                    {
                        texto += numero + " ";
                        listaNumeros.Add(byte.Parse(numero));
                        numero = "";

                    }
                }
                else
                {
                    texto += numero + " ";
                    listaNumeros.Add(byte.Parse(numero));
                    numero = "";
                    numero += frase1[i];
                }

            }

            //CONVIERTO LA LIST EN UN ARRAY DE BYTES Y OBTENGO EL STRING RESULTANTE A PARTIR DE ESE ARRAY
            byte[] arrayBytes = listaNumeros.ToArray();
            var text = System.Text.Encoding.ASCII.GetString(arrayBytes);
            Console.WriteLine(text);
        }

        private static void Permutaciones(string cadena)
        {
            string palabra = "";
            int contadorR2d2 = 0;
            int contadorC3po = 0;
            int contadorTotal = 0;
            int permutaciones = 0;

            Console.WriteLine("\r\n");
            cadena = cadena.ToLower();
            if (!cadena.Contains("r2d2") || !cadena.Contains("c3po"))
            {
                Console.WriteLine("La cadena debe contener las palabras R2d2 y C3po...");
                Console.Write("Permutaciones: 0");
            }
            else //BUSCO LA PALABRA R2D2 Y LUEGO LA PALABRA C3PO Y VOY AUMENTANDO LOS CONTADORES
            {
                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].Equals('r') && palabra == "")
                    {
                        palabra += cadena[i];
                        continue;
                    }

                    else if (cadena[i].Equals('2') && palabra == "r")
                    {
                        palabra += cadena[i];
                        continue;
                    }


                    else if (cadena[i].Equals('d') && palabra == "r2")
                    {
                        palabra += cadena[i];
                        continue;
                    }


                    else if (cadena[i].Equals('2') && palabra == "r2d")
                    {
                        palabra += cadena[i];
                        palabra = "";
                        contadorR2d2 += 1;
                        continue;

                    }
                    else
                    {
                        palabra = "";
                    }
                }

                for (int i = 0; i < cadena.Length; i++)
                {
                    if (cadena[i].Equals('c') && palabra == "")
                    {
                        palabra += cadena[i];
                        continue;
                    }

                    else if (cadena[i].Equals('3') && palabra == "c")
                    {
                        palabra += cadena[i];
                        continue;
                    }


                    else if (cadena[i].Equals('p') && palabra == "c3")
                    {
                        palabra += cadena[i];
                        continue;
                    }


                    else if (cadena[i].Equals('o') && palabra == "c3p")
                    {
                        palabra += cadena[i];
                        palabra = "";
                        contadorC3po += 1;
                        continue;

                    }
                    else
                    {
                        palabra = "";
                    }
                }

                Console.WriteLine("Ocurrencias R2d2: " + contadorR2d2);
                Console.WriteLine("Ocurrencias C3po: " + contadorC3po);

                contadorTotal = contadorR2d2 + contadorC3po;

                if (contadorR2d2 != contadorC3po)//SOLO DOY POR VALIDO QUE AMOBS CONTADORES SEAN IGUALES SINO LOS IGUALO AL QUE TENGA MENOS OCURRENCIAS, MANTENIENDO ASÍ QUE ES OBLIGATORIO QUE EXISTAN POR IGUAL LAS PALABRAS
                                                 //R2D2 Y C3PO, ASI LO HE INTERPRETADO YO VIENDO EL EJERCICIO 
                {
                    if (contadorR2d2 < contadorC3po)
                    {
                        contadorC3po = contadorR2d2;
                        contadorTotal = contadorR2d2 + contadorC3po;
                    }
                    else
                    {
                        contadorR2d2 = contadorC3po;
                        contadorTotal = contadorR2d2 + contadorC3po;
                    }

                    //FACTORIAL DEL NUMERO DE APARACIONES DE LAS DOS PALABRAS QUE AUNQUE SEAN IGUALES SE PODRIAN COMBINAR EN EL RESULTADO DEL FACTORIAL, EN CASO DE QUE NO HAYA LA MISMA CANTIAD DE R2D2 Y DE C3PO, RESTO UNO
                    //PARA MANTENER LA CONDICION DE QUE DEBEN APARECER LAS DOS PALABRAS

                    permutaciones = contadorTotal;
                    do
                    {
                        contadorTotal -= 1;
                        permutaciones *= contadorTotal;
                    }
                    while (contadorTotal > 1);

                    Console.WriteLine("La cadena suministrada no contiene la misma cantidad de veces las palabra R2d2 y C3po...");
                    Console.WriteLine($"Permutaciones: {permutaciones}, hay {permutaciones} formas de combinar las palabras R2d2 y C3po de posición, aunque sean iguales..");
                }
                else
                {
                    //FACTORIAL DEL NUMERO DE APARACIONES DE LAS DOS PALABRAS QUE AUNQUE SEAN IGUALES SE PODRIAN COMBINAR EN EL RESULTADO DEL FACTORIAL
                    permutaciones = contadorTotal;
                    do
                    {
                        contadorTotal -= 1;
                        permutaciones *= contadorTotal;
                    }
                    while (contadorTotal > 1);

                    Console.WriteLine("La cadena suministrada contiene la misma cantidad de veces las palabra R2d2 y C3po...");
                    Console.WriteLine($"Permutaciones: {permutaciones}");
                }
            }
        }

        private static void Sumas(int resultado, List<int> listaNumeros)
        {
            int suma = 0;
            int sumasValidas = 0;
            string texto = "";
            string textoResultado = "";
            List<int> sumables = new List<int>();
            List<int> noSuumables = new List<int>();
            List<int> NumerosNoValidos = new List<int>();

            //RECORRO LA LISTA DE NUMEROS PROPORCIONADOS CON 3 ARRAYS, UNO POR NUMERO A SUMAR, Y COMPRUEBO QUE NO SE REPITAN LOS NUMEROS EN LA SUMA EN LOS DIFERENTES BUCLES. 
            //SI LA SUMA ES MENOR QUE EL REESULTADO PROPORCIONADO AGREGO LOS NUMEROS A UNA LIST LLAMADA SUMABLES, EN CASO DE QUE LA SUMA NO CUMPLA LA CONDICION AGREGO LOS NUMEROS A LA LIST NOSUMABLES,
            //ALGUNO DE ELLOS HA PROVOCADO QUE LA SUMA SEA MAYOR QUE EL RESULTADO
            
            for (int i = 0; i < listaNumeros.Count; i++)
            {
                for (int j = 0; j < listaNumeros.Count; j++)
                {
                    if (j == i) continue;

                    for (int k = 0; k < listaNumeros.Count; k++)
                    {
                        if (k == i) continue;
                        if (k == j) continue;

                        suma = listaNumeros[i] + listaNumeros[j] + listaNumeros[k];

                        if (suma < resultado)
                        {
                            sumasValidas++;

                            sumables.Add(listaNumeros[i]);
                            sumables.Add(listaNumeros[j]);
                            sumables.Add(listaNumeros[k]);
                        }
                        else
                        {
                            noSuumables.Add(listaNumeros[i]);
                            noSuumables.Add(listaNumeros[j]);
                            noSuumables.Add(listaNumeros[k]);
                        }
                    }
                }
            }
            //COMPARO AMBAS LISTAS BUSCANDO AQUELLOS NUMEROS QUE ESTEN EN NOSUMABLES (POR CULPA DE ALGUNO DE ELLOS HA FALLADO LA SUMA) PERO QUE NO ESTEN EN SUMABLES Y LOS AÑADO A OTRA LISTA LLAMADA NUMEROSNOVALIDOS.
            foreach (var item in noSuumables)
            {
                if (!sumables.Contains(item) && !NumerosNoValidos.Contains(item))
                {
                    NumerosNoValidos.Add(item);
                }
            }

            Console.WriteLine("\n#################################");

            Console.WriteLine($"Número para el resultado: {resultado}");

            texto = "Números introducidos: ";
            texto += string.Join(", ", listaNumeros);
            Console.WriteLine(texto);

            Console.WriteLine($"Sumas válidas menores que {resultado}: {sumasValidas}");

            textoResultado = "Números no válidos: ";
            textoResultado += string.Join("   ", NumerosNoValidos);
            Console.WriteLine(textoResultado);

            Console.WriteLine("#################################");

        }
    }
}

