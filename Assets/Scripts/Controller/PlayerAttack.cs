using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Common;
using UnityEngine.InputSystem;

namespace Footkin.Controller
{
    public class PlayerAttack : Attack, IInputHandler
    {
        PlayerInput playerInput;
        InputAction meleeACtion;
        InputAction rangedAction;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            meleeACtion = playerInput.actions.FindAction("MeleeAttack");
            rangedAction = playerInput.actions.FindAction("RangedAttack");
        }


        public void BindInput()
        {
            meleeACtion.performed += OnMeleeAttack;
            rangedAction.performed += OnRangedAttack;
        }

        public void UnBindInput()
        {
            meleeACtion.performed -= OnMeleeAttack;
            rangedAction.performed -= OnRangedAttack;
        }
    } 
}
