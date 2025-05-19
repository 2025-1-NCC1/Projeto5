using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EvoluirProblema : MonoBehaviour
{
    // referência para o painel de problemas
    public GameObject menuProblema;

    // botão do upgrade
    public Button evoluirBotao;

    // textos para exibir o problema e as alternativas
    public TMP_Text problemaParaSolucionar;
    public TMP_Text alternativaA;
    public TMP_Text alternativaB;
    public TMP_Text alternativaC;
    public TMP_Text alternativaD;

    // referência para o GameManager
    public GameManager gameManager;

    // botões das alternativas
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoD;

    // referência ao sistema de upgrade
    public GameObject upgrade;

    // contador global de problemas na cidade
    public int problemaCidade = 0;

    // referência à casa atual
    CasaBehaviour casaB;

    // câmera principal
    public Camera cam;

    // armazena a solução correta do problema atual
    private string solucaoCorretaAtual = "";

    // índice do problema atual na lista
    private int indiceProblemaAtual = -1;

    // lista com todas as soluções possíveis (corretas e incorretas)
    string[] todasAsSolucoes = new string[]
    {
        "Instalar chuveiros inteligentes com controle de uso.",
        "Adicionar torneiras com sensor de presença automática.",
        "Implementar limpeza urbana com água de reuso.",
        "Substituir lavadoras por modelos com recirculação.",
        "Conectar eletrodomésticos que detectam carga ideal.",
        "Instalar sensores de vazamento com alerta imediato.",
        "Adicionar arejadores e sensores em torneiras.",
        "Implantar cisternas inteligentes com filtragem integrada.",
        "Substituir descargas por modelos inteligentes e conectados.",
        "Utilizar hidrômetros inteligentes com alertas de consumo.",
        "Substituir lâmpadas por LED com sensores.",
        "Instalar sensores de presença em ambientes internos.",
        "Implementar tomadas inteligentes com desligamento automático.",
        "Adicionar termostatos inteligentes com controle remoto.",
        "Conectar equipamentos ao sistema de desligamento automático.",
        "Automatizar cortinas com sensor de luminosidade.",
        "Instalar sensores crepusculares para iluminação adaptativa.",
        "Substituir aparelhos por modelos Procel A conectados.",
        "Instalar medidores inteligentes com painel em nuvem.",
        "Programar uso de energia na tarifa branca."
    };

    // inicia o processo de evolução com uma casa específica
    public void evoluir(CasaBehaviour casa)
    {
        casaB = casa;

        System.Random random = new System.Random();

        // verifica se a casa é válida e tem problemas
        if (casa == null || casa.problemaCasa.Count == 0)
        {
            // se não houver problemas, encerra a função
            return;
        }

        // sorteia um índice aleatório de problema da casa
        int problemaIndex = random.Next(0, casa.problemaCasa.Count);
        indiceProblemaAtual = problemaIndex;

        // seleciona o problema e a solução correta
        string problemaSelecionado = casa.problemaCasa[problemaIndex];
        solucaoCorretaAtual = casa.solucao[problemaIndex];

        // mostra o problema na interface
        problemaParaSolucionar.text = problemaSelecionado;

        // cria uma lista de alternativas e começa com a correta
        List<string> alternativas = new List<string> { solucaoCorretaAtual };

        // adiciona alternativas falsas sem repetir
        while (alternativas.Count < 4)
        {
            string falsa = todasAsSolucoes[random.Next(0, todasAsSolucoes.Length)];
            if (!alternativas.Contains(falsa))
            {
                alternativas.Add(falsa);
            }
        }

        // embaralha as alternativas
        for (int i = 0; i < alternativas.Count; i++)
        {
            int j = random.Next(i, alternativas.Count);
            (alternativas[i], alternativas[j]) = (alternativas[j], alternativas[i]);
        }

        // atribui as alternativas aos textos
        alternativaA.text = alternativas[0];
        alternativaB.text = alternativas[1];
        alternativaC.text = alternativas[2];
        alternativaD.text = alternativas[3];
    }

    // métodos para verificar cada botão de resposta
    public void VerificarRespostaA() => Verificar(alternativaA.text, botaoA);
    public void VerificarRespostaB() => Verificar(alternativaB.text, botaoB);
    public void VerificarRespostaC() => Verificar(alternativaC.text, botaoC);
    public void VerificarRespostaD() => Verificar(alternativaD.text, botaoD);

    // método principal para verificar a resposta escolhida
    private void Verificar(string respostaEscolhida, Button botaoSelecionado)
    {
        // verifica se a resposta está correta
        if (respostaEscolhida == solucaoCorretaAtual)
        {
            // resposta correta: reseta cores e fecha o menu
            botaoA.image.color = Color.black;
            botaoB.image.color = Color.black;
            botaoC.image.color = Color.black;
            botaoD.image.color = Color.black;

            // fecha o menu de problemas
            menuProblema.SetActive(false);

            // diminui contador global de problemas
            gameManager.GetComponent<GameManager>().problemaCidade -= 1;

            // se o mouse estiver ativo, trava novamente o cursor
            if (cam.GetComponent<RayCast>().mouseAtivo == true)
            {
                cam.GetComponent<RayCast>().mouseAtivo = false;
                Cursor.lockState = CursorLockMode.Locked;
                cam.GetComponent<RayCast>().painelDesativo = true;
            }

            // se for um problema de energia
            if (gameManager.GetComponent<GameManager>().solucoesLuz.Contains(solucaoCorretaAtual))
            {
                // reduz consumo da casa e da cidade em 20%
                casaB.consumoEnergiaTotal -= casaB.consumoEnergiaTotal * 0.2f;
                gameManager.GetComponent<GameManager>().energiaCidade -= casaB.consumoEnergiaTotal * 0.2f;
            }
            else
            {
                // se for problema de água, reduz consumo também
                casaB.consumoAguaTotal -= casaB.consumoAguaTotal * 0.2f;
                gameManager.GetComponent<GameManager>().aguaCidade -= casaB.consumoAguaTotal * 0.2f;
            }

            // diminui número total de problemas na casa
            casaB.totalProblemas--;

            // remove o problema resolvido da lista
            casaB.problemaCasa.RemoveAt(indiceProblemaAtual);
            casaB.solucao.RemoveAt(indiceProblemaAtual);

            // reduz o número de upgrades restantes no dia
            upgrade.GetComponent<SkyboxDayCycle>().upgradesHoje--;
        }
        else
        {
            // resposta errada: muda a cor do botão para vermelho
            botaoSelecionado.image.color = Color.red;
        }
    }
}
