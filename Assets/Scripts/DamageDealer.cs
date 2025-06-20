using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damageable"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
