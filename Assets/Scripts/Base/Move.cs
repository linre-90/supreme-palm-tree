using UnityEngine;
using UnityEngine.InputSystem;

namespace Footkin.Base
{   
    public class Move : MonoBehaviour
    {
        public CharacterData characterData;
        Vector3 direction;
        CharacterController characterController;
        bool grounded;
        bool isJumping;

        private void Awake()
        {
            direction = Vector3.zero;
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Perform movement before gravity calculations
            characterController.Move(direction * Time.deltaTime * characterData.Speed);
            if (isJumping)
            {
                direction.y += 1f * characterData.jumpForce;
            }
            

            // Gravity + ground ray
            if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 1.1f, ~6))
            {
                if (!isJumping)
                {
                    direction.y = 0f;
                    grounded = true;
                }
            }
            else
            {
                // Apply gravity
                grounded = false;
                direction.y += Physics.gravity.y * Time.deltaTime * characterData.GravityMultiplayer;
            }

            // After jump boost set jumping false
            isJumping = false;
        }

        public void OnMoveRight(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                direction.x = 1;
                return;
            }

            if(direction.x == 1)
            {
                direction.x -= 1;
            }
        }

        public void OnMoveLeft(InputAction.CallbackContext context)
        {
            
            if (context.performed)
            {
                direction.x = -1;
                return;
            }

            if (direction.x == -1)
            {
                direction.x += 1;
            }
        }

        public void OnMoveJump(InputAction.CallbackContext context)
        {
            if (context.performed && grounded)
            {
                grounded = false;
                isJumping = true;
                return;
            }
        }
    } 
}
