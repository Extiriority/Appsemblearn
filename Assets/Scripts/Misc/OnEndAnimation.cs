using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEndAnimation : MonoBehaviour
{
    
    private static readonly int mainMenuClick = Animator.StringToHash("MainMenuClick");

    private Animator anim;
    
    private void Awake() {
        anim = GetComponent<Animator>();
    }
    
    public void ToMainMenu() {
        StartCoroutine(waitTransitionCongrats());
    }
        
    private IEnumerator waitTransitionCongrats() {
        yield return new WaitForSeconds(4f);
        anim.SetBool(mainMenuClick, true);
        StartCoroutine(waitTransitionMainMenu());
    }
    private IEnumerator waitTransitionMainMenu() {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(0);
    }
    
}
