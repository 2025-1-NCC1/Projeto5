using UnityEngine;

public class creditos : MonoBehaviour
{
    //cria um gameObject para ser possível adicionar o painel dos créditos no inspector
    public GameObject painelCreditos;

    // função que abre os créditos
    public void AbrirCreditos()
    {
        painelCreditos.SetActive(true);
    }
    // função que fecha os créditos
    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
    }
}
