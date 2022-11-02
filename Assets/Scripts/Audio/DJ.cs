using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Footkin.Audio
{
    public class DJ : MonoBehaviour
    {
        [SerializeField] AudioClip[] playList;

        AudioSource audioSource;
        int currentSource;


        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            currentSource = 0;

        }

        private void Start()
        {
            audioSource.clip = playList[currentSource];
            audioSource.Play();
        }

        private void Update()
        {
            if(!audioSource.isPlaying)
            {
                if(currentSource + 1 >= playList.Length)
                {
                    currentSource = 0;
                }
                else
                {
                    currentSource++;
                }

                audioSource.clip = playList[currentSource];
                audioSource.Play();
            }
        }
    } 
}
