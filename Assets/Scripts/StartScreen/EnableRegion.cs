using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnableRegion : MonoBehaviour
{
    private Animator anim;
    public GameObject[] regions;
    public GameObject veil;

    public bool pressed;
    public void Start() {
        anim = GetComponent<Animator>();
        StartCoroutine(wait());
    }

    private IEnumerator wait() {
        yield return new WaitForSecondsRealtime(1f);
        foreach (var region in regions) 
             region.SetActive(false);
    }
    
    public void whenButtonClicked() {
        anim.SetBool("OnClick", true);
        pressed = true;
        foreach (var region in regions) 
            region.SetActive(region.activeInHierarchy == false);
        
        veil.SetActive(false);
    }
}
