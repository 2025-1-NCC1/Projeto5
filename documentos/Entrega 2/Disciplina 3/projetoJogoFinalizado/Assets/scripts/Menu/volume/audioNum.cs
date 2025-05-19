using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class audioNum : MonoBehaviour
{
    // referência ao componente Slider da UI
    public Slider slider;

    // referência ao texto da UI que exibirá o valor em porcentagem
    public TMP_Text valorTexto;

    void Start()
    {
        // adiciona um listener para reagir quando o valor do slider mudar
        slider.onValueChanged.AddListener(UpdateValorTexto);

        // atualiza o texto com o valor inicial do slider
        UpdateValorTexto(slider.value);
    }

    // método para atualizar o texto de valor quando o slider é movimentado
    void UpdateValorTexto(float valor)
    {
        // converte o valor (de 0 a 1) para porcentagem e atualiza o texto
        valorTexto.text = Mathf.RoundToInt(valor * 100) + "%";
    }
}
