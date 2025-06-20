using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Movement))]
    public class Inputs : MonoBehaviour
    {
        private Movement movement;
    
        private void Awake()
        {
            movement = GetComponent<Movement>();
        }
        
        private void Update()
        {
            float horizontalDirection = Input.GetAxis(GlobalParams.HORIZONTAL_AXIS);
            bool isJumpPressed = Input.GetButtonDown(GlobalParams.JUMP);
            movement.Move(horizontalDirection, isJumpPressed);
        }
    }  
}

