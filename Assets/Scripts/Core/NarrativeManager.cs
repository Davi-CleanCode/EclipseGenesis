using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public delegate void OnDialogueEnd();
    public OnDialogueEnd onDialogueEndCallback;

    public void StartDialogue(string[] linhas)
    {
        // Aqui você pode integrar com UI futuramente
        Debug.Log("INICIANDO DIÁLOGO:");

        foreach (string linha in linhas)
        {
            Debug.Log(linha);
        }

        onDialogueEndCallback?.Invoke();
    }
}

