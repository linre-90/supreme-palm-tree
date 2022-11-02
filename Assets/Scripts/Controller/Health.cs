using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace MyNamespace
{
    public class Health : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                bool collected = other.GetComponent<Character>().ReceiveHealth(35);
                if (collected)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}