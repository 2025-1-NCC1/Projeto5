using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
    // cria um gameObject para o menu vis�vel no inspector
    public GameObject menuPause;
    
    // define uma vari�vel para a camera
    public Camera cam ;

    // fun��o chamada para retomar o jogo ap�s o pause
    public void resume()
    {
        // restaura a escala do tempo para o tempo normal(1)
        Time.timeScale = 1f;

        // desativa o controle do mouse no script RayCast da c�mera
        RayCast raycastScript = cam.GetComponent<RayCast>();
        raycastScript.mouseAtivo = false;

        // trava o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;

        // desativa o painel de intera��o do RayCast
        raycastScript.painelDesativo = true;

        // oculta o menu de pausa
        menuPause.SetActive(false);
    }

    // fun��o chamada para sair do jogo e voltar ao menu principal
    public void sair()
    {
        // carrega a cena "menu"
        SceneManager.LoadScene("menu");
    }
}