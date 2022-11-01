using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Footkin.Common;

namespace Footkin.Controller
{
    public class Attack : MonoBehaviour
    {
        public Weapon rangedWeapon;
        public Weapon meleeWeapon;

        public void OnRangedAttack(InputAction.CallbackContext context)
        {
            
            if (context.performed)
            {
                Debug.Log("Performing ranged attack");
            }
        }

        public void OnMeleeAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Debug.Log("Performing melee attack");
            }
        }
    } 
}
