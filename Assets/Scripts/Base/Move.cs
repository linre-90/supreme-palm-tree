using UnityEngine;
using UnityEngine.InputSystem;
using Footkin.Controller;

namespace Footkin.Base
{   
    public class Move : MonoBehaviour
    {
        [SerializeField]
        GameObject meshObject;

        public CharacterData characterData;
        Vector3 direction;
        CharacterController characterController;
        bool grounded;

        [SerializeField]
        AnimationController animationController;

        [SerializeField] CharacterAudio characterAudio;
        

        /// <summary>
        /// 0:Left, 1:right, 2:jump
        /// </summary>
        bool[] movementDirection = new bool[] { false, false, false };

        private void Awake()
        {
            direction = Vector3.zero;
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Gravity + ground ray
            if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 1.1f, 1 << 7))
            {
                if (!movementDirection[2])
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

            // reached jump top height point
            if (movementDirection[2] && direction.y > .95f)
            {
                movementDirection[2] = false;
            }
            else if (movementDirection[2])
            {
                direction.y = Mathf.Lerp(direction.y, 1f, characterData.jumpForce);
            }

            // Movement left right and reset
            if (movementDirection[0])
            {
                if (grounded)
                {
                    animationController.SetBoolean(animationController.animationData.walk, true);
                    characterAudio.ModifySound(CharacterAudio.Sounds.walk, CharacterAudio.SoundModifier.play, false);
                }
                direction.x = Mathf.Lerp(direction.x, -1f, characterData.Speed * Time.deltaTime);
                meshObject.transform.eulerAngles = new Vector3(0f, 0f ,0f);
            }
            else if (movementDirection[1])
            {
                if (grounded)
                {
                    animationController.SetBoolean(animationController.animationData.walk, true);
                    characterAudio.ModifySound(CharacterAudio.Sounds.walk, CharacterAudio.SoundModifier.play, false);
                }
                direction.x = Mathf.Lerp(direction.x, 1f, characterData.Speed * Time.deltaTime);
                meshObject.transform.eulerAngles = new Vector3(0f, -180f, 0f);
            }
            else
            {
                characterAudio.ModifySound(CharacterAudio.Sounds.walk, CharacterAudio.SoundModifier.stop, false);
                animationController.SetBoolean(animationController.animationData.walk, false);
                direction.x = Mathf.Lerp(direction.x, 0f, characterData.Speed * Time.deltaTime);
            }

            if (!grounded)
            {
                characterAudio.ModifySound(CharacterAudio.Sounds.walk, CharacterAudio.SoundModifier.stop, false);
            }
            
            // Perform movement to direction
            characterController.Move(direction * Time.deltaTime * characterData.Speed);
        }

        public void OnMoveRight(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                movementDirection[1] = true;
                return;
            }
            movementDirection[1] = false;
        }

        public void OnMoveRight(bool performed)
        {
            if (performed)
            {
                movementDirection[1] = true;
                return;
            }
            movementDirection[1] = false;
        }

        public void OnMoveLeft(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                movementDirection[0] = true;
                return;
            }
            movementDirection[0] = false;
        }

        public void OnMoveLeft(bool performed)
        {
            if (performed)
            {
                movementDirection[0] = true;
                return;
            }
            movementDirection[0] = false;
        }

        public void OnMoveJump(InputAction.CallbackContext context)
        {
            if (context.performed && grounded)
            {
                animationController.SetBoolean(animationController.animationData.jump, true);
                grounded = false;
                movementDirection[2] = true;
                return;
            }
        }

        public void OnAttackPressed(InputAction.CallbackContext context)
        {
            movementDirection[0] = false;
            movementDirection[1] = false;
        }
    } 
}
