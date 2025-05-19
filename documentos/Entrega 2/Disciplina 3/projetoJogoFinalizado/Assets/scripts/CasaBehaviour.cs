using System.Collections.Generic;
using UnityEngine;

// script que representa o comportamento de uma casa individual no jogo
public class CasaBehaviour : MonoBehaviour
{
    // vari�vel do n�mero de moradores da casa
    public int moradores;

    // lista dos tipos de consumo de cada morador (1 = baixo, 2 = m�dio, 3 = alto)
    public List<int> tiposDeConsumo = new List<int>();

    // consumo total de �gua da casa
    public float consumoAguaTotal;

    // consumo total de energia da casa
    public float consumoEnergiaTotal;

    // m�dia dos tipos de consumo dos moradores
    public double mediaTipos;

    // quantidade de problemas identificados na casa
    public int totalProblemas;

    // lista de problemas atribu�dos � casa
    public List<string> problemaCasa = new List<string>();

    // lista de solu��es associadas aos problemas da casa
    public List<string> solucao = new List<string>();

    // m�todo chamado para inicializar os dados da casa
    public void Inicializar(
        int moradores,
        List<int> tipos,
        double mediaTiposParam,
        int totalProblemasParam,
        float consumoAguaParam,
        float consumoEnergiaParam,
        List<string> problemaCasa,
        List<string> solucao
    )
    {
        // atribui os par�metros recebidos �s vari�veis de cada classe
        this.moradores = moradores;
        this.tiposDeConsumo = tipos;
        this.mediaTipos = mediaTiposParam;
        this.totalProblemas = totalProblemasParam;
        this.consumoAguaTotal = consumoAguaParam;
        this.consumoEnergiaTotal = consumoEnergiaParam;
        this.problemaCasa = problemaCasa;
        this.solucao = solucao;
    }
}
