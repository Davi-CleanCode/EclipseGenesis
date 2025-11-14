using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : StatsBase
{
    [Header("Player Settings")]
    [Tooltip("Tempo de invencibilidade específico para o player (substitui iFrameDuration se > 0)")]
    [SerializeField] private float playerIFrame = 1.0f;

    [Header("Respawn")]
    [Tooltip("Transform de respawn (opcional)")]
    public Transform respawnPoint;

    public UnityEvent OnPlayerDeathUI; // pode ligar menus no inspector
    public event Action OnPlayerRespawned;

    protected override void Awake()
    {
        base.Awake();

        if (playerIFrame > 0f)
            iFrameDuration = playerIFrame;
    }

    protected override void Die()
    {
        base.Die();
        // lógica de morte do player
        Debug.Log($"{gameObject.name} morreu.");
        OnPlayerDeathUI?.Invoke();

        // exemplo: chamar GameManager.GameOver() se tiver
        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();
    }

    /// <summary>
    /// Respawn simples — teleporta e restaura vida (pode ser chamado por GameManager).
    /// </summary>
    public void Respawn()
    {
        if (respawnPoint != null)
            transform.position = respawnPoint.position;

        RestoreFull();
        // breve invencibilidade ao respawn
        if (iFrameDuration > 0f)
            StartCoroutine(InvulnerabilityCoroutine(iFrameDuration));

        OnPlayerRespawned?.Invoke();
    }

    /// <summary>
    /// Método de utilidade para aplicar dano vindo do inimigo.
    /// </summary>
    public void ReceiveEnemyHit(int damage, Transform attacker, float knockbackForce = 5f)
    {
        Vector2 direction = (transform.position - attacker.position).normalized;
        TakeDamage(damage, direction, knockbackForce);
    }
}
