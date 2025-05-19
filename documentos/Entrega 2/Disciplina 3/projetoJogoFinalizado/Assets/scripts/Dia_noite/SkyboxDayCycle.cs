using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Controla o ciclo de dia e noite no jogo, atualiza o céu, a contagem de dias e os upgrades diários.
public class SkyboxDayCycle : MonoBehaviour
{
    [Header("Duração do ciclo (em segundos)")]
    public float fullDayLength = 120f; // tempo total de um ciclo de dia
    public GameObject pause; // game object referente ao menu de pausa
    private Material skyboxMat; // material do Skybox
    private float currentTime = 0f; // tempo atual do ciclo
    public int dia = 0; // contador de dias
    public TMP_Text txtDia; // texto exibindo o dia atual
    public GameManager gameManager; // referência ao GameManager
    public Camera cam; // referência à câmera principal
    float velocidadeDia = 1f; // velocidade do ciclo (padrão = 1)
    public GameObject btnPassarDia; // botão para passar o dia
    private bool podePassarDia = false; // variável do tipo booleana que define se o jogador pode passar o dia
    private bool acelerarTempo = false; // variável do tipo booleana que define se o tempo está acelerado

    private int x = 0; // contador responsável por contar o dia apenas uma vez

    [Header("Upgrades")]
    public int upgradesHoje = 0; // número de upgrades disponíveis hoje
    public TMP_Text txtUpgrades; // texto exibindo os upgrades

    void Start()
    {
        // pega o material do skybox atual da cena
        skyboxMat = RenderSettings.skybox;

        // sorteia entre 3 e 7 upgrades no início
        upgradesHoje = Random.Range(3, 8);

        // atualiza o texto na tela
        AtualizarTextoUpgrades();
    }

    void Update()
    {
        // pausar o jogo ao pressionar ESC
        if (Input.GetKey(KeyCode.Escape))
        {
            //libera o cursor e exibe o menu de pausa
            cam.GetComponent<RayCast>().painelDesativo = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // a passagem do tempo é definida para 0
            Time.timeScale = 0f;
            pause.SetActive(true);
        }

        // atualiza o texto dos upgrades
        AtualizarTextoUpgrades();

        // atualiza o texto com o número do dia atual
        txtDia.text = "Dia " + dia.ToString();

        // calcula a porcentagem do tempo atual em relação à duração total do dia
        float t = (currentTime % fullDayLength) / fullDayLength;

        // se acabaram os upgrades e ainda não pode passar o dia, ativa o botão
        if (upgradesHoje == 0 && podePassarDia == false)
        {
            btnPassarDia.SetActive(true);
            podePassarDia = true;
        }

        // se pode passar o dia e o jogador pressionar R, acelera o tempo
        if (podePassarDia == true && Input.GetKeyDown(KeyCode.R))
        {
            acelerarTempo = true;
            Debug.Log("Botão pressionado");
        }

        // se o tempo está acelerado, aumenta a velocidade do ciclo
        if (acelerarTempo == true)
        {
            velocidadeDia = 10f;
        }

        // avança o tempo do ciclo com base na velocidade
        currentTime += Time.deltaTime * velocidadeDia;

        float blend = 0f; // valor do blend para o Skybox

        // definição do tipo de luz/skybox com base no tempo
        if (t < 0.4f)
        {
            // DIA
            blend = 0f;
            x = 0; // permite a contagem de um novo dia no próximo amanhecer
        }
        else if (t >= 0.4f && t < 0.5f)
        {
            // ENTARDECER (10% do tempo)
            float porcentagem = (t - 0.4f) / 0.1f;
            blend = Mathf.Lerp(0f, 1f, porcentagem);
        }
        else if (t >= 0.5f && t < 0.9f)
        {
            // NOITE (40% do tempo)
            blend = 1f;
        }
        else // t >= 0.9f
        {
            // AMANHECER (últimos 10% do tempo)
            float porcentagem = (t - 0.9f) / 0.1f;
            blend = Mathf.Lerp(1f, 0f, porcentagem);

            // essa parte só acontece uma vez por ciclo
            if (x == 0)
            {
                // passa para o próximo dia
                dia += 1;

                // garante que só execute essa lógica uma vez por ciclo
                x = 1;

                // reseta variáveis
                btnPassarDia.SetActive(false);
                podePassarDia = false;
                acelerarTempo = false;
                velocidadeDia = 1f;

                // sorteia novo número de upgrades entre 3 e 7 
                upgradesHoje = Random.Range(3, 8);

                AtualizarTextoUpgrades();

                // verifica condições de vitória ou derrota
                if (dia > 10 && gameManager.GetComponent<GameManager>().problemaCidade != 0)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene("derrota");
                }

                if (gameManager.GetComponent<GameManager>().problemaCidade < 1)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    SceneManager.LoadScene("win");
                }
            }
        }

        // atualiza o valor do blend no material do skybox
        skyboxMat.SetFloat("_Blend", blend);

        // atualiza a iluminação global da cena com base no novo skybox
        DynamicGI.UpdateEnvironment();
    }

    // atualiza o texto dos upgrades na tela
    void AtualizarTextoUpgrades()
    {
        if (txtUpgrades != null)
        {
            txtUpgrades.text = "Upgrades: " + upgradesHoje.ToString();
        }
    }
}
