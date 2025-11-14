using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour

{
    public bool IsGrounded => isGrounded;

    [Header("Movimentação Base")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    [Header("Status")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Checagem de chão")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.15f;

    protected Rigidbody2D rb;
    protected bool isGrounded;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        MovimentoBase();
        ChecarChao();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Pular();
    }

    protected void MovimentoBase()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move != 0)
            transform.localScale = new Vector3(move, 1, 1);
    }

    protected void Pular()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    protected void ChecarChao()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    public virtual void TomarDano(int dano)
    {
        currentHealth -= dano;
        UIManager.Instance.AtualizarVida(currentHealth, maxHealth);

        if (currentHealth <= 0)
            GameManager.Instance.RestartLevel();
    }

    // Método obrigatório para cada personagem implementar
    public abstract void UsarHabilidadePrimaria();
    public abstract void UsarHabilidadeSecundaria();
}
