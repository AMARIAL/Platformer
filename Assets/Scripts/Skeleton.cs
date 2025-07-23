using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isMove;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Unit unit;
    
    private void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        unit = GetComponent<Unit>();
    }
    private void Start ()
    {
        unit.Flip();
        if (unit.IsAlive) isMove = true;
    }
    private void Move ()
    {
        if (unit.IsAlive)
        {
            if(unit.IsCanMove)
                rigidBody.velocity = new Vector2(moveSpeed * (unit.IsFlip ? -1 : 1) , rigidBody.velocity.y);
        }
        else
        {
            isMove = false;
        }
        
        animator.SetFloat("isMoving", Mathf.Abs(rigidBody.velocity.x));

    }
    private void Update ()
    {
        if(isMove)
            Move();
    }
    
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Limiter"))
        {
            unit.Flip();
        }
    }
}
