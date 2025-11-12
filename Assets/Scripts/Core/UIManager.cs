
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);
    }

    public void UpdateHealth(int current, int max)
    {
        Debug.Log($"HP: {current}/{max}");
    }

    public void ShowPause(bool show)
    {
        Debug.Log("Pausa: " + show);
    }

    public void ShowGameOver()
    {
        Debug.Log("Tela de Game Over exibida.");
    }

    public void ShowFinalChoices()
    {
        Debug.Log("Mostrando escolhas finais ao jogador...");
    }
}
