using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;
using UnityEngine.InputSystem;

namespace Footkin.Controller
{
    public class PlayerMove : Move
    {
        PlayerInput playerInput;
        InputAction moveLeft;
        InputAction moveRight;
        InputAction jump;

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
        }

        public void UnBindInput()
        {
            moveLeft.performed -= OnMoveLeft;
            moveRight.performed -= OnMoveRight;
            jump.performed -= OnMoveJump;

            moveLeft.canceled -= OnMoveLeft;
            moveRight.canceled -= OnMoveRight;
            jump.canceled -= OnMoveJump;
        }
    } 
}
