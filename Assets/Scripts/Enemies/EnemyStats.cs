using UnityEngine;
using UnityEngine.Events;

namespace EclipseGenesis.Enemies
{
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

            OnEnemyDied?.Invoke();

            ScoreManager.Instance?.AddScore(scoreOnDeath);

            Destroy(gameObject); // trocar por animação de morte se quiser
        }

        public override void TakeDamage(int damage, Vector2 hitDirection, float knockbackForce = 0f)
        {
            if (IsDead || IsInvulnerable) return;

            base.TakeDamage(damage, hitDirection, knockbackForce);

            EnemyAI ai = GetComponent<EnemyAI>();
            if (ai != null)
                ai.Stun(stunDuration);
        }
    }
}

namespace EclipseGenesis.Enemies
{
    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Return
    }
}




