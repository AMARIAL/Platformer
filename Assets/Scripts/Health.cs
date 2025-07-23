using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private Unit unit;
    private Animator animator;
    private void Awake()
    {
        unit = GetComponent<Unit>();
        animator = GetComponent<Animator>();
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
        animator.Play("Hit");
        CheckIsAlive();
    }
    public void DoHeal(int hp)
    {
        currentHealth += hp;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
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
