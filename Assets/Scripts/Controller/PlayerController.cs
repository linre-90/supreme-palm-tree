using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;
using Footkin.Controller;

namespace Footkin.Controller
{
    public class PlayerController : Character
    {
        PlayerMove playerMove;
        PlayerAttack playerAttack;

        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.BindInput();
            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.BindInput();
        }

        private void OnDestroy()
        {
            playerMove.UnBindInput();
            playerAttack.UnBindInput();
        }


    }
}
