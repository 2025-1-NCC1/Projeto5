using UnityEngine;

public class creditos : MonoBehaviour
{
    //cria um gameObject para ser poss�vel adicionar o painel dos cr�ditos no inspector
    public GameObject painelCreditos;

    // fun��o que abre os cr�ditos
    public void AbrirCreditos()
    {
        painelCreditos.SetActive(true);
    }
    // fun��o que fecha os cr�ditos
    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
    }
}
