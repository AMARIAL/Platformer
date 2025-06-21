using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool isAlive = true;

    private void Start()
    {
        Containers.ST.healthContainer.Add(gameObject,this);
        Resurrection();
    }
    
    public void TakeDamage(int dmg)
    {
        if(!isAlive)
            return;
        currentHealth -= dmg;
        CheckIsAlive();
    }

    public void Resurrection()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }
    
    private void CheckIsAlive ()
    {
        if (currentHealth > 0) 
            return;
        currentHealth = 0;
        isAlive = false;
    }
}
