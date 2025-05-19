using UnityEngine;

public class fechar : MonoBehaviour
{
    // refer�ncia ao painel do menu que ser� ativado/desativado
    public GameObject menuPanel;

    // refer�ncia � c�mera principal para acessar o componente RayCast
    public Camera cam;

    // m�todo p�blico para fechar o menu 
    public void FecharMenu()
    {
        // verifica se o mouse est� ativo no script RayCast associado � c�mera
        if (cam.GetComponent<RayCast>().mouseAtivo == true)
        {
            // desativa o mouse ativo
            cam.GetComponent<RayCast>().mouseAtivo = false;

            // trava o cursor no centro da tela
            Cursor.lockState = CursorLockMode.Locked;
        }

        // marca que o painel est� desativado no script RayCast
        cam.GetComponent<RayCast>().painelDesativo = true;

        // desativa o painel do menu
        menuPanel.SetActive(false);

    }
}
