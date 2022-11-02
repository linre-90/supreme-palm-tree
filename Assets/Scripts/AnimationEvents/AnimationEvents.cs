using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Common;
using Footkin.Controller;

namespace Footkin.Animation
{
    public class AnimationEvents : MonoBehaviour
    {
        public AnimationController animationController;

        public void OnBoolReset(string name) => animationController.ResetBooleanToFalse(name);
        
    } 
}
