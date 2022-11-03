using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace Footkin.Controller
{
    /// <summary>
    /// Enables following capabilities for ai controlled game.
    /// </summary>
    public class Follower : AiControllable
    {
        Vector3 detectedPosition;
        [SerializeField]
        AiController aiController;
        
        /*
        private void OnTriggerEnter(Collider other)
        {
            detectedPosition = other.gameObject.transform.position;
            Follow();
        }*/

        private void OnTriggerExit(Collider other)
        {
            aiController.LostPlayer();
        }

        private void OnTriggerStay(Collider other)
        {
            detectedPosition = other.gameObject.transform.position;
            Follow();
        }

        private void Follow()
        {
            aiController.SetPlayerDetected(detectedPosition);
        }
    } 
}
