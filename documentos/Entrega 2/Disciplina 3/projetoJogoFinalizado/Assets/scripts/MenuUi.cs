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
    public TMP_Text totalProblemas; // texto para exibir o total de problemas da cidade


    // referência à câmera principal, usada para manipular o script RayCast
    public Camera cam;

    // método chamado para mostrar as informações de uma casa no menu
    public void MostrarInformacoes(CasaBehaviour casa)
    {
        // desativa o RayCast temporariamente (impede que o jogador interaja com outras casas)
        cam.GetComponent<RayCast>().painelDesativo = false;

        // ativa o painel com as informações da casa
        menuPanel.SetActive(true);

        // libera o cursor para que o jogador possa clicar nos elementos da UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // define o texto do nome da casa
        nomeCasaText.text = "Casa " + casa.gameObject.name;

        // define o número de moradores
        moradoresText.text = "Moradores: " + casa.moradores.ToString();

        // define o consumo de água com duas casas decimais
        aguaText.text = "Água: " + casa.consumoAguaTotal.ToString("F2") + "L/dia";

        // define o consumo de energia com duas casas decimais
        energiaText.text = "Energia: " + casa.consumoEnergiaTotal.ToString("F2") + "kWh/mês";

        // mostra o número total de problemas da casa
        totalProblemas.text = "Total de problemas: " + casa.totalProblemas;
    }

    // método para fechar o painel de informações
    public void FecharMenu()
    {
        menuPanel.SetActive(false);
    }
}
