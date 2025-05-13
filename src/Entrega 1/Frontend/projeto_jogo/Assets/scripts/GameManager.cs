using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    int somaTipo = 0;
    int totalProblemas = 0;
    string[] problemasLuz = new string[]
{
    "Consumo elevado de energia durante a noite. Solução: substitua todas as lâmpadas incandescentes por modelos LED conectados a sensores de presença.",
    "Luzes permanecem acesas em ambientes desocupados. Solução: instale sensores de presença integrados ao sistema de automação predial.",
    "Equipamentos eletrônicos permanecem em stand-by por longos períodos. Solução: implemente tomadas inteligentes com desligamento automático programável.",
    "Ares-condicionados operam com temperatura excessivamente baixa. Solução: adote termostatos inteligentes com controle remoto via aplicativo.",
    "Computadores e monitores são deixados ligados sem uso. Solução: integre os equipamentos a um sistema de gerenciamento de energia que desligue automaticamente após inatividade.",
    "Uso constante de luz artificial durante o dia. Solução: automatize a abertura de cortinas com sensores de luminosidade externa.",
    "Excesso de iluminação em áreas externas após o horário necessário. Solução: instale sensores crepusculares que ajustem a iluminação conforme a luz natural.",
    "Equipamentos antigos consomem mais energia. Solução: substitua por aparelhos com selo Procel A e integre ao sistema de monitoramento energético.",
    "Ausência de controle sobre o consumo em tempo real. Solução: implemente medidores inteligentes com dashboards em nuvem para acompanhamento diário.",
    "Uso desorganizado de eletrodomésticos de alto consumo. Solução: adote programação inteligente para operação de equipamentos nos horários de menor tarifa (tarifa branca)."
};

    string[] problemasComAgua = new string[]
{
    "Banhos prolongados causam alto consumo. Solução: instale chuveiros inteligentes com controle de tempo e temperatura.",
    "Torneiras permanecem abertas durante escovação ou lavagem. Solução: utilize torneiras com sensores de presença para ativação automática.",
    "Calçadas são lavadas com mangueira em vez de vassoura. Solução: implemente sistemas de limpeza urbana com água de reuso e jatos de alta pressão controlados.",
    "Carros são lavados com mangueira continuamente aberta. Solução: substitua o processo por lavadoras com sistema de recirculação de água.",
    "Máquinas de lavar operam com carga incompleta. Solução: conecte a eletrodomésticos inteligentes que só iniciam ciclos com carga ideal detectada.",
    "Vazamentos passam despercebidos. Solução: adote sensores de vazamento integrados à rede hidráulica com notificações em tempo real.",
    "Lavagem de louça consome muita água. Solução: instale arejadores nas torneiras e sensores que interrompam o fluxo automaticamente.",
    "Água da chuva não é aproveitada. Solução: implemente cisternas inteligentes com filtragem e redistribuição para uso não potável.",
    "Descargas com desperdício. Solução: substitua por vasos sanitários com descarga inteligente de volume duplo e monitoramento por app.",
    "Falta de visibilidade do consumo hídrico. Solução: use hidrômetros inteligentes conectados à rede IoT com alertas de consumo excessivo."
};
   


    void Start()
    {
        GameObject[] objetosDeCasa = GameObject.FindGameObjectsWithTag("casas");
        System.Random random = new System.Random();

        if (objetosDeCasa.Length != 26)
        {
            Debug.LogWarning($"Esperado 26 casas, mas foram encontradas {objetosDeCasa.Length} com a tag 'casas'. Verifique na cena.");
        }

        foreach (GameObject obj in objetosDeCasa)
        {
            somaTipo = 0;
            totalProblemas = 0;
            CasaBehaviour casa = obj.GetComponent<CasaBehaviour>();

            if (casa != null)
            {
                int moradores = random.Next(2, 6); // Entre 1 e 5 moradores
                int consumoAgua = 0;
                int consumoEnergia = 0;
                double mediaTipos = 0;
                List<int> tipos = new List<int>();
                List<string> problemasAgua = new List<string>();
                List<string> problemaCasa = new List<string>();
                List<string> problemasEnergia = new List<string>();
                // Aleatoriedade para distribuir tipos de consumo
                for (int i = 0; i < moradores; i++)
                {
                    int tipo = random.Next(1, 4); // 1 = Econômico, 2 = Médio, 3 = Alto
                    tipos.Add(tipo);
                    somaTipo += tipo;

                    switch (tipo)
                    {
                        case 1: // Econômico
                            consumoAgua += 110; // Água: 110L/dia
                            consumoEnergia += 80; // Energia: 80kWh/mês
                            break;
                        case 2: // Médio
                            consumoAgua += 166; // Água: 166L/dia
                            consumoEnergia += 155; // Energia: 155kWh/mês
                            break;
                        case 3: // Alto
                            consumoAgua += 300; // Água: 300L/dia
                            consumoEnergia += 300; // Energia: 300kWh/mês
                            break;
                    }
                }

               

                mediaTipos = (double)somaTipo / moradores;
                Debug.Log("GameMannager"+mediaTipos);
               
                // Converte o consumo mensal de energia para diário (dividido por 30 dias)
                consumoEnergia /= 30;

                //Poblemas 
                if(mediaTipos > 2.5) {
                        totalProblemas = 4;
                }
                else if(mediaTipos > 1.7) {
                        totalProblemas = 3;
                }
                else {
                        totalProblemas = 2;
                }

                for (int i = 0; i < totalProblemas; i++)
                {
                    int qualProblema = random.Next(1, 3); // 1 = água, 2 = luz
                    int numNaArray = random.Next(0, 10);  // índices de 0 a 9

                    string problemaSelecionado;

                    if (qualProblema == 1)
                    {
                        problemaSelecionado = problemasComAgua[numNaArray];
                    }
                    else
                    {
                        problemaSelecionado = problemasLuz[numNaArray];
                    }

                    
                    if (!problemasAgua.Contains(problemaSelecionado))
                    {
                        problemasAgua.Add(problemaSelecionado);
                        Debug.Log("problema adcionado na casa" + casa.name + " o problema foi " + problemaSelecionado);
                    }
                    else
                    {
                        
                        i--;
                    }
                }

                problemaCasa = problemasAgua.Concat(problemasEnergia).ToList();

                // Inicializa a casa com os valores calculados
                casa.Inicializar(moradores, tipos, mediaTipos, totalProblemas, consumoAgua, consumoEnergia, problemaCasa);
            
            }
            else
            {
                Debug.LogError($"GameObject '{obj.name}' não tem o script CasaBehaviour.");
            }
        }
    }
}
