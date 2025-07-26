using System.Collections;
using UnityEngine;

    public enum UnitType
    {
        Player,
        Enemy,
        Npc
    }
public class Unit : MonoBehaviour
{
    [SerializeField] private bool isCanMove;
    public UnitType unitType;
    private bool isFlip;
    private bool isAlive = true;
    private bool isMove;
    private Rigidbody2D rigidbody;
    protected Animator animator;

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
    public virtual  void Die() {}
    public bool IsFlip
    {
        get => isFlip;
    }
    public bool IsAlive
    {
        get => isAlive;
        set => isAlive = value;
    }
    public bool IsCanMove
    {
        get => isCanMove;
        set => isCanMove = value;
    }
    public bool IsMove
    {
        get => isMove;
        set => isMove = value;
    }
    public void DoStunn()
    {
        StartCoroutine(Stunn());
    }

    private IEnumerator Stunn()
    {
        isCanMove = false;
        yield return new WaitForSeconds(0.5f);
        isCanMove = true;
        yield return null;
    }
}
