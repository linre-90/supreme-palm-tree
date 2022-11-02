using Footkin.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

namespace Footkin.Controller
{
    /// <summary>
    /// Weapon class
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public DamageData damageData;
        private List<GameObject> enemies;
        private Timer cooldownTimer;
        private bool usable = false;

        [SerializeField]
        GameObject projectile;

        private void Awake()
        {
            enemies = new List<GameObject>();
            cooldownTimer = new Timer(damageData.cooldown);
            cooldownTimer.Elapsed += OnTimedEvent;
        }

        private void Start()
        {
            cooldownTimer.Enabled = true;
            cooldownTimer.Start();
        }

        private void OnDestroy()
        {
            cooldownTimer.Elapsed -= OnTimedEvent;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(damageData.targetTag))
            {
                enemies.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {

            if (other.CompareTag(damageData.targetTag))
            {
                try
                {
                    enemies.Remove(other.gameObject);
                }
                catch (System.Exception) { }
            }
        }

        /// <summary>
        /// Overloaded method in ranged weapon.
        /// </summary>
        virtual public void AttackEnemy()
        {
            if (usable)
            {
                usable = false;
                cooldownTimer.Interval = damageData.cooldown;
                cooldownTimer.Start();
                DoDamage();
            }
        }

        private void DoDamage()
        {
            if(enemies.Count > 0)
            {
                // TODO call attack animation
                if (damageData.type.Equals("MELEE"))
                {
                    foreach (GameObject enemy in enemies)
                    {
                        // Expert error handling for null reference....
                        try
                        {
                            enemy.gameObject.GetComponent<Character>().ReceiveDamage(damageData.HitPoints);
                        }
                        catch (System.Exception) { }
                    }
                }

                if (damageData.type.Equals("RANGED"))
                {
                    Transform spawn = transform.GetChild(0).transform; /*GetComponentInChildren<Transform>()*/;
                    GameObject temp =  Instantiate(projectile, spawn.position, Quaternion.identity, null);
                    ProjectileController x = temp.GetComponent<ProjectileController>();
                    x.SetDamage(damageData.HitPoints);
                    x.SetDirection(-transform.parent.right);
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            cooldownTimer.Stop();
            usable = true;
        }
    } 
}
