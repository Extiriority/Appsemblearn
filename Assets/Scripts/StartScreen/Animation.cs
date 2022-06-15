using UnityEngine;

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

    private void Awake() {
        anim = GetComponent<Animator>();
    }
 
    public void Pressed() {
        anim.SetBool(onClick, true);
    }
    
    public void MedievalPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        
        anim.SetBool(medievalClick, true);
    }
    
    public void TutorialPressed() {
        anim.SetBool(medievalClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        
        anim.SetBool(tutorialClick, true);
    }
    
    public void PiratePressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(cavernClick, false);
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        
        anim.SetBool(pirateClick, true);
    }
    
    public void IcePressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(cavernClick, false);
        anim.SetBool(lavaClick, false);
        
        anim.SetBool(iceClick, true);
    }
    
    public void CavernPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(iceClick, false);
        anim.SetBool(lavaClick, false);
        
        anim.SetBool(cavernClick, true);
    }
    
    public void LavaPressed() {
        anim.SetBool(tutorialClick, false);
        anim.SetBool(pirateClick, false);
        anim.SetBool(medievalClick, false);   
        anim.SetBool(iceClick, false);
        anim.SetBool(cavernClick, false);
        
        anim.SetBool(lavaClick, true);
    }
}
