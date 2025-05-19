using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

// classe que gerencia o jogo e os dados globais da cidade
public class GameManager : MonoBehaviour
{
    // variáveis de controle da cidade
    int somaTipo = 0;
    int totalProblemas = 0;
    public float aguaCidade = 0.0f;
    public double energiaCidade = 0.0;
    public int pessoas = 0;
    public int problemaCidade = 0;

    // referências de UI
    public TMP_Text aguaCidadeTotal;
    public TMP_Text energiaCidadeTotal;
    public TMP_Text moradoresText;
    public TMP_Text problemasCidade;

    // listas de problemas relacionados à energia
    string[] problemasLuz = new string[]
    {
        "Consumo elevado de energia durante a noite.",
        "Luzes permanecem acesas em ambientes desocupados.",
        "Equipamentos eletrônicos permanecem em stand-by por longos períodos.",
        "Ares-condicionados operam com temperatura excessivamente baixa.",
        "Computadores e monitores são deixados ligados sem uso.",
        "Uso constante de luz artificial durante o dia.",
        "Excesso de iluminação em áreas externas após o horário necessário.",
        "Equipamentos antigos consomem mais energia.",
        "Ausência de controle sobre o consumo em tempo real.",
        "Uso desorganizado de eletrodomésticos de alto consumo."
    };

    // soluções para problemas de água
    string[] solucoesComAgua = new string[]
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
        "Utilizar hidrômetros inteligentes com alertas de consumo."
    };

    // soluções para problemas de energia
    public string[] solucoesLuz = new string[]
    {
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

    // problemas relacionados ao uso da água
    public string[] problemasComAgua = new string[]
    {
        "Banhos prolongados causam alto consumo.",
        "Torneiras permanecem abertas durante escovação ou lavagem.",
        "Calçadas são lavadas com mangueira em vez de vassoura.",
        "Carros são lavados com mangueira continuamente aberta.",
        "Máquinas de lavar operam com carga incompleta.",
        "Vazamentos passam despercebidos.",
        "Lavagem de louça consome muita água.",
        "Água da chuva não é aproveitada.",
        "Descargas com desperdício.",
        "Falta de visibilidade do consumo hídrico."
    };

    void Start()
    {
        // busca todas as casas presentes na cena com a tag "casas"
        GameObject[] objetosDeCasa = GameObject.FindGameObjectsWithTag("casas");
        System.Random random = new System.Random();

        // verifica se há exatamente 26 casas na cena
        if (objetosDeCasa.Length != 26)
        {
            Debug.LogWarning($"Esperado 26 casas, mas foram encontradas {objetosDeCasa.Length} com a tag 'casas'. Verifique na cena.");
        }

        // inicializa os dados de cada casa
        foreach (GameObject obj in objetosDeCasa)
        {
            somaTipo = 0;
            totalProblemas = 0;
            CasaBehaviour casa = obj.GetComponent<CasaBehaviour>();

            if (casa != null)
            {
                int moradores = random.Next(2, 6); // número de moradores entre 2 e 5
                pessoas += moradores;

                int consumoAgua = 0;
                int consumoEnergia = 0;
                double mediaTipos = 0;
                List<int> tipos = new List<int>();
                List<string> problemaCasa = new List<string>();
                List<string> solucoesCasa = new List<string>();

                // define o tipo de consumo para cada morador
                for (int i = 0; i < moradores; i++)
                {
                    int tipo = random.Next(1, 4); // tipo entre 1 e 3
                    tipos.Add(tipo);
                    somaTipo += tipo;

                    // define consumo com base no tipo
                    switch (tipo)
                    {
                        case 1:
                            consumoAgua += 110;
                            energiaCidade += 80;
                            consumoEnergia += 80;
                            aguaCidade += 110;
                            break;
                        case 2:
                            consumoAgua += 166;
                            energiaCidade += 155;
                            consumoEnergia += 155;
                            aguaCidade += 166;
                            break;
                        case 3:
                            consumoAgua += 300;
                            energiaCidade += 300;
                            consumoEnergia += 300;
                            aguaCidade += 300;
                            break;
                    }
                }

                // calcula a média dos tipos de consumo
                mediaTipos = (double)somaTipo / moradores;

                // define quantos problemas a casa terá com base na média
                if (mediaTipos > 2.5) totalProblemas = 3;
                else if (mediaTipos > 1.7) totalProblemas = 2;
                else totalProblemas = 1;

                problemaCidade += totalProblemas;

                // adiciona problemas e soluções sem repetir
                for (int i = 0; i < totalProblemas; i++)
                {
                    int qualProblema = random.Next(1, 3); // 1 = água, 2 = luz
                    int numNaArray = random.Next(0, 10);

                    string problemaSelecionado;
                    string solucaoSelecionada;

                    if (qualProblema == 1)
                    {
                        problemaSelecionado = problemasComAgua[numNaArray];
                        solucaoSelecionada = solucoesComAgua[numNaArray];
                    }
                    else
                    {
                        problemaSelecionado = problemasLuz[numNaArray];
                        solucaoSelecionada = solucoesLuz[numNaArray];
                    }

                    // garante que não haja problemas repetidos
                    if (!problemaCasa.Contains(problemaSelecionado))
                    {
                        problemaCasa.Add(problemaSelecionado);
                        solucoesCasa.Add(solucaoSelecionada);
                        Debug.Log($"Problema adicionado à casa {casa.name}: {problemaSelecionado}");
                        Debug.Log($"Solução adicionada à casa {casa.name}: {solucaoSelecionada}");
                    }
                    else
                    {
                        i--; // tenta novamente se for repetido
                    }
                }

                // inicializa os dados da casa
                casa.Inicializar(moradores, tipos, mediaTipos, totalProblemas, consumoAgua, consumoEnergia, problemaCasa, solucoesCasa);
            }
            else
            {
                Debug.LogError($"GameObject '{obj.name}' não tem o script CasaBehaviour.");
            }
        }

    }

    void Update()
    {
        // atualiza a UI da cidade em tempo real
        aguaCidadeTotal.text = Mathf.RoundToInt(aguaCidade).ToString() + "L/dia";
        energiaCidadeTotal.text = Math.Round(energiaCidade).ToString() + "KW/dia";
        moradoresText.text = pessoas + " moradores";
        problemasCidade.text = problemaCidade.ToString() + " problemas";
    }
}
