using UnityEngine;

public class fechar : MonoBehaviour
{
    // referência ao painel do menu que será ativado/desativado
    public GameObject menuPanel;

    // referência à câmera principal para acessar o componente RayCast
    public Camera cam;

    // método público para fechar o menu 
    public void FecharMenu()
    {
        // verifica se o mouse está ativo no script RayCast associado à câmera
        if (cam.GetComponent<RayCast>().mouseAtivo == true)
        {
            // desativa o mouse ativo
            cam.GetComponent<RayCast>().mouseAtivo = false;

            // trava o cursor no centro da tela
            Cursor.lockState = CursorLockMode.Locked;
        }

        // marca que o painel está desativado no script RayCast
        cam.GetComponent<RayCast>().painelDesativo = true;

        // desativa o painel do menu
        menuPanel.SetActive(false);

    }
}
