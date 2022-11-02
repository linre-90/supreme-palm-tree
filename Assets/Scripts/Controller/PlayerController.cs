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
        

        int health;
        bool inputAlreadyUnbind = false;

        public override void ReceiveDamage(int damage)
        {
            health -= damage;
            if(health <= 0)
            {
                playerAttack.UnBindInput();
                playerMove.UnBindInput();
                Debug.Log("TODO: Show again quit button");
            }
            Debug.Log(health);
        }

        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.BindInput();
            playerAttack = GetComponent<PlayerAttack>();
            playerAttack.BindInput();
            health = characterData.Health;
        }

        private void OnDestroy()
        {
            if (!inputAlreadyUnbind)
            {
                playerMove.UnBindInput();
                playerAttack.UnBindInput();
            }
        }

        public override bool ReceiveHealth(int amount)
        {
            if(this.health + amount <= 100)
            {
                this.health += amount;
                return true;
            }
            return false;
        }
    }
}
