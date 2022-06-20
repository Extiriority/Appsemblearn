using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    private Animator anim;
    private static readonly int onClick = Animator.StringToHash("OnClick");
    private static readonly int tutorialClick = Animator.StringToHash("TutorialClick");
    private static readonly int pirateClick = Animator.StringToHash("PirateClick");
    private static readonly int cavernClick = Animator.StringToHash("CavernClick");
    private static readonly int iceClick = Animator.StringToHash("IceClick");
    private static readonly int lavaClick = Animator.StringToHash("LavaClick");
    private static readonly int medievalClick = Animator.StringToHash("MedievalClick");
    private static readonly int startClick = Animator.StringToHash("startClick");

    private void Awake() {
        anim = GetComponent<Animator>();
    }
 
    public void Pressed() {
        anim.SetBool(onClick, true);
    }
    
    public void MedievalClick() {
        anim.SetTrigger(startClick);
        StartCoroutine(waitTransitionMedieval());
    }

    private IEnumerator waitTransitionMedieval() {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(2);
    }
    
    public void PirateClick() {
        anim.SetTrigger(startClick);
        StartCoroutine(waitTransitionPirate());
    }

    private IEnumerator waitTransitionPirate() {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }

    
    public void MedievalPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(medievalClick, true);
    }
    
    public void TutorialPressed() {
        anim.SetBool(medievalClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(tutorialClick, true);
    }
    
    public void PiratePressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(pirateClick, true);
    }
    
    public void IcePressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(cavernClick, false);
        anim.SetBool(lavaClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(iceClick, true);
    }
    
    public void CavernPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(cavernClick, true);
    }
    
    public void LavaPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(iceClick, false);
        anim.SetBool(cavernClick, false);
        SoundManager.instance.play("Select");
        anim.SetBool(lavaClick, true);
    }
}
