using UnityEngine;

public class fechar2 : MonoBehaviour
{
    // referência ao painel do menu que será ativado ou desativado
    public GameObject menuPanel;

    // referência à câmera principal 
    public Camera cam;

    // método público para fechar o menu e atualizar estados 
    public void FecharMenu()
    {
        // verifica se o mouse está ativo no componente RayCast da câmera
        if (cam.GetComponent<RayCast>().mouseAtivo == true)
        {
            // desativa o mouse 
            cam.GetComponent<RayCast>().mouseAtivo = false;

            // trava o cursor no centro da tela 
            Cursor.lockState = CursorLockMode.Locked;
        }

        // marca que o painel está desativado no RayCast
        cam.GetComponent<RayCast>().painelDesativo = true;

        // desativa o painel do menu na cena
        menuPanel.SetActive(false);

    }
}
