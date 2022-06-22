using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject workshopUI;
    [SerializeField] GameObject shieldUI;
    [SerializeField] GameObject blacksmithDialogue;

    [Header("Customer objects")]
    [SerializeField] GameObject customer;
    [SerializeField] GameObject customerAnimator;

    public void StartDollyTrack(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        OnAnimationEnd(playableDirector);
    }

    public void OnAnimationEnd(PlayableDirector playableDirector)
    {
        Animator anim = playableDirector.GetComponent<Animator>();
        if (playableDirector.GetComponent<Animator>())
        {
            StartCoroutine(DelayedUI(anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator DelayedUI(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        //Enable Dialogue
        workshopUI.SetActive(true);
        shieldUI.SetActive(true);
    }

    public void StartDialogue()
    {
        blacksmithDialogue.SetActive(true);
    }

    public void ChangeCamPrio(CinemachineVirtualCamera camToMoveTo)
    {

        blacksmithDialogue.SetActive(false);
        camToMoveTo.Priority = 11;
        customer.SetActive(true);
        customerAnimator.GetComponent<Animator>().Play("OpenDoor");
    }
}
