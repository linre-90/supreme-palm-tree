using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public enum Sounds
    {
        walk,
        melee,
        jump,
        range
    }

    public enum SoundModifier
    {
        play,
        stop
    }

    [SerializeField] AudioSource footstepSource;

    [SerializeField] AudioSource meleeSource;

    [SerializeField] AudioSource jumpSource;

    [SerializeField] AudioSource rangedSource;


    public void ModifySound(Sounds sound, SoundModifier soundModifier, bool oneShot = true)
    {
        AudioSource x = GetSource(sound);

        switch (soundModifier)
        {
            case SoundModifier.play:
                if(!oneShot)
                {
                    if (!x.isPlaying)
                    {
                        x.Play();
                    }
                }
                else
                {
                    x.PlayOneShot(x.clip);
                }
                break;
            case SoundModifier.stop:
                x.Stop();
                break;
            default:
                break;
        }
    }

    private AudioSource GetSource(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.walk:
                return footstepSource;
            case Sounds.melee:
                return meleeSource;
            case Sounds.jump:
                return jumpSource;
            case Sounds.range:
                return rangedSource;
            default:
                return null;
        }
    }
}
