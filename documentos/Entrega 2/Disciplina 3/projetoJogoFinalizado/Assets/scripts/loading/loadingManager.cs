using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    // nome da cena a ser carregada 
    public string cenaParaCarregar = "jogo";

    // referência ao texto que exibirá a porcentagem de carregamento
    public TMP_Text textoPorcentagem;

    void Start()
    {
        // inicia a contagem que carrega a cena 
        StartCoroutine(CarregarCena());
    }

    // coroutine para carregar a cena e atualizar a UI
    IEnumerator CarregarCena()
    {
        // começa a carregar a cena especificada 
        AsyncOperation operacao = SceneManager.LoadSceneAsync(cenaParaCarregar);

        // evita que a cena seja ativada automaticamente quando o carregamento atingir 90%
        operacao.allowSceneActivation = false;

        // enquanto o carregamento não estiver completo
        while (operacao.isDone ==  false)
        {
            // calcula o progresso normalizado entre 0 e 1 
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            // atualiza o texto da UI com a porcentagem de progresso, se o texto existir
            if (textoPorcentagem != null)
                textoPorcentagem.text = (progresso * 100f).ToString("F0") + "%";

            // quando o progresso atingir 90% (estado pronto para ativar)
            if (operacao.progress >= 0.9f)
            {
                // mostra 100% na UI
                textoPorcentagem.text = "100%";

                // espera 1 segundo
                yield return new WaitForSeconds(1f);

                // permite ativar a cena, finalizando o carregamento e mudando para ela
                operacao.allowSceneActivation = true;
            }

            // espera até o próximo frame antes de continuar o loop
            yield return null;
        }
    }
}
