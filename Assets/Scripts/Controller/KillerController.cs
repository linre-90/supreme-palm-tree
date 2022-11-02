using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Footkin.Controller
{
    public class KillerController : MonoBehaviour
    {
        [SerializeField] float DeathTime;

        // Update is called once per frame
        void Update()
        {
            DeathTime -= Time.deltaTime;
            if (DeathTime < 0)
            {
                Destroy(this.gameObject);
            }
        }
    } 
}
