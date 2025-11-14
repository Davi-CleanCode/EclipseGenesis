using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimentação")]
    public float moveSpeed = 7f;
    public float jumpForce = 12f;

    [Header("Checagem de chão")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    [Header("Status")]
    public int maxHealth = 100;
    public int currentHealth;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Movimento();
        Pulo();
        ChecarQueda();
    }

    void Movimento()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Flip visual do personagem
        if (move != 0)
            transform.localScale = new Vector3(move, 1, 1);
    }

    void Pulo()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void ChecarQueda()
    {
        if (transform.position.y < -12f)
        {
            GameManager.Instance.RestartLevel();
        }
    }

    public void TomarDano(int dano)
    {
        currentHealth -= dano;

        UIManager.Instance.AtualizarVida(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
