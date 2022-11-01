using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Footkin.Controller
{
    /// <summary>
    /// Weapon class
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public DamageData damageData;
        private List<GameObject> enemies;

        private void Awake()
        {
            enemies = new List<GameObject>();
        }

        private void OnTriggerEnter(Collider other)
        {
            enemies.Add(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            try
            {
                enemies.Remove(other.gameObject);
            }
            catch (System.Exception){}
            
        }

        public void AttackEnemy()
        {
            DoDamage();
        }

        private void DoDamage()
        {
            foreach (GameObject enemy in enemies)
            {
                // Expert error handling for null reference....
                try
                {
                    enemy.GetComponent<EnemyController>().ReceiveDamage(damageData.HitPoints);
                }
                catch (System.Exception){}
            }
        }
    } 
}
