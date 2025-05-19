using UnityEngine;

public class menuCamera : MonoBehaviour
{
    // define as variáveis responsáveis pelos pontos em que a camera se move
    public Transform pontoA;
    public Transform pontoB;

    // define a velocidade do movimento da câmera
    public float velocidade = 1f;

    // variável auxiliar para o cálculo da interpolação
    private float t = 0f;

    // indica se a câmera está indo para o ponto B (se for false, está indo para o ponto A)
    private bool indoParaB = true;

    
    void Update()
    {
        // se estiver indo para B, incrementa t
        // se estiver voltando para A, decrementa t
        if (indoParaB)
        {
            t += Time.deltaTime * velocidade;
        }
        else
        {
            t -= Time.deltaTime * velocidade;
        }

        // garante que o valor de t fique entre 0 e 1
        t = Mathf.Clamp01(t);

        // move a posição da câmera entre pontoA e pontoB
        transform.position = Vector3.Lerp(pontoA.position, pontoB.position, t);

        // faz a rotação da câmera também acompanhar suavemente entre pontoA e pontoB
        transform.rotation = Quaternion.Lerp(pontoA.rotation, pontoB.rotation, t);

        // quando t atinge os extremos (0 ou 1), inverte a direção do movimento
        if (t >= 1f || t <= 0f)
        {
            indoParaB = !indoParaB;
        }
    }
}
