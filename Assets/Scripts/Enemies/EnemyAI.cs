
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float aggroRange = 6f;

    Transform player;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var p = GameObject.FindWithTag("Player");
        if (p) player = p.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist < aggroRange)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.velocity = dir * chaseSpeed;
        }
        else rb.velocity = new Vector2(Mathf.Sin(Time.time) * patrolSpeed, rb.velocity.y);
    }
}
