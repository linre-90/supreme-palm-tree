using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Footkin.Controller
{
    /// <summary>
    /// Orchestrates enemy behaviour using components like: <br></br>
    /// </summary>
    public class AiController : MonoBehaviour
    {
        bool followPlayer;
        Vector3 detectionPosition;

        [SerializeField]
        EnemyMove enemyMove;

        [SerializeField]
        Attack attack;

        private void Update()
        {
            if (followPlayer)
            {
                // Follow to right
                if(detectionPosition.x >= transform.position.x)
                {
                    enemyMove.OnMoveRight(true);
                }

                if (detectionPosition.x < transform.position.x)
                {
                    enemyMove.OnMoveLeft(true);
                }
                followPlayer = false;
            }

            //Debug.DrawRay(this.transform.position, -transform.GetChild(0).transform.right * 2f, Color.red, 1f);
            // hit detection for melee attack key press
            if (Physics.Raycast(this.transform.position, -transform.GetChild(0).transform.right, out RaycastHit hit, 2f, 1 << 6))
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    if (attack.meleeWeapon)
                    {
                        attack.OnMeleeAttack();
                    }
                }
            }

            //Debug.DrawRay(this.transform.position, -transform.GetChild(0).transform.right * 8f, Color.red, 1f);
            // hit detection for ranged attack key press
            if (Physics.Raycast(this.transform.position, -transform.GetChild(0).transform.right, out RaycastHit rangedhit, 8f, 1 << 6))
            {
                if (rangedhit.transform.gameObject.CompareTag("Player"))
                {
                    if (attack.rangedWeapon)
                    {
                        attack.OnRangedAttack();
                    }
                }
            }
        }

        public void SetPlayerDetected(Vector3 detectedPosition)
        {
            followPlayer = true;
            this.detectionPosition = detectedPosition;
        }

        public void LostPlayer()
        {
            followPlayer = false;
            enemyMove.OnMoveRight(false);
            enemyMove.OnMoveLeft(false);
        }
    }
}
