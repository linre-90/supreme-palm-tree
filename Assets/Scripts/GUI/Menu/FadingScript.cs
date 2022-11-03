using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject deathImage;
    [SerializeField] private GameObject winImage;
    public bool fadeInReady = false;
    public bool fadeOutReady = false;

    public CharacterData characterData;

    /*
     *   fadeOutReady = Scenen vaihto, pelin alku jne. (Alpha 1 -> 0)           |||  Call: FadingScript.fadeOutReady = true; (False after done)
     *   fadeInReady = Päinvastainen, esim kuolema screeniin. (Alpha 0 -> 1)    |||  Call: FadingScript.fadeInReady = true;  (False after done)
     *   
     *   Scenen vaihto metodi kutsu:    FadingScript.StartingFade();  
     *   Kuolema metodi kutsu:          FadingScript.DeathFade();
     * 
     * */


    private void Start()
    {
        
        StartingFade();
        deathImage.SetActive(false);
    }

    void Update()
    {
        if (fadeInReady)
        {
            canvasGroup.alpha += Time.unscaledDeltaTime * 2f;
            if (canvasGroup.alpha == 1)
            {
               fadeInReady = false;
            }
        }

        if (fadeOutReady)
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime * 0.4f;
          if (canvasGroup.alpha == 0)
          {
            fadeOutReady = false;
          }
        }

        if(characterData.Health <= 0)
        {
            DeathFade();
        }
    }

    public void StartingFade()
    {
        fadeInReady = false;
        fadeOutReady = true;
    }

    public void DeathFade()
    {
        fadeOutReady = false;
        fadeInReady = true;
        deathImage.SetActive(true);
    }

    public void WinFade()
    {
        fadeOutReady = false;
        fadeInReady = true;
        winImage.SetActive(true);
    }
}
