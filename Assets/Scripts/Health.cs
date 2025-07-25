using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private bool isPlayer;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private Unit unit;
    private Animator animator;
    private bool isScoreAnim;
    private Image HpIndicator;
    private void Awake()
    {
        unit = GetComponent<Unit>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Containers.ST.healthContainer.Add(gameObject,this);
        
        if (isPlayer)
            HpIndicator = GameObject.Find("HрIndiсator").GetComponent<Image>();
        
        Resurrection();
    }
    public void TakeDamage(int dmg)
    {
        if(!unit.IsAlive)
            return;
        
        currentHealth -= dmg;
        animator.Play("Hit");
        
        if (isPlayer && !isScoreAnim)
            StartCoroutine(HpAnim());
        
        CheckIsAlive();
    }
    public void DoHeal(int hp)
    {
        currentHealth += hp;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        if (isPlayer && !isScoreAnim)
            StartCoroutine(HpAnim());
    }
    public void Resurrection()
    {
        currentHealth = maxHealth;
        if (isPlayer && !isScoreAnim)
            StartCoroutine(HpAnim());
        unit.IsAlive = true;
    }
    private void CheckIsAlive ()
    {
        if (currentHealth > 0) 
            return;
        currentHealth = 0;
        unit.Die();
        
        if(isPlayer)
            GameManager.ST.ChangeLives();
    }
    private IEnumerator  HpAnim()
    {
        isScoreAnim = true;
        while (currentHealth != (int) (HpIndicator.fillAmount*100))
        { 
            yield return new WaitForSeconds(0.1f);
            
            if(currentHealth > (int) (HpIndicator.fillAmount*100))
                HpIndicator.fillAmount += 0.1f;
            else
                HpIndicator.fillAmount -= 0.1f;
            //Debug.Log(currentHealth + " - " + (int) (HpIndicator.fillAmount*100));
        }
        isScoreAnim = false;
        yield return null;
    }
}