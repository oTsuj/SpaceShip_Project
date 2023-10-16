using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerObserverManager
{
    public static Action<int> OnPointsChanged;

    public static void PointsChanged(int points)
    {
        OnPointsChanged?.Invoke(points);
    }


    public static Action<int> OnLifeChanged;

    public static void LifeChanged(int life)
    {
        OnLifeChanged?.Invoke(life);
    }
}
