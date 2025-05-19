using UnityEngine;

public class painelConfig : MonoBehaviour
{
    // refer�ncia ao  objeto painel de configura��es
    public GameObject painelConfiguracoes;

    //m�todo respons�vel por abrir o panel de configura��es
    public void AbrirConfiguracoes()
    {
        painelConfiguracoes.SetActive(true);
    }

    //m�todo respons�vel por fechar o panel de configura��es
    public void FecharConfiguracoes()
    {
        painelConfiguracoes.SetActive(false);
    }
}
