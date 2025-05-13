using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuUi : MonoBehaviour
{
    public GameObject menuPanel;        // Refer�ncia ao painel da UI
    public GameObject menuProblema;        // Refer�ncia ao painel dos Problemas
    public TMP_Text nomeCasaText;      // Texto para exibir o nome da casa
    public TMP_Text moradoresText;     // Texto para exibir o n�mero de moradores
    public TMP_Text aguaText;          // Texto para exibir o consumo de �gua
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

    // M�todo para mostrar o menu com as informa��es da casa
    public void MostrarInformacoes(CasaBehaviour casa)
    {
        // Ativa o painel
        menuPanel.SetActive(true);

        // Atualiza as informa��es da UI
        nomeCasaText.text = "Casa " + casa.gameObject.name;
        moradoresText.text = "Moradores: " + casa.moradores.ToString();
        aguaText.text = "�gua: " + casa.consumoAguaTotal + "L/dia";
        energiaText.text = "Energia: " + casa.consumoEnergiaTotal + "kWh/m�s";
        mediaTipos.text = "Media Tipos: " + casa.mediaTipos;
        totalProblemas.text = "Total de problemas: " + casa.totalProblemas;
        problemaCasa.text = string.Join("\n� ", casa.problemaCasa).Insert(0, "� ");
        Debug.Log("Problemas sorteados:");
        
       
    }
    
    // M�todo para esconder o menu  
    public void FecharMenu()
    {
        menuPanel.SetActive(false);
    }
}
