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
        Vector3 orgPosition;

        [SerializeField]
        EnemyMove enemyMove;

        private void Awake()
        {
            orgPosition = transform.position;
        }

        private void Update()
        {
            if (followPlayer)
            {
                // Follow to right
                if(detectionPosition.x >= orgPosition.x)
                {
                    enemyMove.OnMoveRight(true);
                }

                if (detectionPosition.x < orgPosition.x)
                {
                    enemyMove.OnMoveLeft(true);
                }
                followPlayer = false;
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
