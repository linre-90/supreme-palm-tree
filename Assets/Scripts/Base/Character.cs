using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Common;
using Footkin.Controller;

namespace Footkin.Base
{
    public class Character : MonoBehaviour
    {
        public CharacterData characterData;

        [SerializeField]
        private IAnimationController animationController;

        [SerializeField]
        private Attack attack;

    } 
}
