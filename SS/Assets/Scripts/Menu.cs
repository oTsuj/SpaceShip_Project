using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private string nomeLevelJogo;
    public void Play()
    {
        GameManager.Instance.ChamarCenas();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
