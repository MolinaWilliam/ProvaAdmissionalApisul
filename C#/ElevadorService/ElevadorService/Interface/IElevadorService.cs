using ElevadorService.Models;
using System.Collections.Generic;

namespace ElevadorService.Interface
{
    public interface IElevadorService
    {

        /// <summary> Deve retornar uma List contendo o(s) andar(es) menos utilizado(s). </summary> 
        List<int> andarMenosUtilizado(List<Elevador> ElevadorList);       

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s). </summary> 
        List<char> elevadorMaisFrequentado(List<Elevador> ElevadorList);

        /// <summary> Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um). </summary> 
        List<char> periodoMaiorFluxoElevadorMaisFrequentado(List<Elevador> ElevadorList, char elevador);

        /// <summary> Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s). </summary> 
        List<char> elevadorMenosFrequentado(List<Elevador> ElevadorList);

        /// <summary> Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um). </summary> 
        List<char> periodoMenorFluxoElevadorMenosFrequentado(List<Elevador> ElevadorList, char elevador);

        /// <summary> Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores. </summary> 
        List<char> periodoMaiorUtilizacaoConjuntoElevadores(List<Elevador> ElevadorList);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorA(List<Elevador> ElevadorList);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador B em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorB(List<Elevador> ElevadorList);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador C em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorC(List<Elevador> ElevadorList);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador D em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorD(List<Elevador> ElevadorList);

        /// <summary> Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador E em relação a todos os serviços prestados. </summary> 
        float percentualDeUsoElevadorE(List<Elevador> ElevadorList);

    }
}
