using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] CharacterData characterData;
    public Slider slider;

    public void Update()
    {
        slider.value = characterData.Health;
    }
}
