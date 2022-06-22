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
        Invoke("DisableCanvas", 1f);
        ani.SetTrigger("FadeOut");
    }

    void DisableCanvas()
    {
        this.gameObject.GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
}
