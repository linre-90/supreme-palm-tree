using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Footkin.Base
{   
    public class Move : MonoBehaviour
    {
        public CharacterData characterData;

        public void OnMoveRight(InputAction.CallbackContext context, float speed)
        {
            Debug.Log("Move right with " + speed.ToString());
        }
        public void OnMoveLeft(InputAction.CallbackContext context, float speed)
        {
            Debug.Log("Move left with " + speed.ToString());
        }
        public void OnMoveJump(InputAction.CallbackContext context, float speed)
        {
            Debug.Log("Jump with " + speed.ToString());
        }
    } 
}
