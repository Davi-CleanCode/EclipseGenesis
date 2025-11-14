using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttackHitbox : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damage = 15;
    public float knockbackForce = 8f;

    [Header("Hitbox Options")]
    public bool destroyAfterHit = false;
    public bool oneHitPerAttack = true;

    private HashSet<GameObject> objectsHit = new HashSet<GameObject>();

    private void Awake()
    {
        // Garante que o collider seja usado como trigger
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnEnable()
    {
        // Sempre limpa ao reativar
        objectsHit.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        GameObject obj = other.gameObject;

        // Se hit único por ataque estiver ativado
        if (oneHitPerAttack && objectsHit.Contains(obj))
            return;

        objectsHit.Add(obj);

        // Aplica dano
        PlayerStats player = obj.GetComponent<PlayerStats>();
        if (player != null)
        {
            Vector2 direction = (obj.transform.position - transform.position).normalized;
            player.TakeDamage(damage, direction, knockbackForce);
        }

        // Destruir hitbox depois do hit (útil para ataques rápidos)
        if (destroyAfterHit)
            gameObject.SetActive(false);
    }
}
