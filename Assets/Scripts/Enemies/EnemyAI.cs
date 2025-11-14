using UnityEngine;

namespace EclipseGenesis.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [Header("References")]
        public Transform leftLimit;
        public Transform rightLimit;
        private Transform player;
        private Animator animator;

        [Header("Movement Settings")]
        public float moveSpeed = 2f;
        public float chaseSpeed = 3f;
        public float stopDistance = 1.3f;
        public float detectionRange = 6f;
        public float returnSpeed = 2f;

        private Vector3 initialPosition;
        private Vector3 patrolTarget;
        private EnemyState currentState = EnemyState.Patrol;

        public bool canMove = true;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            animator = GetComponent<Animator>();

            initialPosition = transform.position;
            patrolTarget = leftLimit.position;
        }

        private void Update()
        {
            if (!canMove) return;
            if (player == null) return;

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            switch (currentState)
            {
                case EnemyState.Patrol:
                    Patrol();
                    if (distanceToPlayer <= detectionRange)
                        SwitchState(EnemyState.Chase);
                    break;

                case EnemyState.Chase:
                    ChasePlayer();
                    if (distanceToPlayer <= stopDistance)
                        SwitchState(EnemyState.Attack);
                    if (distanceToPlayer > detectionRange * 1.5f)
                        SwitchState(EnemyState.Return);
                    break;

                case EnemyState.Attack:
                    // Movimento é bloqueado no AttackController
                    if (distanceToPlayer > stopDistance)
                        SwitchState(EnemyState.Chase);
                    break;

                case EnemyState.Return:
                    ReturnToOrigin();
                    if (Vector2.Distance(transform.position, initialPosition) < 0.2f)
                        SwitchState(EnemyState.Patrol);
                    break;
            }
        }

        private void Patrol()
        {
            MoveTowards(patrolTarget, moveSpeed);

            // Troca direção ao chegar no limite
            if (Vector2.Distance(transform.position, patrolTarget) < 0.2f)
            {
                patrolTarget = patrolTarget == leftLimit.position ?
                               rightLimit.position : leftLimit.position;
            }
        }

        private void ChasePlayer()
        {
            MoveTowards(player.position, chaseSpeed);
        }

        private void ReturnToOrigin()
        {
            MoveTowards(initialPosition, returnSpeed);
        }

        private void MoveTowards(Vector3 target, float speed)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // vira o inimigo
            if (direction.x != 0)
                transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);

            animator.SetFloat("Speed", Mathf.Abs(direction.x));
        }

        public void StopMovement()
        {
            animator.SetFloat("Speed", 0);
            canMove = false;
        }

        public void ResumeMovement()
        {
            canMove = true;
        }

        private void SwitchState(EnemyState newState)
        {
            currentState = newState;
        }
    }
}
