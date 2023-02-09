using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        public static void LinqStrings()
        {
            string[] autos =
            {
                "VW Gol",
                "VW Golf",
                "Fiat Punto",
                "Audi A3",
                "Audi A5",
                "Seat Ibiza",
                "Seat León"
            };

            //1. SELECT de todos los autos

            var listaAutos = from auto in autos select auto;

            foreach (var auto in listaAutos)
            {
                Console.WriteLine(auto);
            }

            //2. SELECT de todos los audis

            var listaAudis =
                from auto in autos
                where auto.Contains("Audi")
                select auto;

            foreach (var auto in listaAudis)
            {
                Console.WriteLine(auto);
            }

        }
        public static void LinqNumeros()
        {
            List<int> numeros = new List<int>
            {
                1,2,3,4,5,6,7,8,9
            };

            //Cada numero multiplicado x 3
            //Tomar todos los numero menos el 9
            //Ordenar de manera ascendente

            var numerosProcesados = numeros
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num);
        }
        public static void EjmploBusqueda()
        {
            List<string> listaTexto = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            //Encontrar el primer elemento
            var primero = listaTexto.First();

            //Encontrar el primero elemento que sea "c" 
            var primerC = listaTexto.First(texto => texto.Equals("c"));

            //Encontrar el primer elemento que contenga "j"
            var primerConJ = listaTexto.First(texto => texto.Contains("j"));

            //Encontrar el primer elemento que contenga "z" default
            var primerConZODefault = listaTexto
                .FirstOrDefault(texto => texto.Contains("z")); // "" (vacio) o primer elemento con "z"
            //Encontrar el ultimo elemento que contenga "z" default
            var ultimoConZODefault = listaTexto
                .LastOrDefault(texto => texto.Contains("z")); // "" (vacio) o ultimo elemento con "z"
            //Evitar elementos repetidos
            var textoUnico = listaTexto.Single();
            var textoUnicoODefault = listaTexto.SingleOrDefault();

            int[] pares = { 0, 2, 4, 6, 8 };
            int[] otrosPares = { 0, 2, 6 };

            //Seleccionar todo los numeros que esten en pares y no en otrosPares
            var misPares = pares.Except(otrosPares); //Devuelve { 4, 8}
        }
        public static void SelectsMultiples()
        {
            string[] opiniones =
            {
                "Opinion 1, Texto 1",
                "Opinion 2, Texto 2",
                "Opinion 3, Texto 3"
            };

            var misOpiniones = opiniones.SelectMany(opinion => opinion.Split(","));

            var empresas = new[]
            {
                new Empresa()
                {
                    Id = 1,
                    Nombre = "Empresa 1",
                    Empleados = new[]
                    {
                        new Empleado()
                        {
                            Id = 1,
                            Nombre = "Juan",
                            Email = "juan@mail.com",
                            Salario = 22000
                        },
                        new Empleado()
                        {
                            Id = 2,
                            Nombre = "Marta",
                            Email = "marta@mail.com",
                            Salario = 22500
                        },
                        new Empleado()
                        {
                            Id = 3,
                            Nombre = "Sandra",
                            Email = "sandra@mail.com",
                            Salario = 21000
                        }
                    }
                },
                new Empresa()
                {
                    Id = 2,
                    Nombre = "Empresa 2",
                    Empleados = new[]
                    {
                        new Empleado()
                        {
                            Id = 4,
                            Nombre = "Miguel",
                            Email = "miguel@mail.com",
                            Salario = 30000
                        },
                        new Empleado()
                        {
                            Id = 5,
                            Nombre = "Jose",
                            Email = "jose@mail.com",
                            Salario = 22500
                        },
                        new Empleado()
                        {
                            Id = 6,
                            Nombre = "Viviana",
                            Email = "vivi@mail.com",
                            Salario = 29000
                        }
                    }
                }
            };

            //Obtener todos los empleados de todas las empresas
            var empleadosGlobal = empresas.SelectMany(empresa => empresa.Empleados);

            //Comprobar si alguna lista esta vacia
            bool hayEmpresas = empresas.Any();

            bool hayEmpleados = empresas.Any(empresa => empresa.Empleados.Any());

            //Todas las empresas que tengas empleado que ganen mas de 25000 pesos

            var resultado = empresas
                .Select(empresa => empresa.Empleados
                .Where(empleado => empleado.Salario >= 25000));

        }
        public static void linqCollections()
        {
            var primeraLista = new List<string> { "a", "b", "c" };
            var segundaLista = new List<string> { "a", "c", "d" };

            //INNER JOIN 

            var resultadoEnComun =
                from elemento in primeraLista
                join segundoElemento in segundaLista
                on elemento equals segundoElemento
                select new { elemento, segundoElemento };

            var resultadoEnComun2 = primeraLista.Join(
                segundaLista,
                elemento => elemento,
                segundoElemento => segundoElemento,
                (elemento, segundoElemento) => new { elemento, segundoElemento }
                );

            //OUTER JOI - LEFT 
            var leftOuterJoin =
                from elemento in primeraLista
                join segundoElemento in segundaLista
                on elemento equals segundoElemento
                into listaTemporal
                from elementoTemporal in listaTemporal.DefaultIfEmpty()
                where elemento != elementoTemporal
                select new { Elemento = elemento };

            //OUTER JOI - RIGHT 
            var rightOuterJoin =
                from segundoElemento in segundaLista
                join elemento in primeraLista
                on segundoElemento equals elemento
                into listaTemporal
                from elementoTemporal in listaTemporal.DefaultIfEmpty()
                where segundoElemento != elementoTemporal
                select new { Elemento = segundoElemento };

            //Una manera mas corta
            var leftOuterJoin2 =
                from elemento in primeraLista
                from segundoElemento in segundaLista
                .Where(s => s == elemento).DefaultIfEmpty()
                select new { Elemento = elemento, SegundoElemento = segundoElemento };

            //UNION 
            var unionList = leftOuterJoin.Union(rightOuterJoin);



        }
        public static void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            //Saltarse los primeros dos valores
            var skipTwoFirstValues = myList.Skip(2); // {3,4,5,6,7,8,9,10}

            //Saltarse los ultimos dos valores 
            var skipTwoLastValues = myList.SkipLast(2); //{1,2,3,4,5,6,7,8}

            //Saltar valores por condicion 
            var skipWhile = myList.SkipWhile(num => num < 4); //{4,5,6,7,8,9,10}

            //Tomar los primeros dos valores
            var takeFirstTwo = myList.Take(2); //{1,2}

            //Tomar los ultimos dos valores 
            var takeTwoLastValues = myList.TakeLast(2); //{9,10}

            //Tomar valores por condicion
            var takeWhile = myList.TakeWhile(num => num < 4); //{1,2,3}
        }

        //Paginacion con skip y take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        //Variables en consultas LinQ
        static void LinqVariables()
        {
            int[] numeros =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            var aboveAverage =
                from numero in numeros
                let promedio = numeros.Average()
                let numeroCuadrado = Math.Pow(numero, 2)
                where numeroCuadrado > promedio
                select numero;
        }

        //Zip
        public static void ZipLinQ()
        {
            int[] numeros =
            {
                1, 2, 3, 4, 5
            };
            string[] stringNumeros =
            {
                "uno", "dos", "tres", "cuatro", "cinco"
            };
            IEnumerable<string> zipNumeros = numeros.Zip(stringNumeros, (numero, palabra)
                => numero + " = " + palabra);
        }
        //Range & Repeat
        public static void repeatRangeLinQ()
        {
            //Generar una coleccion de 1 a 1000 --> Range 
            var first1000 = Enumerable.Range(1, 1000);

            //Repetir un valor n cantidad de veces
            var fiveXs = Enumerable.Repeat("X", 5);
        }
        //All
        public static void allLinQ()
        {
            var numeros = new List<int>
            {
                1, 2, 3, 4, 5
            };
            bool allAreSmallerThan10 = numeros.All(x => x < 10); //true
            bool allAreMultipliesOf2 = numeros.All(x => x % 2 == 0); //false
        }

        //Agregacion 
        public static void aggregateQueries()
        {
            int[] numeros = 
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            int sum = numeros.Aggregate((previo, actual) => previo + actual);
        }
        //Distinct
        static public void distinctValues()
        {
            int[] numeros =
            {
                1, 2, 3, 4, 5, 5, 4, 3, 2, 1
            };
            var distinctValues = numeros.Distinct();
        }
        //GroupBy
        static public void groupByExaples()
        {
            int[] numeros =
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
            //Separar los numeros pares e impares en grupos
            var grouped = numeros.GroupBy(x => x % 2 == 0);
            //El primer grupo es el que no cumple la condicion y el segundo el que si
        }
    }
}