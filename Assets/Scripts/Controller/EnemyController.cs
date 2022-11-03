using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace Footkin.Controller
{
    public class EnemyController : Character
    {
        int health;
        [SerializeField] GameObject deathClipAudioPLayer;

        private void Awake()
        {
            health = characterData.Health;
        }

        override public void ReceiveDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Instantiate(deathClipAudioPLayer, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        public override bool ReceiveHealth(int amount){ return false; }
    } 
}
