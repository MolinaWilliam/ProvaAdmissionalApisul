using ElevadorService.Interface;
using ElevadorService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElevadorService.Clases
{
    class ServiceElevador : IElevadorService
    {
        public List<int> andarMenosUtilizado(List<Elevador> ElevadorList)
        {           
            var andarList = new List<int>();
            var andarMenosVisitadoList = new List<int>();

            foreach (var item in ElevadorList)
            {
                andarList.Add(item.andar);
            }          
               
            andarMenosVisitadoList = menosFrequentado(andarList); ;               

            return andarMenosVisitadoList;
        }

        public List<char> elevadorMaisFrequentado(List<Elevador> ElevadorList)
        {
            List<char> elevaMaisFrequentado = new List<char>();
            var eList = new List<char>();                

            foreach (var item in ElevadorList)
            {
                eList.Add(item.elevador);
            }

            elevaMaisFrequentado = maisFrequentado(eList);

            return elevaMaisFrequentado;            
        }

        public List<char> elevadorMenosFrequentado(List<Elevador> ElevadorList)
        {
            List<char> elevaMenosFrequentado = new List<char>();
            var eList = new List<char>();               

            foreach (var item in ElevadorList)
            {
                eList.Add(item.elevador);
            }

            elevaMenosFrequentado = menosFrequentado(eList);

            return elevaMenosFrequentado;           
        }

        public float percentualDeUsoElevadorA(List<Elevador> ElevadorList)
        {
            float percentualDeUsoElevadorA = usoPorcentual(ElevadorList, 'A');

            return percentualDeUsoElevadorA;
        }

        public float percentualDeUsoElevadorB(List<Elevador> ElevadorList)
        {
            float percentualDeUsoElevadorA = usoPorcentual(ElevadorList, 'B');

            return percentualDeUsoElevadorA;
        }

        public float percentualDeUsoElevadorC(List<Elevador> ElevadorList)
        {
            float percentualDeUsoElevadorA = usoPorcentual(ElevadorList, 'C');

            return percentualDeUsoElevadorA;
        }

        public float percentualDeUsoElevadorD(List<Elevador> ElevadorList)
        {
            float percentualDeUsoElevadorA = usoPorcentual(ElevadorList, 'D');

            return percentualDeUsoElevadorA;
        }

        public float percentualDeUsoElevadorE(List<Elevador> ElevadorList)
        {
            float percentualDeUsoElevadorA = usoPorcentual(ElevadorList, 'E');

            return percentualDeUsoElevadorA;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<Elevador> ElevadorList, char elevador)
        {
            List<char> periodoMaiorFluxoElevadorMaisFrequentado = new List<char>();
            List<Elevador> auxEList = new List<Elevador>();
            var tList = new List<char>();
            
            auxEList = ElevadorList.Where(E => E.elevador == elevador).ToList();           

            foreach (var item in auxEList)
            {
                tList.Add(item.turno);
            }

            periodoMaiorFluxoElevadorMaisFrequentado = maisFrequentado(tList);

            return periodoMaiorFluxoElevadorMaisFrequentado;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<Elevador> ElevadorList)
        {
            List<char> periodoMaiorUsoConjuntoElevadores = new List<char>();
            var tList = new List<char>();

            foreach (var item in ElevadorList)
            {
                tList.Add(item.turno);
            }

            periodoMaiorUsoConjuntoElevadores = maisFrequentado(tList);

            return periodoMaiorUsoConjuntoElevadores;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado(List<Elevador> ElevadorList, char elevador)
        {
            List<char> periodoMenorFluxoElevadorMenosFrequentado = new List<char>();            
            List<Elevador> auxEList = new List<Elevador>();
            var tList = new List<char>();

            auxEList = ElevadorList.Where(E => E.elevador == elevador).ToList();            

            foreach (var item in auxEList)
            {
                tList.Add(item.turno);
            }

            periodoMenorFluxoElevadorMenosFrequentado = menosFrequentado(tList);

            return periodoMenorFluxoElevadorMenosFrequentado;
        }

        public float usoPorcentual(List<Elevador> ElevadorList, char Elevador)
        {
            var eList = new List<char>();
            float totalUsoElevador = 0, totalUsoElevadorA = 0;
            float usoPorcentual = 0.00F;           

            foreach (var item in ElevadorList)
            {
                eList.Add(item.elevador);
            }

            char[] array = eList.ToArray();
            var counts = array.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Value);
            
            totalUsoElevador += ElevadorList.Count();
            
            foreach (var count in counts)
            {            
                if (count.Value == Elevador)
                {
                    totalUsoElevadorA += count.Count;
                }
            }

            usoPorcentual = (totalUsoElevadorA * 100 ) / totalUsoElevador;

            return usoPorcentual;
        }

        public List<char> maisFrequentado(List<char> arrayList)
        {
            char[] array = arrayList.ToArray();
            List<char> maisFrequentado = new List<char>();
            var counts = array.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Value);
            int MaisFrequentado = counts.Max(x => x.Count);

            foreach (var count in counts)
            {
                if (count.Count == MaisFrequentado)
                {
                    maisFrequentado.Add(count.Value);
                }
            }

            return maisFrequentado;
        }

        public List<char> menosFrequentado(List<char> arrayList)
        {
            char[] array = arrayList.ToArray();
            List<char> menosFrequentado = new List<char>();
            var counts = array.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Value);
            int MenosFrequentado = counts.Min(x => x.Count);

            foreach (var count in counts)
            {
                if (count.Count == MenosFrequentado)
                {
                    menosFrequentado.Add(count.Value);
                }
            }

            return menosFrequentado;
        }

        public List<int> menosFrequentado(List<int> arrayList)
        {
            int[] array = arrayList.ToArray();
            List<int> menosFrequentado = new List<int>();
            var counts = array.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Value);
            int MenosFrequentado = counts.Min(x => x.Count);

            foreach (var count in counts)
            {
                if (count.Count == MenosFrequentado)
                {
                    menosFrequentado.Add(count.Value);
                }
            }

            return menosFrequentado;
        }

        public List<int> maisFrequentado(List<int> arrayList)
        {
            int[] array = arrayList.ToArray();
            List<int> menosFrequentado = new List<int>();
            var counts = array.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Value);
            int MenosFrequentado = counts.Min(x => x.Count);

            foreach (var count in counts)
            {
                if (count.Count == MenosFrequentado)
                {
                    menosFrequentado.Add(count.Value);
                }
            }

            return menosFrequentado;
        }


    }
}
