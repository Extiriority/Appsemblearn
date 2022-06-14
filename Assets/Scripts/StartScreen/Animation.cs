using System.Collections;
using System.Collections.Generic;
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
}
