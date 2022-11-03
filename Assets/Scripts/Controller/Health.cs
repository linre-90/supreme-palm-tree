using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Footkin.Base;

namespace MyNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField] GameObject PickupAudioPlayer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                bool collected = other.GetComponent<Character>().ReceiveHealth(35);
                if (collected)
                {
                    Instantiate(PickupAudioPlayer, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}