using UnityEngine;

public class DrVolkan : BaseCharacter
{
    [Header("Habilidades Volkan")]
    public float teleportDistance = 4f;
    public GameObject energyFieldPrefab;
    public float fieldDuration = 2f;

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Z))
            UsarHabilidadePrimaria();

        if (Input.GetKeyDown(KeyCode.X))
            UsarHabilidadeSecundaria();
    }

    public override void UsarHabilidadePrimaria()
    {
        GetComponent<CharacterAnimator>().PlaySkill();
        Vector3 targetPos = transform.position + (transform.right * teleportDistance * transform.localScale.x);
        transform.position = targetPos;

        Debug.Log("Volkan: Teleporte quântico!");
        GetComponent<CharacterAnimator>().PlayAttack();
    }

    public override void UsarHabilidadeSecundaria()
    {
        StartCoroutine(CriarCampo());
    }

    private System.Collections.IEnumerator CriarCampo()
    {
        GameObject campo = Instantiate(energyFieldPrefab, transform.position, Quaternion.identity);
        Debug.Log("Volkan: Campo de energia ativado!");

        yield return new WaitForSeconds(fieldDuration);

        Destroy(campo);
    }
}
