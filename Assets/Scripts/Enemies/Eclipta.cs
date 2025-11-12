
using UnityEngine;

public class Eclipta : MonoBehaviour
{
    public string ecliptaName = "Eclipta";
    public int maxHealth = 150;
    public int meleeDamage = 20;
    public float attackRange = 1.5f;
    public bool isCorrupted = false;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log(ecliptaName + " caiu. O conflito interno dos híbridos continua.");
        Destroy(gameObject);
    }

    public void Attack(GameObject target)
    {
        var player = target.GetComponent<PlayerController>();
        if (player != null) player.TakeDamage(meleeDamage);
    }
}
