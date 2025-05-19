using UnityEngine;
using UnityEngine.SceneManagement;

public class iniciar : MonoBehaviour
{
    // função que carrega a cena loading
    public void IniciarJogo()
    {
        SceneManager.LoadScene("loading"); // Nome exato da sua cena
    }

    // função que fecha o jogo
    public void SairDoJogo()
    {
        Application.Quit();

    }
}
