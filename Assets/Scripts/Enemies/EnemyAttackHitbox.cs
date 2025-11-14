using UnityEngine;

namespace EclipseGenesis.Enemies
{
    public class EnemyAttackHitbox : MonoBehaviour
    {
        [Header("Damage Settings")]
        public int damageAmount = 10;

        [Header("Optional Knockback")]
        public bool applyKnockback = false;
        public float knockbackForce = 5f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Só atinge o jogador
            if (collision.CompareTag("Player"))
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(damageAmount);

                    if (applyKnockback)
                    {
                        ApplyKnockback(collision.transform);
                    }
                }
            }
        }

        private void ApplyKnockback(Transform player)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb == null) return;

            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        }

        // Chamado via evento de animação (Animation Event)
        public void ActivateHitbox()
        {
            GetComponent<Collider2D>().enabled = true;
        }

        // Chamado via evento de animação
        public void DeactivateHitbox()
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
