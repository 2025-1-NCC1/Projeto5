using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class audioNum : MonoBehaviour
{
    // refer�ncia ao componente Slider da UI
    public Slider slider;

    // refer�ncia ao texto da UI que exibir� o valor em porcentagem
    public TMP_Text valorTexto;

    void Start()
    {
        // adiciona um listener para reagir quando o valor do slider mudar
        slider.onValueChanged.AddListener(UpdateValorTexto);

        // atualiza o texto com o valor inicial do slider
        UpdateValorTexto(slider.value);
    }

    // m�todo para atualizar o texto de valor quando o slider � movimentado
    void UpdateValorTexto(float valor)
    {
        // converte o valor (de 0 a 1) para porcentagem e atualiza o texto
        valorTexto.text = Mathf.RoundToInt(valor * 100) + "%";
    }
}
