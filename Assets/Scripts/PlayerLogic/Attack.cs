using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Collider2D hitCollider;
    private bool isAttack;
        
    private Animator animator;
    
    private byte attackNum = 1;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        hitCollider.enabled = false;
    }
    
    public void Hit()
    {
        if(Player.ST.state == Player.State.Dead || isAttack) return;
        
        animator.Play("Knight-Attack " + attackNum);
        
        attackNum++;
        if (attackNum > 3)
            attackNum = 1;
        
        StartCoroutine(CollDownAttack());
    }
    
    public void StopAttack ()
    {
        isAttack = false;
        hitCollider.enabled = false;
    }
    
    private IEnumerator CollDownAttack ()
    {
        isAttack = true;
        hitCollider.enabled = true;
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        hitCollider.enabled = false;
        yield return null;
    }
    
}
