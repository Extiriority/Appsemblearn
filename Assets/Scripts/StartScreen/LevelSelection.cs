using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] public GameObject levelObject;
    [SerializeField] public Level levelData;
    [SerializeField] public Canvas canvas;

    public void ShowLevelInfo()
    {
        SceneManager.LoadScene(1);
    }

}
