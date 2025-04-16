using UnityEngine;
using System.Collections;

public class Predios : MonoBehaviour
{
    private Vector3 posicaoOriginal;
    public float altura = 0.1f;
    public bool ativo;

    void Start()
    {
        ativo = false;
        posicaoOriginal = transform.position; // ? ESSENCIAL
    }

    public void TrocaMaterial()
    {
        StopCoroutine("TrocaCor");
        if (ativo)
        {
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white * 0.1f);
            StartCoroutine("TrocaCor");
        }
    }

    IEnumerator TrocaCor()
    {
        yield return new WaitForSeconds(0.1f);
        ativo = false;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

    public void Subir()
    {
        StopCoroutine("Pulinho");
        if (ativo)
        {
            transform.position = posicaoOriginal + new Vector3(0, altura, 0);
            StartCoroutine("Pulinho");
        }
    }

    IEnumerator Pulinho()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = posicaoOriginal;
        ativo = false;
    }
}
