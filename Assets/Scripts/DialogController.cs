using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public GameObject dialogPanel; // Referência ao painel de diálogo
    public TextMeshProUGUI dialogText; // Referência ao texto do diálogo

    private bool isDialogOpen = false; // Controla se o diálogo está aberto

    public void ShowDialog(string message)
    {
        if (!isDialogOpen)
        {
            dialogPanel.SetActive(true); // Mostra o painel
            dialogText.text = message;  // Atualiza o texto do diálogo
            isDialogOpen = true;        // Marca que o diálogo está aberto
        }
    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false); // Esconde o painel
        isDialogOpen = false;         // Marca que o diálogo está fechado
    }
}
