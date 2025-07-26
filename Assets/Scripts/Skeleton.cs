using System.Collections;
using UnityEngine;
public class Skeleton : Unit
{
    enum State
    {
        Idle,
        Move,
        Attack,
        Dead
    }
    [SerializeField] private float moveSpeed;
    [SerializeField] private State state;
    [SerializeField] private Collider2D hitCollider;
    private Rigidbody2D rigidBody;

    private void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start ()
    {
        IsCanMove = true;
        Flip();
        StartCoroutine(Patrol());
    }
    private void Move ()
    {
        if (IsAlive)
        {
            if (IsCanMove)
                rigidBody.velocity = new Vector2(moveSpeed * (IsFlip ? -1 : 1) , rigidBody.velocity.y);
        }
        else
        {
            state = State.Idle;
        }
        
        animator.SetFloat("isSpeed", Mathf.Abs(rigidBody.velocity.x));
    }
    private void Update ()
    {
        animator.SetFloat("isSpeed", 0);
        
        if(state == State.Move)
            Move();
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Limiter"))
        {
            Flip();
        }
    }
    public void DoAttack ()
    {
        state = State.Attack;
        animator.SetBool("isAttack", true);
        float px = Player.ST.transform.position.x;
        float x = transform.position.x;
        if(px < x &&  !IsFlip  || px > x && IsFlip)
            Flip();
            
        StartCoroutine(CollDownAttack());
    }
    
    private IEnumerator CollDownAttack ()
    {
        yield return new WaitForSeconds(0.4f);
        hitCollider.enabled = true;
        yield return new WaitForSeconds(0.6f);
        state = State.Move;
        hitCollider.enabled = false;
        animator.SetBool("isAttack", false);
        yield return null;
    }
    
    private IEnumerator Patrol ()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            if (state != State.Attack)
            {
                if (Random.Range(0, 10) < 8)
                    state = State.Move;
                else
                    state = State.Idle;
                
            }
        }
        yield return null;
    }

    public override void Die()
    {
        IsAlive = false;
        animator.SetTrigger("trDeath");
        state = State.Dead;
    }
}
