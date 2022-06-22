using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject workshopUI;
    [SerializeField] GameObject shieldUI;

    public void StartDollyTrack(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        if (playableDirector.GetComponent<Animator>())
        {
            StartCoroutine(DelayedUI(1.5f));
        }
    }

    IEnumerator DelayedUI(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        //Enable Dialogue
        workshopUI.SetActive(true);
        shieldUI.SetActive(true);
    }
}
