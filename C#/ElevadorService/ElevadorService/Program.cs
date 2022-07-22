using ElevadorService.Clases;
using ElevadorService.Interface;
using ElevadorService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ElevadorService
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            Menu();           
        }

        static void Menu()
        {          
            var arquivoPath = @"C:\Projetos\ProvaAdmissionalApisul\C#\ElevadorService\ElevadorService\Json\input.json";
            var jsonData = File.ReadAllText(arquivoPath.ToString());
            List<Elevador> ElevadorList = JsonConvert.DeserializeObject<List<Elevador>>(jsonData);

            bool showMenu = true;
            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Administração prédio 99a da Tecnopuc \n\n");
                Console.WriteLine("Escolha uma opção: \n");
                Console.WriteLine("1) Andar menos utilizado pelos usuários");
                Console.WriteLine("2) Elevador mais frequentado e o período que se encontra maior fluxo");
                Console.WriteLine("3) Elevador menos frequentado e o período que se encontra menor fluxo");
                Console.WriteLine("4) Período de maior utilização do conjunto de elevadores");
                Console.WriteLine("5) Percentual de uso de cada elevador com relação a todos os serviços prestados");
                Console.WriteLine("6) Saída \n");
                Console.Write("\rSelecione uma opção: ");

                switch (Console.ReadLine())
                {                   
                    case "1":
                        Console.WriteLine("\n");
                        andarMenosUtilizado(ElevadorList);
                        showMenu = true;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("\n");
                        periodoMaiorFluxoElevadorMaisFrequentado(ElevadorList);
                        showMenu = true;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.WriteLine("\n");
                        periodoMenorFluxoElevadorMenosFrequentado(ElevadorList);
                        showMenu = true;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.WriteLine("\n");
                        periodoMaiorUtilizacaoConjuntoElevadores(ElevadorList);
                        showMenu = true;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadLine();
                        break;

                    case "5":
                        Console.WriteLine("\n");
                        percentualDeUsoElevadorA(ElevadorList);
                        percentualDeUsoElevadorB(ElevadorList);
                        percentualDeUsoElevadorC(ElevadorList);
                        percentualDeUsoElevadorD(ElevadorList);
                        percentualDeUsoElevadorE(ElevadorList);
                        showMenu = true;
                        Console.WriteLine("Pressione qualquer tecla para continuar");
                        Console.ReadLine();  
                        break;

                    case "6":
                        showMenu = false;
                        break;
                }               
            }
        }

        static void andarMenosUtilizado(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            List<int> andarMenosUtilizado = elevadorService.andarMenosUtilizado(ElevadorList);

            Console.WriteLine("Lista Andar(es) menos utilizado pelos usuários \n");

            foreach (var andar in andarMenosUtilizado)
            {
                var andarQtdeUso = ElevadorList.Where(E => E.andar == andar).ToList().Count.ToString();
                Console.WriteLine("Andar N° {0}. Quantidade de uso: {1}", andar, andarQtdeUso);
            }
            Console.WriteLine("\n");
        }

        static void percentualDeUsoElevadorA(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            float percentualDeUsoElevadorA = elevadorService.percentualDeUsoElevadorA(ElevadorList);
            var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == 'A').ToList().Count.ToString();

            Console.WriteLine("Percentual de uso do elevador A = {0:F2}. Quantidade de uso: {1} \n", percentualDeUsoElevadorA, elevadorQtdeUso);
        }

        static void percentualDeUsoElevadorB(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            float percentualDeUsoElevadorB = elevadorService.percentualDeUsoElevadorB(ElevadorList);
            var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == 'B').ToList().Count.ToString();

            Console.WriteLine("Percentual de uso do elevador B = {0:F2}. Quantidade de uso: {1} \n", percentualDeUsoElevadorB, elevadorQtdeUso);
        }
        static void percentualDeUsoElevadorC(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            float percentualDeUsoElevadorC = elevadorService.percentualDeUsoElevadorC(ElevadorList);
            var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == 'C').ToList().Count.ToString();

            Console.WriteLine("Percentual de uso do elevador C = {0:F2}. Quantidade de uso: {1}  \n", percentualDeUsoElevadorC, elevadorQtdeUso);
        }
        static void percentualDeUsoElevadorD(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            float percentualDeUsoElevadorD = elevadorService.percentualDeUsoElevadorD(ElevadorList);
            var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == 'D').ToList().Count.ToString();

            Console.WriteLine("Percentual de uso do elevador D = {0:F2}. Quantidade de uso: {1} \n", percentualDeUsoElevadorD, elevadorQtdeUso);
        }

        static void percentualDeUsoElevadorE(List<Elevador> ElevadorList)
        {
            ServiceElevador elevadorService = new ServiceElevador();
            float percentualDeUsoElevadorE = elevadorService.percentualDeUsoElevadorE(ElevadorList);
            var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == 'E').ToList().Count.ToString();

            Console.WriteLine("Percentual de uso do elevador E = {0:F2}. Quantidade de uso: {1} \n", percentualDeUsoElevadorE, elevadorQtdeUso);

        }

        static void periodoMaiorFluxoElevadorMaisFrequentado(List<Elevador> ElevadorList)
        {
            string turno = "";
            ServiceElevador elevadorService = new ServiceElevador();
            List<char> eMaisFrequentado = elevadorService.elevadorMaisFrequentado(ElevadorList);

            foreach (var elevador in eMaisFrequentado)
            {               
                var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == elevador).ToList().Count.ToString();
                List<char> periodoMaiorFluxoElevadorMaisFrequentado = elevadorService.periodoMaiorFluxoElevadorMaisFrequentado(ElevadorList, elevador);

                foreach (var periodo in periodoMaiorFluxoElevadorMaisFrequentado)
                {
                    switch (periodo)
                    {
                        case 'M':
                            turno = "Matutino";
                            break;

                        case 'V':
                            turno = "Vespertino";
                            break;
                        case 'N':
                            turno = "Noturno";
                            break;
                    }

                    var periodoQtdeUso = ElevadorList.Where(E => E.turno == periodo && E.elevador == elevador).ToList().Count.ToString();

                    Console.WriteLine("O Elevador {0} é o maior frequentado. Quantidade de uso: {1}.", elevador, elevadorQtdeUso);
                    Console.WriteLine("O período de maior fluxo é o {0}. Quantidade de uso: {1} \n", turno, periodoQtdeUso);
                }
            }

        }

        static void periodoMenorFluxoElevadorMenosFrequentado(List<Elevador> ElevadorList)
        {
            string turno = "";
            ServiceElevador elevadorService = new ServiceElevador();
            List<char> eMenosFrequentado = elevadorService.elevadorMenosFrequentado(ElevadorList);

            // Console.WriteLine("Período de menor fluxo de cada um dos elevadores menos frequentados \n");

            foreach (var elevador in eMenosFrequentado)
            {               
                var elevadorQtdeUso = ElevadorList.Where(E => E.elevador == elevador).ToList().Count.ToString();
                List<char> periodoMenorFluxoElevadorMenosFrequentado = elevadorService.periodoMenorFluxoElevadorMenosFrequentado(ElevadorList, elevador);

                foreach (var periodo in periodoMenorFluxoElevadorMenosFrequentado)
                {
                    switch (periodo)
                    {
                        case 'M':
                            turno = "Matutino";
                            break;

                        case 'V':
                            turno = "Vespertino";
                            break;
                        case 'N':
                            turno = "Noturno";
                            break;
                    }
                    
                    var periodoQtdeUso = ElevadorList.Where(E => E.turno == periodo && E.elevador == elevador).ToList().Count.ToString();

                    Console.WriteLine("O Elevador {0} é o menor frequentado. Quantidade de uso: {1}. ", elevador, elevadorQtdeUso);
                    Console.WriteLine("O período de menor fluxo é o {0}, Quantidade de uso: {1} \n", turno, periodoQtdeUso );
                }
            }
        }
        static void periodoMaiorUtilizacaoConjuntoElevadores(List<Elevador> ElevadorList)
        {
            string turno = "";
            ServiceElevador elevadorService = new ServiceElevador();
            List<char> periodoMaiorUtilizacaoConjuntoElevadores = elevadorService.periodoMaiorUtilizacaoConjuntoElevadores(ElevadorList);
           
            foreach (var periodo in periodoMaiorUtilizacaoConjuntoElevadores)
            { 
                switch (periodo)
                {
                    case 'M':
                        turno = "Matutino";
                        break;

                    case 'V':
                        turno = "Vespertino";
                        break;
                    case 'N':
                        turno = "Noturno";
                        break;
                }

                Console.WriteLine("Período de maior fluxo do Conjunto elevadores é no Turno {0} \n", turno);
            }
        }
    }
}
