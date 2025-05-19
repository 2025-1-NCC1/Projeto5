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
    // refer�ncia para o painel de problemas
    public GameObject menuProblema;

    // bot�o do upgrade
    public Button evoluirBotao;

    // textos para exibir o problema e as alternativas
    public TMP_Text problemaParaSolucionar;
    public TMP_Text alternativaA;
    public TMP_Text alternativaB;
    public TMP_Text alternativaC;
    public TMP_Text alternativaD;

    // refer�ncia para o GameManager
    public GameManager gameManager;

    // bot�es das alternativas
    public Button botaoA;
    public Button botaoB;
    public Button botaoC;
    public Button botaoD;

    // refer�ncia ao sistema de upgrade
    public GameObject upgrade;

    // contador global de problemas na cidade
    public int problemaCidade = 0;

    // refer�ncia � casa atual
    CasaBehaviour casaB;

    // c�mera principal
    public Camera cam;

    // armazena a solu��o correta do problema atual
    private string solucaoCorretaAtual = "";

    // �ndice do problema atual na lista
    private int indiceProblemaAtual = -1;

    // lista com todas as solu��es poss�veis (corretas e incorretas)
    string[] todasAsSolucoes = new string[]
    {
        "Instalar chuveiros inteligentes com controle de uso.",
        "Adicionar torneiras com sensor de presen�a autom�tica.",
        "Implementar limpeza urbana com �gua de reuso.",
        "Substituir lavadoras por modelos com recircula��o.",
        "Conectar eletrodom�sticos que detectam carga ideal.",
        "Instalar sensores de vazamento com alerta imediato.",
        "Adicionar arejadores e sensores em torneiras.",
        "Implantar cisternas inteligentes com filtragem integrada.",
        "Substituir descargas por modelos inteligentes e conectados.",
        "Utilizar hidr�metros inteligentes com alertas de consumo.",
        "Substituir l�mpadas por LED com sensores.",
        "Instalar sensores de presen�a em ambientes internos.",
        "Implementar tomadas inteligentes com desligamento autom�tico.",
        "Adicionar termostatos inteligentes com controle remoto.",
        "Conectar equipamentos ao sistema de desligamento autom�tico.",
        "Automatizar cortinas com sensor de luminosidade.",
        "Instalar sensores crepusculares para ilumina��o adaptativa.",
        "Substituir aparelhos por modelos Procel A conectados.",
        "Instalar medidores inteligentes com painel em nuvem.",
        "Programar uso de energia na tarifa branca."
    };

    // inicia o processo de evolu��o com uma casa espec�fica
    public void evoluir(CasaBehaviour casa)
    {
        casaB = casa;

        System.Random random = new System.Random();

        // verifica se a casa � v�lida e tem problemas
        if (casa == null || casa.problemaCasa.Count == 0)
        {
            // se n�o houver problemas, encerra a fun��o
            return;
        }

        // sorteia um �ndice aleat�rio de problema da casa
        int problemaIndex = random.Next(0, casa.problemaCasa.Count);
        indiceProblemaAtual = problemaIndex;

        // seleciona o problema e a solu��o correta
        string problemaSelecionado = casa.problemaCasa[problemaIndex];
        solucaoCorretaAtual = casa.solucao[problemaIndex];

        // mostra o problema na interface
        problemaParaSolucionar.text = problemaSelecionado;

        // cria uma lista de alternativas e come�a com a correta
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

    // m�todos para verificar cada bot�o de resposta
    public void VerificarRespostaA() => Verificar(alternativaA.text, botaoA);
    public void VerificarRespostaB() => Verificar(alternativaB.text, botaoB);
    public void VerificarRespostaC() => Verificar(alternativaC.text, botaoC);
    public void VerificarRespostaD() => Verificar(alternativaD.text, botaoD);

    // m�todo principal para verificar a resposta escolhida
    private void Verificar(string respostaEscolhida, Button botaoSelecionado)
    {
        // verifica se a resposta est� correta
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
                // se for problema de �gua, reduz consumo tamb�m
                casaB.consumoAguaTotal -= casaB.consumoAguaTotal * 0.2f;
                gameManager.GetComponent<GameManager>().aguaCidade -= casaB.consumoAguaTotal * 0.2f;
            }

            // diminui n�mero total de problemas na casa
            casaB.totalProblemas--;

            // remove o problema resolvido da lista
            casaB.problemaCasa.RemoveAt(indiceProblemaAtual);
            casaB.solucao.RemoveAt(indiceProblemaAtual);

            // reduz o n�mero de upgrades restantes no dia
            upgrade.GetComponent<SkyboxDayCycle>().upgradesHoje--;
        }
        else
        {
            // resposta errada: muda a cor do bot�o para vermelho
            botaoSelecionado.image.color = Color.red;
        }
    }
}
