using UnityEngine;
using UnityEngine.SceneManagement;

public class iniciar : MonoBehaviour
{
    // fun��o que carrega a cena loading
    public void IniciarJogo()
    {
        SceneManager.LoadScene("loading"); // Nome exato da sua cena
    }

    // fun��o que fecha o jogo
    public void SairDoJogo()
    {
        Application.Quit();

    }
}
