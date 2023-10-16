using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsUiController : MonoBehaviour
{
    private Text pointsText;
    
    private void OnEnable()
    {
        PlayerObserverManager.OnPointsChanged += UpdatePoints;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnPointsChanged -= UpdatePoints;
    }

    private void Awake()
    {
        pointsText = GetComponent<Text>();
    }

    private void UpdatePoints(int value)
    {
        pointsText.text = value.ToString();
    }
}
