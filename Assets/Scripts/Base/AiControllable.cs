using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Controller;

namespace Footkin.Base
{
    /// <summary>
    /// Base class for enemy behaviours
    /// </summary>
    public class AiControllable : MonoBehaviour
    {
        protected Vector3 originalPosition;

        private void Awake()
        {
            this.originalPosition = this.transform.position;
        }

    } 
}
