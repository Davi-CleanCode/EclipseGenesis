
using UnityEngine;

public class PredarBoss : MonoBehaviour
{
    public int maxIntegrity = 1000;
    public int corruptionLevel = 0;

    int currentIntegrity;

    void Start()
    {
        currentIntegrity = maxIntegrity;
    }

    public void ApplyDamage(int amount)
    {
        currentIntegrity -= amount;
        UpdatePhase();
        if (currentIntegrity <= 0) OnDefeated();
    }

    void UpdatePhase()
    {
        float ratio = (float)currentIntegrity / maxIntegrity;
        if (ratio < 0.66f) EnterPhaseTwo();
        if (ratio < 0.33f) EnterPhaseThree();
    }

    void EnterPhaseTwo()
    {
        Debug.Log("Predar entra na Fase 2: a corrupção consome o campo.");
    }

    void EnterPhaseThree()
    {
        Debug.Log("Predar entra na Fase 3: a fome cósmica desperta totalmente.");
    }

    void OnDefeated()
    {
        Debug.Log("Predar foi destruído. O ciclo pode enfim se quebrar...");
        NarrativeManager.Instance.TriggerEvent("PredarDefeated");
    }
}
