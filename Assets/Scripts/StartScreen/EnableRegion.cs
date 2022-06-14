using System.Collections;
using UnityEngine;

public class EnableRegion : MonoBehaviour {
    public GameObject[] regions;
    public GameObject veil;

    public void Start() {
        StartCoroutine(wait());
    }

    private IEnumerator wait() {
        yield return new WaitForSecondsRealtime(1f);
        foreach (var region in regions) 
             region.SetActive(false);
    }
    
    public void whenButtonClicked() {
        foreach (var region in regions) 
            region.SetActive(region.activeInHierarchy == false);
        veil.SetActive(false);
    }
}
