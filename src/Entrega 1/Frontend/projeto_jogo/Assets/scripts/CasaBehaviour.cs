using System.Collections.Generic;
using UnityEngine;

public class CasaBehaviour : MonoBehaviour
{
    public int moradores;
    public List<int> tiposDeConsumo = new List<int>();
    public int consumoAguaTotal;
    public int consumoEnergiaTotal; 
    public double mediaTipos;
    public int totalProblemas;
    
    public List<string> problemaCasa = new List<string>();
    



    public void Inicializar(int moradores, List<int> tipos, double mediaTipos, int totalProblemas, int agua, int energia, List<string> problemaCasa)
    {
        this.moradores = moradores;
        this.mediaTipos = mediaTipos;
        this.totalProblemas = totalProblemas;
        this.tiposDeConsumo = tipos;
        this.consumoAguaTotal = agua;
        this.consumoEnergiaTotal = energia;
        this.problemaCasa = problemaCasa;
        

        // Debug no console (opcional)
        // Debug.Log($"{gameObject.name} => Moradores: {moradores}, Água: {agua}L/dia, Energia: {energia}kWh/dia");
    }
}
