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
            Debug.Log("asdasdasd");
            health -= damage;
            if(health <= 0)
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
            health = characterData.Health;
        }
        private void Update()
        {
            //Debug.Log(health);
        }

        private void OnDestroy()
        {
            if (!inputAlreadyUnbind)
            {
                playerMove.UnBindInput();
                playerAttack.UnBindInput();
            }
        }
    }
}
