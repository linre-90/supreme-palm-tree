using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace Footkin.Controller
{
    public class EnemyController : Character
    {
        int health;

        private void Awake()
        {
            health = characterData.Health;
        }

        override public void ReceiveDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public override void ReceiveHealth(int amount){}
    } 
}
