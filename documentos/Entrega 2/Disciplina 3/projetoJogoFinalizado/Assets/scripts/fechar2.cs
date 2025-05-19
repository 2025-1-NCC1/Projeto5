using UnityEngine;

public class fechar2 : MonoBehaviour
{
    // refer�ncia ao painel do menu que ser� ativado ou desativado
    public GameObject menuPanel;

    // refer�ncia � c�mera principal 
    public Camera cam;

    // m�todo p�blico para fechar o menu e atualizar estados 
    public void FecharMenu()
    {
        // verifica se o mouse est� ativo no componente RayCast da c�mera
        if (cam.GetComponent<RayCast>().mouseAtivo == true)
        {
            // desativa o mouse 
            cam.GetComponent<RayCast>().mouseAtivo = false;

            // trava o cursor no centro da tela 
            Cursor.lockState = CursorLockMode.Locked;
        }

        // marca que o painel est� desativado no RayCast
        cam.GetComponent<RayCast>().painelDesativo = true;

        // desativa o painel do menu na cena
        menuPanel.SetActive(false);

    }
}
