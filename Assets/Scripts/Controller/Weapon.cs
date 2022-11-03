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

        [SerializeField]
        AnimationController animationController;

        [SerializeField] GameObject punchVfx;

        [SerializeField] CharacterAudio characterAudio;

        [SerializeField] GameObject rangedIndicator;


        bool indicatorOnState = false;

        private void Awake()
        {
            enemies = new List<GameObject>();
            cooldownTimer = new Timer(damageData.cooldown);
            cooldownTimer.Elapsed += OnTimedEvent;
            indicatorOnState = false;
        }

        private void Start()
        {
            cooldownTimer.Enabled = true;
            cooldownTimer.Start();
        }

        private void Update()
        {
            if(rangedIndicator)
            {
                rangedIndicator.SetActive(indicatorOnState);
            }
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

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(damageData.targetTag))
            {
                if (!enemies.Contains(other.gameObject))
                {
                    enemies.Add(other.gameObject);
                }
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
                indicatorOnState = false;
                usable = false;
                cooldownTimer.Interval = damageData.cooldown;
                cooldownTimer.Start();
                DoDamage();
            }
        }

        private void DoDamage()
        {

            if (damageData.type.Equals("MELEE"))
            {
                characterAudio.ModifySound(CharacterAudio.Sounds.melee, CharacterAudio.SoundModifier.play);
                characterAudio.ModifySound(CharacterAudio.Sounds.walk, CharacterAudio.SoundModifier.stop);
                animationController.SetBoolean(animationController.animationData.melee, true);
                foreach (GameObject enemy in enemies)
                {
                    // Expert error handling for null reference....
                    try
                    {
                        enemy.gameObject.GetComponent<Character>().ReceiveDamage(damageData.HitPoints);
                        Instantiate(punchVfx, enemy.transform.position, Quaternion.identity);

                    }
                    catch (System.Exception) { }
                }
            }


            if (damageData.type.Equals("RANGED"))
            {
                characterAudio.ModifySound(CharacterAudio.Sounds.range, CharacterAudio.SoundModifier.play);
                animationController.SetBoolean(animationController.animationData.ranged, true);
                Transform spawn = transform.GetChild(0).transform;
                GameObject temp = Instantiate(projectile, spawn.position, Quaternion.identity, null);
                ProjectileController x = temp.GetComponent<ProjectileController>();
                temp.transform.rotation = transform.parent.rotation;
                x.SetDamage(damageData.HitPoints);
                x.SetDirection(-transform.parent.right);
            }

            // Flush enemies list
            enemies.Clear();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            cooldownTimer.Stop();
            usable = true;
            indicatorOnState = true;
        }
    }
}
