using UnityEngine;

public class KaelDrayen : BaseCharacter
{
    [Header("Habilidades Kael")]
    public Transform firePoint;
    public GameObject laserProjectile;
    public float laserSpeed = 20f;

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
        GetComponent<CharacterAnimator>().PlayMorph();
        // Golpe com braço-espada
        Debug.Log("Kael: Golpe de espada-morph!");
    }

    public override void UsarHabilidadeSecundaria()
    {
        GetComponent<CharacterAnimator>().PlaySkill();
        // Disparo de laser-morph
        GameObject laser = Instantiate(laserProjectile, firePoint.position, firePoint.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = transform.right * laserSpeed;

        Debug.Log("Kael: Laser morph disparado!");
    }
}
