using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyStats))]
public class EnemyAI : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Stunned
    }

    [Header("Movement")]
    public float moveSpeed = 2f;
    public float chaseSpeed = 3f;
    public float patrolRange = 3f;
    public float groundCheckDistance = 1f;

    [Header("Combat")]
    public float attackRange = 1.2f;
    public int damage = 15;
    public float attackCooldown = 1f;

    [Header("Detection")]
    public float detectionRange = 5f;
    public LayerMask playerLayer;

    private EnemyState currentState;
    private Rigidbody2D rb;
    private EnemyStats stats;
    private Transform player;
    private Vector2 startPosition;
    private float patrolDirection = 1;
    private bool canAttack = true;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<EnemyStats>();
    }

    private void Start()
    {
        currentState = EnemyState.Patrol;
        startPosition = transform.position;

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    private void Update()
    {
        if (stats.IsDead) return;

        switch (currentState)
        {
            case EnemyState.Idle: HandleIdle(); break;
            case EnemyState.Patrol: HandlePatrol(); break;
            case EnemyState.Chase: HandleChase(); break;
            case EnemyState.Attack: HandleAttack(); break;
            case EnemyState.Stunned:
                // nada aqui — stun é controlado pela coroutine
                break;
        }

        DetectPlayer();
    }

    // ---------------------------------------------------------------------- //
    //  ESTADOS
    // ---------------------------------------------------------------------- //

    private void HandleIdle()
    {
        rb.velocity = Vector2.zero;
    }

    private void HandlePatrol()
    {
        rb.velocity = new Vector2(moveSpeed * patrolDirection, rb.velocity.y);

        // Inverte caso chegue no limite da patrulha
        if (Vector2.Distance(transform.position, startPosition) >= patrolRange)
        {
            Flip();
            patrolDirection *= -1;
        }
    }

    private void HandleChase()
    {
        if (player == null) return;

        float direction = Mathf.Sign(player.position.x - transform.position.x);
        rb.velocity = new Vector2(direction * chaseSpeed, rb.velocity.y);

        // vira pro player
        if ((direction > 0 && !isFacingRight) || (direction < 0 && isFacingRight))
            Flip();

        // Se estiver perto o suficiente -> atacar
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            ChangeState(EnemyState.Attack);
        }
    }

    private void HandleAttack()
    {
        rb.velocity = Vector2.zero;

        if (player == null) return;
        if (!canAttack) return;

        StartCoroutine(AttackCoroutine());
    }

    // ---------------------------------------------------------------------- //
    //  DETECÇÃO
    // ---------------------------------------------------------------------- //

    private void DetectPlayer()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (currentState != EnemyState.Stunned)
        {
            if (distance <= attackRange)
                ChangeState(EnemyState.Attack);

            else if (distance <= detectionRange)
                ChangeState(EnemyState.Chase);

            else
                ChangeState(EnemyState.Patrol);
        }
    }

    // ---------------------------------------------------------------------- //
    //  ATAQUE
    // ---------------------------------------------------------------------- //

    private IEnumerator AttackCoroutine()
    {
        canAttack = false;

        // *** Aqui você pode chamar animação ***
        // animação de ataque → evento chama DealDamage()

        yield return new WaitForSeconds(0.1f);

        DealDamage();

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;

        ChangeState(EnemyState.Chase);
    }

    private void DealDamage()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange)
        {
            PlayerStats pStats = player.GetComponent<PlayerStats>();
            if (pStats != null)
            {
                Vector2 hitDir = (player.position - transform.position).normalized;
                pStats.TakeDamage(damage, hitDir, 6f);
            }
        }
    }

    // ---------------------------------------------------------------------- //
    //  FLIP (virar sprite)
    // ---------------------------------------------------------------------- //

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ---------------------------------------------------------------------- //
    //  TRANSIÇÃO DE ESTADOS
    // ---------------------------------------------------------------------- //

    private void ChangeState(EnemyState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
    }

    // ---------------------------------------------------------------------- //
    //  STUN (usado pelo EnemyStats)
    // ---------------------------------------------------------------------- //

    public void Stun(float duration)
    {
        StopAllCoroutines();
        StartCoroutine(StunCoroutine(duration));
    }

    private IEnumerator StunCoroutine(float duration)
    {
        ChangeState(EnemyState.Stunned);
        rb.velocity = Vector2.zero;

        // Aqui pode tocar uma animação de hit / flash vermelho

        yield return new WaitForSeconds(duration);

        ChangeState(EnemyState.Patrol);
    }
}
