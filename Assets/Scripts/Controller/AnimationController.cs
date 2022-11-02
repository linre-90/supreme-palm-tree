using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Common;


namespace Footkin.Controller
{
    public class AnimationController: MonoBehaviour, IAnimationController
    {
        [SerializeField]
        Animator animator;

        public AnimationData animationData;

        public void ResetBooleanToFalse(string name) => animator.SetBool(name, false);

        public void SetBoolean(string name, bool value) => animator.SetBool(name, value);
       
    }
}
