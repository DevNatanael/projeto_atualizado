using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGamePanel()
    {
        SceneManager.LoadScene("fase1"); // Reinicia a primeira fase
    }
}
