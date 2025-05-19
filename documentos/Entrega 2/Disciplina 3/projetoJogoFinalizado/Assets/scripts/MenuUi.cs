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
    public TMP_Text totalProblemas; // texto para exibir o total de problemas da cidade


    // refer�ncia � c�mera principal, usada para manipular o script RayCast
    public Camera cam;

    // m�todo chamado para mostrar as informa��es de uma casa no menu
    public void MostrarInformacoes(CasaBehaviour casa)
    {
        // desativa o RayCast temporariamente (impede que o jogador interaja com outras casas)
        cam.GetComponent<RayCast>().painelDesativo = false;

        // ativa o painel com as informa��es da casa
        menuPanel.SetActive(true);

        // libera o cursor para que o jogador possa clicar nos elementos da UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // define o texto do nome da casa
        nomeCasaText.text = "Casa " + casa.gameObject.name;

        // define o n�mero de moradores
        moradoresText.text = "Moradores: " + casa.moradores.ToString();

        // define o consumo de �gua com duas casas decimais
        aguaText.text = "�gua: " + casa.consumoAguaTotal.ToString("F2") + "L/dia";

        // define o consumo de energia com duas casas decimais
        energiaText.text = "Energia: " + casa.consumoEnergiaTotal.ToString("F2") + "kWh/m�s";

        // mostra o n�mero total de problemas da casa
        totalProblemas.text = "Total de problemas: " + casa.totalProblemas;
    }

    // m�todo para fechar o painel de informa��es
    public void FecharMenu()
    {
        menuPanel.SetActive(false);
    }
}
