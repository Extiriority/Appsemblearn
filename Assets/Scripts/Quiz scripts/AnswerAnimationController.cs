using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnswerAnimationController : MonoBehaviour
{
    bool isUp = false;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void CheckState()
    {
        if (isUp)
        {
            HideAnswers();
        }
        else
        {
            ShowAnswers();
        }
    }

    public void ShowAnswers()
    {
        Debug.Log("OK");
        isUp = true;
        animator.SetTrigger("GoUp");
    }

    public void HideAnswers()
    {
        Debug.Log("NO");
        isUp = false;
        animator.SetTrigger("GoDown");
    }
}
