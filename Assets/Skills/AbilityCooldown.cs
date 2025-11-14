using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    public float cooldownTime = 1f;
    private float cooldown;

    public bool PodeUsar()
    {
        return Time.time > cooldown;
    }

    public void IniciarCooldown()
    {
        cooldown = Time.time + cooldownTime;
    }
}
