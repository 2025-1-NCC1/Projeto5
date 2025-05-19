
using UnityEngine;
using UnityEngine.SceneManagement;

public class winScript : MonoBehaviour
{
    //método que define a liberação do cursor assim que a tela de vitória carregar
    void start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // método responsável por voltar ao menu
    public void VoltarMenu()
    {
        SceneManager.LoadScene("menu"); 
    }


}
