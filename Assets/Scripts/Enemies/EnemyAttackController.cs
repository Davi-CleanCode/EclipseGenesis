using UnityEngine;

namespace EclipseGenesis.Enemies
{
    public class EnemyAttackController : MonoBehaviour
    {
        [Header("Attack Settings")]
        public float attackRange = 1.2f;
        public float attackCooldown = 1.5f;

        private float nextAttackTime;
        private Transform player;
        private Animator animator;
        private EnemyAI enemyAI;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            animator = GetComponent<Animator>();
            enemyAI = GetComponent<EnemyAI>();
        }

        private void Update()
        {
            if (player == null) return;

            float distance = Vector2.Distance(transform.position, player.position);

            // Player está na distância de ataque?
            if (distance <= attackRange)
            {
                enemyAI.StopMovement(); // congela o inimigo
                TryAttack();
            }
            else
            {
                enemyAI.ResumeMovement(); // deixa ele andar normalmente
            }
        }

        private void TryAttack()
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
