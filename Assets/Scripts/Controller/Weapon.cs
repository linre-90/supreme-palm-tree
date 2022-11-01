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
            Debug.Log("asdasd");
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
                enemy.GetComponent<EnemyController>().ReceiveDamage(damageData.HitPoints);
            }
        }

    } 
}
