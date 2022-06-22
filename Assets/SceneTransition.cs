using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Animator ani;

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        ani.SetTrigger("FadeOut");
    }
}
