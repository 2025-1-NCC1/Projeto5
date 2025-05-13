using UnityEngine;
using System.Collections;
//Script dos prédios

public class Predios : MonoBehaviour
{
    public bool ativo; // Indica se o prédio está ativo (destacado)
    public bool selecionado; // Indica se o prédio está selecionado
    private Vector3 posicaoOriginal; // Armazena a posição original do prédio
    private Renderer rendererPredio; // Referência ao componente Renderer do prédio (para trocar cor/material)

    void Start()
    {
        ativo = false; // Inicialmente não está ativo
        selecionado = false; // Inicialmente não está selecionado
        posicaoOriginal = transform.position; // Salva a posição original para depois voltar
        rendererPredio = GetComponent<Renderer>(); // Pega o Renderer do objeto
    }

    // Método para ativar o efeito de destaque no prédio
    public void TrocaMaterial()
    {
        StopCoroutine("TrocaCor"); // Para qualquer coroutine anterior que esteja mudando a cor
        if (ativo)
        {
            // Altera a cor de emissão para destacar
            rendererPredio.material.SetColor("_EmissionColor", Color.white * 0.22f);
            StartCoroutine("TrocaCor"); // Inicia a coroutine que desativa o destaque após um tempo
        }
    }

    // Coroutine que aguarda 0.1 segundo antes de apagar o brilho e desativar o "ativo"
    IEnumerator TrocaCor()
    {
        yield return new WaitForSeconds(0.1f);
        ativo = false; //Desativa o estado "ativo"
        rendererPredio.material.SetColor("_EmissionColor", Color.black);
    }
    
    // Método para selecionar o prédio
    public void Selecionar()
    {
        if (!selecionado)
        {
            selecionado = true; // Marca como selecionado
            transform.position += new Vector3(0, 0.7f, 0); // Move o prédio para cima (efeito visual de seleção)

        }
    }

    // Método para desselecionar o prédio
    public void Desselecionar()
    {
        if (selecionado)
        {
            selecionado = false;  // Marca como não selecionado
            transform.position = posicaoOriginal; // Volta à posição original
           
        }
    }
}
