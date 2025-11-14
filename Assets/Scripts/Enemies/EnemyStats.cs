using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : StatsBase
{
    [Header("Enemy Settings")]
    [SerializeField] private int scoreOnDeath = 10;
    [Tooltip("Tempo de imobilização após levar dano (knockback stun)")]
    [SerializeField] private float stunDuration = 0.15f;

    public UnityEvent OnEnemyDied; // ligar efeitos, partículas, etc.

    protected override void Die()
    {
        base.Die();
        Debug.Log($"{gameObject.name} derrotado.");

        // acionamento de eventos visuais/sons
        OnEnemyDied?.Invoke();

        // ex: pontuação
        ScoreManager.Instance?.AddScore(scoreOnDeath);

        // destroi o inimigo (ou trocar por prefab de cadáver)
        Destroy(gameObject);
    }

    public override void TakeDamage(int damage, Vector2 hitDirection, float knockbackForce = 0f)
    {
        if (IsDead || IsInvulnerable) return;

        base.TakeDamage(damage, hitDirection, knockbackForce);

        // aplicar stun/tempo curto (desativa IA por Xs) - simples exemplo
        var ai = GetComponent<EnemyAI>();
        if (ai != null)
            ai.Stun(stunDuration);
    }
}
