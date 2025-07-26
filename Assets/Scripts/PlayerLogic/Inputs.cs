using UnityEngine;

[RequireComponent(typeof(Player))]

public class Inputs : MonoBehaviour
{
    private Player movement;
    private Attack attack;
    
    private void Awake()
    {
        movement = GetComponent<Player>();
        attack = GetComponent<Attack>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalParams.HORIZONTAL_AXIS);
        bool isJumpPressed = Input.GetButtonDown(GlobalParams.JUMP);
            
        movement.Move(horizontalDirection, isJumpPressed);
            
        if(Input.GetButtonDown(GlobalParams.FIRE)) 
            attack.Hit();
    }
}