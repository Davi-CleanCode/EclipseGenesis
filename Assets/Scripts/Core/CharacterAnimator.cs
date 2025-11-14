using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private BaseCharacter character;

    // Parâmetros comuns
    private readonly int SpeedHash = Animator.StringToHash("speed");
    private readonly int GroundedHash = Animator.StringToHash("grounded");
    private readonly int JumpHash = Animator.StringToHash("jump");
    private readonly int FallHash = Animator.StringToHash("fall");

    // Parâmetros de ataque e habilidades
    private readonly int AttackHash = Animator.StringToHash("attack");
    private readonly int SkillHash = Animator.StringToHash("skill");
    private readonly int DashHash = Animator.StringToHash("dash");
    private readonly int MorphHash = Animator.StringToHash("morph");

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<BaseCharacter>();
    }

    private void Update()
    {
        AtualizarMovimentoBase();
    }

    private void AtualizarMovimentoBase()
    {
        anim.SetFloat(SpeedHash, Mathf.Abs(rb.velocity.x));
        anim.SetBool(GroundedHash, character.IsGrounded);

        if (rb.velocity.y > 0.1f)
            anim.SetTrigger(JumpHash);

        if (rb.velocity.y < -1f)
            anim.SetTrigger(FallHash);
    }

    // ======== MÉTODOS PÚBLICOS PARA SEREM CHAMADOS PELOS PERSONAGENS ========

    public void PlayAttack()
    {
        anim.SetTrigger(AttackHash);
    }

    public void PlaySkill()
    {
        anim.SetTrigger(SkillHash);
    }

    public void PlayDash()
    {
        anim.SetTrigger(DashHash);
    }

    public void PlayMorph()
    {
        anim.SetTrigger(MorphHash);
    }
}
