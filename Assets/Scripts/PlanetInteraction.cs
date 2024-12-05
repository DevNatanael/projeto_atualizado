using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    public float detectionRadius = 1.5f; // Raio de detecção da nave
    private bool hasArrived = false;    // Controla se a nave já chegou

    public DialogController dialogController; // Referência ao controlador de diálogo

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
        if (dialogController != null)
        {
            dialogController.ShowDialog("Bem-vindo ao planeta Mercúrio! Este é o menor e mais próximo planeta do Sol.");
        }
        else
        {
            Debug.LogError("DialogController não foi configurado no planeta!");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
