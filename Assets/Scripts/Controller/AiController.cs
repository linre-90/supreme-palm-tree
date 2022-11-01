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
            // Todo raycast
            attack.OnMeleeAttack();
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
