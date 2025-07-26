using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
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
        
        if (unit.unitType == UnitType.Player)
            HpIndicator = GameObject.Find("HрIndiсator").GetComponent<Image>();

        Resurrection();
    }
    public void TakeDamage(int dmg)
    {
        if(!unit.IsAlive)
            return;
        
        currentHealth -= dmg;
        animator.Play("Hit");
        
        if (unit.unitType == UnitType.Player && !isScoreAnim)
            StartCoroutine(HpAnim());
        else
            unit.DoStunn();

        CheckIsAlive();
    }
    public void DoHeal(int hp)
    {
        currentHealth += hp;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        
        if (unit.unitType == UnitType.Player && !isScoreAnim)
            StartCoroutine(HpAnim());
    }
    public void Resurrection()
    {
        currentHealth = maxHealth;
        if (unit.unitType == UnitType.Player && !isScoreAnim)
            StartCoroutine(HpAnim());
        unit.IsAlive = true;
    }
    private void CheckIsAlive ()
    {
        if (currentHealth > 0) 
            return;
        currentHealth = 0;
        unit.Die();
    }
    private IEnumerator  HpAnim()
    {
        isScoreAnim = true;
        int i = currentHealth > Mathf.RoundToInt(HpIndicator.fillAmount * 100) ? 1 : -1;
        
        while (currentHealth != Mathf.RoundToInt(HpIndicator.fillAmount*100))
        { 
            yield return new WaitForSeconds(0.1f);
            HpIndicator.fillAmount += 0.1f * i;
        }
        HpIndicator.fillAmount = (float)currentHealth / 100;
        isScoreAnim = false;
        yield return null;
    }
}