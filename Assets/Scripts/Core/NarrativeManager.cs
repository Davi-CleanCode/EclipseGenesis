
using UnityEngine;
using System.Collections.Generic;

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager Instance { get; private set; }

    Dictionary<string, System.Action> events = new Dictionary<string, System.Action>();

    void Awake()
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        events["PredarDefeated"] = OnPredarDefeated;
    }

    public void TriggerEvent(string key)
    {
        if (events.ContainsKey(key)) events[key]?.Invoke();
        else Debug.LogWarning("Evento não encontrado: " + key);
    }

    void OnPredarDefeated()
    {
        Debug.Log("O Predar foi derrotado. O destino de Kael'Thar e da Terra está em suas mãos.");
        UIManager.Instance.ShowFinalChoices();
    }
}
