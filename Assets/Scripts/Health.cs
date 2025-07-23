using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private Unit unit;

    private void Awake()
    {
        unit = GetComponent<Unit>();
    }

    private void Start()
    {
        Containers.ST.healthContainer.Add(gameObject,this);
        Resurrection();
    }
    
    public void TakeDamage(int dmg)
    {
        if(!unit.IsAlive)
            return;
        currentHealth -= dmg;
        CheckIsAlive();
    }

    public void Resurrection()
    {
        currentHealth = maxHealth;
        unit.IsAlive = true;
    }
    
    private void CheckIsAlive ()
    {
        if (currentHealth > 0) 
            return;
        currentHealth = 0;
        unit.Die();
    }
}
