using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
                rangedWeapon.AttackEnemy();
            }
        }

        public void OnMeleeAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                rangedWeapon.AttackEnemy();
            }
        }
    } 
}
