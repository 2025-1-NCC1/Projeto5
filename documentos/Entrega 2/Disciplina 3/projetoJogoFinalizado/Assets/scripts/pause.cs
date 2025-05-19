using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
    // cria um gameObject para o menu visível no inspector
    public GameObject menuPause;
    
    // define uma variável para a camera
    public Camera cam ;

    // função chamada para retomar o jogo após o pause
    public void resume()
    {
        // restaura a escala do tempo para o tempo normal(1)
        Time.timeScale = 1f;

        // desativa o controle do mouse no script RayCast da câmera
        RayCast raycastScript = cam.GetComponent<RayCast>();
        raycastScript.mouseAtivo = false;

        // trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;

        // desativa o painel de interação do RayCast
        raycastScript.painelDesativo = true;

        // oculta o menu de pausa
        menuPause.SetActive(false);
    }

    // função chamada para sair do jogo e voltar ao menu principal
    public void sair()
    {
        // carrega a cena "menu"
        SceneManager.LoadScene("menu");
    }
}