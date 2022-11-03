using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;
using UnityEngine.InputSystem;
using Footkin.Common;

namespace Footkin.Controller
{
    public class PlayerMove : Move, IInputHandler
    {
        PlayerInput playerInput;
        InputAction moveLeft;
        InputAction moveRight;
        InputAction jump;

        InputAction melee;
        InputAction range;



        public void BindInput()
        {
            this.playerInput = GetComponent<PlayerInput>();
            moveLeft = playerInput.actions.FindAction("MoveLeft");
            moveRight = playerInput.actions.FindAction("MoveRight");
            jump = playerInput.actions.FindAction("Jump");

            moveLeft.performed += OnMoveLeft;
            moveRight.performed += OnMoveRight;
            jump.performed += OnMoveJump;

            moveLeft.canceled += OnMoveLeft;
            moveRight.canceled += OnMoveRight;
            jump.canceled += OnMoveJump;

            // Bind input to release movement
            melee = playerInput.actions.FindAction("MeleeAttack");
            range = playerInput.actions.FindAction("RangedAttack");
            melee.performed += OnAttackPressed;
            range.performed += OnAttackPressed;
        }

        public void UnBindInput()
        {
            moveLeft.performed -= OnMoveLeft;
            moveRight.performed -= OnMoveRight;
            jump.performed -= OnMoveJump;

            moveLeft.canceled -= OnMoveLeft;
            moveRight.canceled -= OnMoveRight;
            jump.canceled -= OnMoveJump;

            melee.performed -= OnAttackPressed;
            range.performed -= OnAttackPressed;
        }
    } 
}
