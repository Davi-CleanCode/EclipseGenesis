
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public int maxHealth = 100;

    int currentHealth;
    Rigidbody2D rb;
    Vector2 input;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal"); 
        if (Input.GetButtonDown("Jump")) TryJump();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);
        FlipSprite();
    }

    void FlipSprite()
    {
        if (input.x > 0 && !facingRight || input.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void TryJump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UIManager.Instance.UpdateHealth(currentHealth, maxHealth);
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("O herói cibernético caiu. A Terra permanece em risco.");
        GameManager.Instance.GameOver();
    }
}
