using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetInteraction : MonoBehaviour
{
    public float detectionRadius = 1.5f; // Raio de detecção da nave
    private bool hasArrived = false;    // Controla se a nave já chegou

    public DialogController dialogController; // Referência ao controlador de diálogo

      private string[] perguntas =
    {
        "Este é o menor planeta do sistema solar e também o mais próximo do Sol. Qual é ele?",
        "Este planeta tem uma atmosfera densa e é conhecido como o planeta mais quente do sistema solar. Qual é ele?",
        "Chamado de Planeta Azul, é o único conhecido por abrigar vida. Qual é ele?",
        "Este planeta é conhecido como o Planeta Vermelho por causa de sua superfície rica em óxido de ferro. Qual é ele?",
        "O maior planeta do sistema solar, conhecido por sua Grande Mancha Vermelha. Qual é ele?",
        "Este planeta é famoso por seus belos anéis feitos de gelo e rochas. Qual é ele?",
        "Este planeta tem um eixo de rotação inclinado, o que faz com que ele 'role' ao longo de sua órbita. Qual é ele?",
        "Este planeta é o mais distante do Sol e tem ventos extremamente fortes. Qual é ele?"
    };

        private string[,] opcoesRespostas =
    {
        { "Vênus", "Mercúrio", "Terra" },    // Respostas para Mercúrio
        { "Júpiter", "Marte", "Vênus" },    // Respostas para Vênus
        { "Terra", "Saturno", "Urano" },    // Respostas para Terra
        { "Netuno", "Marte", "Mercúrio" },  // Respostas para Marte
        { "Júpiter", "Saturno", "Urano" },  // Respostas para Júpiter
        { "Saturno", "Júpiter", "Netuno" }, // Respostas para Saturno
        { "Urano", "Terra", "Mercúrio" },   // Respostas para Urano
        { "Marte", "Vênus", "Netuno" }      // Respostas para Netuno
    };

    private int[] respostasCorretas = { 1, 2, 0, 1, 0, 0, 0, 2 };

    public Button opc1;
    public Button opc2;
    public Button opc3;


    void Update()
    {
        if (!hasArrived)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance <= detectionRadius)
                {
                    hasArrived = true;
                    OpenPlanetDialog(); // Mostra o diálogo
                }
            }
        }
    }

    void OpenPlanetDialog()
    {
        // Obtém o nome da cena atual
        string nomeCenaAtual = SceneManager.GetActiveScene().name;

        // Identifica a fase com base no nome da cena
        int faseAtual;
        if (int.TryParse(nomeCenaAtual.Replace("fase", ""), out faseAtual) && faseAtual >= 1 && faseAtual <= 8)
        {
            string perguntaAtual = perguntas[faseAtual - 1]; // Obtém a pergunta correspondente à fase
            int perguntaIndex = faseAtual - 1;
            if (dialogController != null)
            {
                dialogController.ShowDialog(perguntaAtual); // Mostra a pergunta no diálogo

                opc1.GetComponentInChildren<TextMeshProUGUI>().text = opcoesRespostas[perguntaIndex, 0];
                opc2.GetComponentInChildren<TextMeshProUGUI>().text = opcoesRespostas[perguntaIndex, 1];
                opc3.GetComponentInChildren<TextMeshProUGUI>().text = opcoesRespostas[perguntaIndex, 2];


                opc1.onClick.RemoveAllListeners();
                opc2.onClick.RemoveAllListeners();
                opc3.onClick.RemoveAllListeners();

                opc1.onClick.AddListener(() => VerificarResposta(perguntaIndex, 0));
                opc2.onClick.AddListener(() => VerificarResposta(perguntaIndex, 1));
                opc3.onClick.AddListener(() => VerificarResposta(perguntaIndex, 2));
            }
            else
            {
                Debug.LogError("DialogController não foi configurado no planeta!");
            }
        }
        else
        {
            Debug.LogError("A cena atual não corresponde a uma fase válida.");
        }
    }

void VerificarResposta(int perguntaIndex, int respostaSelecionada)
{
    if (respostaSelecionada == respostasCorretas[perguntaIndex])
    {
        Debug.Log("Resposta correta!");
        dialogController.CloseDialog();
        // Avançar para a próxima fase
        int proximaFase = SceneManager.GetActiveScene().buildIndex + 1;

        // Verifica se existe uma próxima fase
        if (proximaFase < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaFase); // Carrega a próxima cena
        }
        else
        {
            Debug.Log("Você completou todas as fases!"); // Última fase
        }
    }
    else
    {
        Debug.Log("Resposta incorreta. Tente novamente.");
    }
}


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
