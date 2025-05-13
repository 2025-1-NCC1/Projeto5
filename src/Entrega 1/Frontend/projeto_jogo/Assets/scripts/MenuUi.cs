using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuUi : MonoBehaviour
{
    public GameObject menuPanel;        // Referência ao painel da UI
    public GameObject menuProblema;        // Referência ao painel dos Problemas
    public TMP_Text nomeCasaText;      // Texto para exibir o nome da casa
    public TMP_Text moradoresText;     // Texto para exibir o número de moradores
    public TMP_Text aguaText;          // Texto para exibir o consumo de água
    public TMP_Text energiaText; // Texto para exibir o consumo de energia
    public TMP_Text totalProblemas;
    public TMP_Text mediaTipos;
   
    public TMP_Text problemaCasa;
    double media;
    int numProblemas;
    private void Start()
    {
        // Inicialmente, o painel fica desativado
        menuPanel.SetActive(false);
    }

    // Método para mostrar o menu com as informações da casa
    public void MostrarInformacoes(CasaBehaviour casa)
    {
        // Ativa o painel
        menuPanel.SetActive(true);

        // Atualiza as informações da UI
        nomeCasaText.text = "Casa " + casa.gameObject.name;
        moradoresText.text = "Moradores: " + casa.moradores.ToString();
        aguaText.text = "Água: " + casa.consumoAguaTotal + "L/dia";
        energiaText.text = "Energia: " + casa.consumoEnergiaTotal + "kWh/mês";
        mediaTipos.text = "Media Tipos: " + casa.mediaTipos;
        totalProblemas.text = "Total de problemas: " + casa.totalProblemas;
        problemaCasa.text = string.Join("\n• ", casa.problemaCasa).Insert(0, "• ");
        Debug.Log("Problemas sorteados:");
        
       
    }
    
    // Método para esconder o menu  
    public void FecharMenu()
    {
        menuPanel.SetActive(false);
    }
}
