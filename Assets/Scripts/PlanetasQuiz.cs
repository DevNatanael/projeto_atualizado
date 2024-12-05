using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string enunciado;
    public string[] opcoes;
    public int respostaCorreta; // Índice da resposta correta no array "opcoes"
}

public class PlanetasQuiz : MonoBehaviour
{
    public List<Question> perguntas = new List<Question>
    {
        new Question
        {
            enunciado = "Este é o menor planeta do sistema solar e também o mais próximo do Sol. Qual é ele?",
            opcoes = new string[] { "Mercúrio", "Marte", "Vênus" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "Este planeta tem uma atmosfera densa e é conhecido como o planeta mais quente do sistema solar. Qual é ele?",
            opcoes = new string[] { "Vênus", "Mercúrio", "Terra" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "Chamado de Planeta Azul, é o único conhecido por abrigar vida. Qual é ele?",
            opcoes = new string[] { "Marte", "Terra", "Netuno" },
            respostaCorreta = 1
        },
        new Question
        {
            enunciado = "Este planeta é conhecido como o Planeta Vermelho por causa de sua superfície rica em óxido de ferro. Qual é ele?",
            opcoes = new string[] { "Marte", "Vênus", "Júpiter" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "O maior planeta do sistema solar, conhecido por sua Grande Mancha Vermelha. Qual é ele?",
            opcoes = new string[] { "Júpiter", "Saturno", "Urano" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "Este planeta é famoso por seus belos anéis feitos de gelo e rochas. Qual é ele?",
            opcoes = new string[] { "Saturno", "Júpiter", "Urano" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "Este planeta tem um eixo de rotação inclinado, o que faz com que ele 'role' ao longo de sua órbita. Qual é ele?",
            opcoes = new string[] { "Urano", "Netuno", "Saturno" },
            respostaCorreta = 0
        },
        new Question
        {
            enunciado = "Este planeta é o mais distante do Sol e tem ventos extremamente fortes. Qual é ele?",
            opcoes = new string[] { "Netuno", "Urano", "Júpiter" },
            respostaCorreta = 0
        }
    };
}
