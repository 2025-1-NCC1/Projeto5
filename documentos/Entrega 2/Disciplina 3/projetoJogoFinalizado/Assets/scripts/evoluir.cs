using UnityEngine;

public class evoluir : MonoBehaviour
{
    // refer�ncia para o menu de problemas 
    public GameObject menuProblemas;

    // refer�ncia para o painel principal do menu (UI com infos da casa, etc.)
    public GameObject menuPanel;

    // bot�o de evolu��o (sendo usado no inspector)
    public GameObject btnEvoluir;

    // c�mera principal, usada para pegar o objeto da casa na frente do jogador
    public Camera cam;

    // objeto que cont�m o script de controle do tempo/dia (SkyboxDayCycle)
    public GameObject upgrade;

    // m�todo chamado para abrir o menu de evolu��o de problema da casa
    public void menuEvoluir()
    {
        // pega o script CasaBehaviour da casa que est� sendo olhada pela c�mera
        RayCast rayCastScript = cam.GetComponent<RayCast>();
        GameObject objetoHit = rayCastScript.hitInfo.collider.gameObject;

        CasaBehaviour casa = objetoHit.GetComponent<CasaBehaviour>();

        // verifica se a casa tem problemas e se ainda h� upgrades dispon�veis hoje
        bool casaTemProblemas = casa.problemaCasa.Count != 0;
        bool podeEvoluirHoje = upgrade.GetComponent<SkyboxDayCycle>().upgradesHoje > 0;

        // se a casa tiver problemas e o jogador tiver upgrades disponiveis, executa o bloco if
        if (casaTemProblemas && podeEvoluirHoje)
        {
            // ativa o menu de problemas e desativa o menu de informa��es
            rayCastScript.painelDesativo = false;
            menuProblemas.SetActive(true);
            menuPanel.SetActive(false);

            // mensagens de debug no console
            Debug.Log("Fechou Infos");
            Debug.Log("Abriu problemas");

            // chama o m�todo para carregar o problema atual no menu
            menuProblemas.GetComponent<EvoluirProblema>().evoluir(casa);
        }
    }
}
