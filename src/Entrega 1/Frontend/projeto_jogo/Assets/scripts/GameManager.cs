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
    "Consumo elevado de energia durante a noite. Solu��o: substitua todas as l�mpadas incandescentes por modelos LED conectados a sensores de presen�a.",
    "Luzes permanecem acesas em ambientes desocupados. Solu��o: instale sensores de presen�a integrados ao sistema de automa��o predial.",
    "Equipamentos eletr�nicos permanecem em stand-by por longos per�odos. Solu��o: implemente tomadas inteligentes com desligamento autom�tico program�vel.",
    "Ares-condicionados operam com temperatura excessivamente baixa. Solu��o: adote termostatos inteligentes com controle remoto via aplicativo.",
    "Computadores e monitores s�o deixados ligados sem uso. Solu��o: integre os equipamentos a um sistema de gerenciamento de energia que desligue automaticamente ap�s inatividade.",
    "Uso constante de luz artificial durante o dia. Solu��o: automatize a abertura de cortinas com sensores de luminosidade externa.",
    "Excesso de ilumina��o em �reas externas ap�s o hor�rio necess�rio. Solu��o: instale sensores crepusculares que ajustem a ilumina��o conforme a luz natural.",
    "Equipamentos antigos consomem mais energia. Solu��o: substitua por aparelhos com selo Procel A e integre ao sistema de monitoramento energ�tico.",
    "Aus�ncia de controle sobre o consumo em tempo real. Solu��o: implemente medidores inteligentes com dashboards em nuvem para acompanhamento di�rio.",
    "Uso desorganizado de eletrodom�sticos de alto consumo. Solu��o: adote programa��o inteligente para opera��o de equipamentos nos hor�rios de menor tarifa (tarifa branca)."
};

    string[] problemasComAgua = new string[]
{
    "Banhos prolongados causam alto consumo. Solu��o: instale chuveiros inteligentes com controle de tempo e temperatura.",
    "Torneiras permanecem abertas durante escova��o ou lavagem. Solu��o: utilize torneiras com sensores de presen�a para ativa��o autom�tica.",
    "Cal�adas s�o lavadas com mangueira em vez de vassoura. Solu��o: implemente sistemas de limpeza urbana com �gua de reuso e jatos de alta press�o controlados.",
    "Carros s�o lavados com mangueira continuamente aberta. Solu��o: substitua o processo por lavadoras com sistema de recircula��o de �gua.",
    "M�quinas de lavar operam com carga incompleta. Solu��o: conecte a eletrodom�sticos inteligentes que s� iniciam ciclos com carga ideal detectada.",
    "Vazamentos passam despercebidos. Solu��o: adote sensores de vazamento integrados � rede hidr�ulica com notifica��es em tempo real.",
    "Lavagem de lou�a consome muita �gua. Solu��o: instale arejadores nas torneiras e sensores que interrompam o fluxo automaticamente.",
    "�gua da chuva n�o � aproveitada. Solu��o: implemente cisternas inteligentes com filtragem e redistribui��o para uso n�o pot�vel.",
    "Descargas com desperd�cio. Solu��o: substitua por vasos sanit�rios com descarga inteligente de volume duplo e monitoramento por app.",
    "Falta de visibilidade do consumo h�drico. Solu��o: use hidr�metros inteligentes conectados � rede IoT com alertas de consumo excessivo."
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
                    int tipo = random.Next(1, 4); // 1 = Econ�mico, 2 = M�dio, 3 = Alto
                    tipos.Add(tipo);
                    somaTipo += tipo;

                    switch (tipo)
                    {
                        case 1: // Econ�mico
                            consumoAgua += 110; // �gua: 110L/dia
                            consumoEnergia += 80; // Energia: 80kWh/m�s
                            break;
                        case 2: // M�dio
                            consumoAgua += 166; // �gua: 166L/dia
                            consumoEnergia += 155; // Energia: 155kWh/m�s
                            break;
                        case 3: // Alto
                            consumoAgua += 300; // �gua: 300L/dia
                            consumoEnergia += 300; // Energia: 300kWh/m�s
                            break;
                    }
                }

               

                mediaTipos = (double)somaTipo / moradores;
                Debug.Log("GameMannager"+mediaTipos);
               
                // Converte o consumo mensal de energia para di�rio (dividido por 30 dias)
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
                    int qualProblema = random.Next(1, 3); // 1 = �gua, 2 = luz
                    int numNaArray = random.Next(0, 10);  // �ndices de 0 a 9

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
                Debug.LogError($"GameObject '{obj.name}' n�o tem o script CasaBehaviour.");
            }
        }
    }
}
