using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;
using Footkin.Controller;
using UnityEngine.InputSystem;

namespace Footkin.Controller
{
    public class PlayerController : Character
    {
        PlayerMove playerMove;

        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.BindInput();
        }

        private void OnDestroy()
        {
            playerMove.UnBindInput();
        }


    }
}
