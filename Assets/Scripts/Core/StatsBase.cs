using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class StatsBase : MonoBehaviour
{
    [Header("Stats Base")]
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth = 100;

    [Header("Invencibilidade")]
    [Tooltip("Tempo (s) de invencibilidade após sofrer dano")]
    [SerializeField] protected float iFrameDuration = 0.5f;
    protected bool isInvulnerable = false;

    // Eventos para UI/FX/SFX
    public event Action<int, int> OnHealthChanged; // (current, max)
    public event Action OnDied;
    public UnityEvent OnTakeDamage; // alternativa visual no inspector

    protected virtual void Awake()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;
    public bool IsDead => currentHealth <= 0;
    public bool IsInvulnerable => isInvulnerable;

    /// <summary>
    /// Aplica cura (pode passar valor negativo para dano, mas prefira TakeDamage).
    /// </summary>
    public virtual void Heal(int amount)
    {
        if (amount <= 0) return;

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    /// <summary>
    /// Restaura vida ao máximo.
    /// </summary>
    public virtual void RestoreFull()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    /// <summary>
    /// Método público para aplicar dano.
    /// </summary>
    public virtual void TakeDamage(int damage, Vector2 hitDirection, float knockbackForce = 0f)
    {
        if (IsDead || isInvulnerable || damage <= 0) return;

        currentHealth -= damage;
        OnTakeDamage?.Invoke();
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (knockbackForce > 0f)
        {
            TryApplyKnockback(hitDirection.normalized, knockbackForce);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            // ativa invencibilidade temporária
            if (iFrameDuration > 0f)
                StartCoroutine(InvulnerabilityCoroutine(iFrameDuration));
        }
    }

    protected virtual void Die()
    {
        OnDied?.Invoke();
    }

    protected virtual void TryApplyKnockback(Vector2 direction, float force)
    {
        // Implementação padrão: se tiver Rigidbody2D, aplica impulso.
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // zerar velocidade antes do impulso
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

    protected IEnumerator InvulnerabilityCoroutine(float duration)
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(duration);
        isInvulnerable = false;
    }
}
