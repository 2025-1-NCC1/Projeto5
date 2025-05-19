
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    //m�todo que define a libera��o do cursor assim que a tela de vit�ria carregar
    void start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // m�todo respons�vel por voltar ao menu
    public void VoltarMenu()
    {
        SceneManager.LoadScene("menu"); 
    }


}
