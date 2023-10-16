using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUIController : MonoBehaviour
{
    private Slider lifeSlider;

    private void OnEnable()
    {
        PlayerObserverManager.OnLifeChanged += UpdateLife;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnLifeChanged -= UpdateLife;
    }

    private void UpdateLife(int value)
    {
        lifeSlider.value = value;
    }

    private void Awake()
    {
        lifeSlider = GetComponent<Slider>();
    }
}
