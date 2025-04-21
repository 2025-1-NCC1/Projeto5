using UnityEngine;
using System.Collections;

public class Predios : MonoBehaviour
{
    public bool ativo;
    public bool selecionado;
    private Vector3 posicaoOriginal;
    private Renderer rendererPredio;

    void Start()
    {
        ativo = false;
        selecionado = false;
        posicaoOriginal = transform.position;
        rendererPredio = GetComponent<Renderer>();
    }

    public void TrocaMaterial()
    {
        StopCoroutine("TrocaCor");
        if (ativo)
        {
            rendererPredio.material.SetColor("_EmissionColor", Color.white * 0.22f);
            StartCoroutine("TrocaCor");
        }
    }

    IEnumerator TrocaCor()
    {
        yield return new WaitForSeconds(0.1f);
        ativo = false;
        rendererPredio.material.SetColor("_EmissionColor", Color.black);
    }

    public void Selecionar()
    {
        if (!selecionado)
        {
            selecionado = true;
            transform.position += new Vector3(0, 0.7f, 0); // Sobe
            
        }
    }

    public void Desselecionar()
    {
        if (selecionado)
        {
            selecionado = false;
            transform.position = posicaoOriginal; // Volta à posição original
           
        }
    }
}
