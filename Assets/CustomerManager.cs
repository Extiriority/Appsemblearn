using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{

    private Animator animator;

    [Header("All potential customers")]
    [SerializeField] private GameObject[] customerList;
    [SerializeField] private GameObject currentCustomer;
    [SerializeField] private GameObject dialogueBox;

    private void Start()
    {
        currentCustomer = customerList[0];
        animator = currentCustomer.GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("WalkingEnd"))
        {
            onAnimationEnd();
        }
    }

    private void onAnimationEnd()
    {
        if (animator)
        {
            StartCoroutine(DelayedDialogue(animator.GetCurrentAnimatorStateInfo(0).length));
        }

    }

    IEnumerator DelayedDialogue(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        //Enable Dialogue
        dialogueBox.SetActive(true);
    }
}
