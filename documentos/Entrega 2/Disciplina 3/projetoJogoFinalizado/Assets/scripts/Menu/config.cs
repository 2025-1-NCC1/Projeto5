using UnityEngine;

public class painelConfig : MonoBehaviour
{
    // referência ao  objeto painel de configurações
    public GameObject painelConfiguracoes;

    //método responsável por abrir o panel de configurações
    public void AbrirConfiguracoes()
    {
        painelConfiguracoes.SetActive(true);
    }

    //método responsável por fechar o panel de configurações
    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
    }
}
