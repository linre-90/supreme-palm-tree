using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace Footkin.Controller
{
    public class PlayerController : Character
    {
        PlayerMove playerMove;
        PlayerAttack playerAttack;
        bool inputAlreadyUnbind = false;

        public override void ReceiveDamage(int damage)
        {
            characterData.Health -= damage;
            if(characterData.Health <= 0)
            {
                playerAttack.UnBindInput();
                playerMove.UnBindInput();
                Debug.Log("TODO: Show again quit button");
            }
        }

        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.BindInput();
            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.BindInput();
        }

        private void OnDestroy()
        {
            if (!inputAlreadyUnbind)
            {
                playerMove.UnBindInput();
                playerAttack.UnBindInput();
            }

            characterData.Health = 100;
        }

        public override bool ReceiveHealth(int amount)
        {
            if(characterData.Health + amount <= 100)
            {
                characterData.Health += amount;
                return true;
            }
            return false;
        }
    }
}
