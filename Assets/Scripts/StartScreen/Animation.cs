using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
 
    private void Awake() {
        anim = GetComponent<Animator>();
    }
 
    public void Pressed() {
        anim.SetBool("OnClick", true);
    }
    
    public void MedievalPressed() {
        anim.SetBool("TutorialClick", false);
        anim.SetBool("PirateClick", false);
        anim.SetBool("CavernClick", false);
        anim.SetBool("IceClick", false);
        anim.SetBool("LavaClick", false);
        
        anim.SetBool("MedievalClick", true);
    }
    
    public void TutorialPressed() {
        anim.SetBool("MedievalClick", false);
        anim.SetBool("PirateClick", false);
        anim.SetBool("CavernClick", false);
        anim.SetBool("IceClick", false);
        anim.SetBool("LavaClick", false);
        
        anim.SetBool("TutorialClick", true);
    }
    
    public void PiratePressed() {
        anim.SetBool("TutorialClick", false);
        anim.SetBool("MedievalClick", false);   
        anim.SetBool("CavernClick", false);
        anim.SetBool("IceClick", false);
        anim.SetBool("LavaClick", false);
        
        anim.SetBool("PirateClick", true);
    }
    
    public void IcePressed() {
        anim.SetBool("TutorialClick", false);
        anim.SetBool("PirateClick", false);
        anim.SetBool("MedievalClick", false);   
        anim.SetBool("CavernClick", false);
        anim.SetBool("LavaClick", false);
        
        anim.SetBool("IceClick", true);
    }
    
    public void CavernPressed() {
        anim.SetBool("TutorialClick", false);
        anim.SetBool("PirateClick", false);
        anim.SetBool("MedievalClick", false);   
        anim.SetBool("IceClick", false);
        anim.SetBool("LavaClick", false);
        
        anim.SetBool("CavernClick", true);
    }
    
    public void LavaPressed() {
        anim.SetBool("TutorialClick", false);
        anim.SetBool("PirateClick", false);
        anim.SetBool("MedievalClick", false);   
        anim.SetBool("IceClick", false);
        anim.SetBool("CavernClick", false);
        
        anim.SetBool("LavaClick", true);
    }
}
