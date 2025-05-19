using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// script para controlar o volume do áudio usando um AudioMixer e um slider
public class controladorVolume : MonoBehaviour
{
    // referência ao AudioMixer que possui o parâmetro exposto para controlar o volume
    public AudioMixer audioMixer;

    // nome do parâmetro exposto no AudioMixer que será controlado
    public string exposedParam = "MyExposedParam";

    // referência ao slider da UI que controla o volume
    public Slider volumeSlider;

    // definição dos limites de volume
    public float minDb = 0f;   // volume mínimo (0 dB)
    public float maxDb = 20f;  // volume máximo (20 dB)

    void Start()
    {
        // adiciona um listener para atualizar o volume quando o slider for alterado
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // obtém o valor atual do parâmetro exposto no AudioMixer em dB
        float currentDb;
        if (audioMixer.GetFloat(exposedParam, out currentDb))
        {
            // converte o valor de dB para um valor normalizado entre 0 e 1
            float normalized = Mathf.InverseLerp(minDb, maxDb, currentDb);

            // atualiza o slider para refletir o valor atual do volume
            volumeSlider.value = normalized;
        }
    }

    // método chamado sempre que o slider muda de valor
    public void SetVolume(float sliderValue)
    {
        // converte o valor normalizado do slider (0 a 1) para o intervalo em dB (minDb a maxDb)
        float dB = Mathf.Lerp(minDb, maxDb, sliderValue);

        // aplica o valor convertido ao parâmetro exposto do AudioMixer
        audioMixer.SetFloat(exposedParam, dB);
    }
}
