using UnityEngine;

public enum OtherHealthOwner: byte
{
    Enemy,
    Player
}

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private OtherHealthOwner otherHealthOwner;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag(otherHealthOwner.ToString()) && Containers.ST.healthContainer.ContainsKey(other.gameObject))
        {
            Containers.ST.healthContainer[other.gameObject].TakeDamage(damage);
        }
    }
}
