using UnityEngine;
using System.Collections;
//Script dos pr�dios

public class Predios : MonoBehaviour
{
    public bool ativo; // Indica se o pr�dio est� ativo (destacado)
    public bool selecionado; // Indica se o pr�dio est� selecionado
    private Vector3 posicaoOriginal; // Armazena a posi��o original do pr�dio
    private Renderer rendererPredio; // Refer�ncia ao componente Renderer do pr�dio (para trocar cor/material)

    void Start()
    {
        ativo = false; // Inicialmente n�o est� ativo
        selecionado = false; // Inicialmente n�o est� selecionado
        posicaoOriginal = transform.position; // Salva a posi��o original para depois voltar
        rendererPredio = GetComponent<Renderer>(); // Pega o Renderer do objeto
    }

    // M�todo para ativar o efeito de destaque no pr�dio
    public void TrocaMaterial()
    {
        StopCoroutine("TrocaCor"); // Para qualquer coroutine anterior que esteja mudando a cor
        if (ativo)
        {
            // Altera a cor de emiss�o para destacar
            rendererPredio.material.SetColor("_EmissionColor", Color.white * 0.22f);
            StartCoroutine("TrocaCor"); // Inicia a coroutine que desativa o destaque ap�s um tempo
        }
    }

    // Coroutine que aguarda 0.1 segundo antes de apagar o brilho e desativar o "ativo"
    IEnumerator TrocaCor()
    {
        yield return new WaitForSeconds(0.1f);
        ativo = false; //Desativa o estado "ativo"
        rendererPredio.material.SetColor("_EmissionColor", Color.black);
    }
    
    // M�todo para selecionar o pr�dio
    public void Selecionar()
    {
        if (!selecionado)
        {
            selecionado = true; // Marca como selecionado
            transform.position += new Vector3(0, 0.7f, 0); // Move o pr�dio para cima (efeito visual de sele��o)

        }
    }

    // M�todo para desselecionar o pr�dio
    public void Desselecionar()
    {
        if (selecionado)
        {
            selecionado = false;  // Marca como n�o selecionado
            transform.position = posicaoOriginal; // Volta � posi��o original
           
        }
    }
}
