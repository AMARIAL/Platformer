using UnityEngine;

public class Unit : MonoBehaviour
{
    private bool isFlip;
    private bool isAlive = true;
    private Rigidbody2D rigidbody;
    private Animator animator;
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Flip()
    {
        isFlip = !isFlip;
        transform.localScale = new Vector3(isFlip ? -1 : 1, 1, 1);
    }

    public void Die()
    {
        isAlive = false;
        rigidbody.simulated = false;
        animator.SetTrigger("trDeath");
    }

    public bool IsFlip
    {
        get => isFlip;
    }

    public bool IsAlive
    {
        get => isAlive;
        set => isAlive = value;
    }
}
