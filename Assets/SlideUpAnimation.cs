using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SlideUpAnimation : MonoBehaviour
{
    [SerializeField] PlayableDirector animationUp;
    [SerializeField] PlayableDirector animationDown;

    public void ShowAnswers()
    {
        Debug.Log("it Arrived");
        animationUp.Play();
    }

    public void HideAnswers()
    {
        animationDown.Play();
    }
}
