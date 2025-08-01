using UnityEngine;

public class PlayerVars
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private GroundDetection _groundDetection;
    private Inputs _inputs;
    private Health _health;
    private AnimationCurve _speedCurve;
    public PlayerVars(Rigidbody2D rigidbody2D, Animator animator, GroundDetection groundDetection, Inputs inputs, Health health, AnimationCurve speedCurve)
    {
        _rigidbody2D = rigidbody2D;
        _animator = animator;
        _groundDetection = groundDetection;
        _inputs = inputs;
        _health = health;
        _speedCurve = speedCurve;
    }

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Animator Animator => _animator;
    public GroundDetection GroundDetection => _groundDetection;
    public Inputs Inputs => _inputs;
    public Health Health => _health;
    public AnimationCurve AnimationCurve => _speedCurve;
}
