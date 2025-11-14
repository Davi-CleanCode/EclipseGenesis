using UnityEngine;

public class HattoriRen : BaseCharacter
{
    [Header("Habilidades Hattori")]
    public float dashForce = 18f;
    public float dashTime = 0.15f;
    private bool isDashing;

    protected override void Update()
    {
        if (!isDashing)
            base.Update();

        if (Input.GetKeyDown(KeyCode.Z))
            UsarHabilidadePrimaria();

        if (Input.GetKeyDown(KeyCode.X))
            UsarHabilidadeSecundaria();
    }

    public override void UsarHabilidadePrimaria()
    {
        GetComponent<CharacterAnimator>().PlayAttack();
        // Corte básico
        Debug.Log("Hattori: Corte de plasma!");
    }

    public override void UsarHabilidadeSecundaria()
    {
        GetComponent<CharacterAnimator>().PlayDash();
        // Dash de plasma
        if (!isDashing)
            StartCoroutine(Dash());
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;

        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0);

        yield return new WaitForSeconds(dashTime);

        rb.gravityScale = originalGravity;
        isDashing = false;
    }
}
