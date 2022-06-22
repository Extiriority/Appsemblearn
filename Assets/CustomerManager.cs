using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{

    private Animator animator;

    [Header("All potential customers")]
    [SerializeField] private ShieldSO[] requestList;
    [SerializeField] private Customer currentCustomer;
    [SerializeField] private GameObject customerUI;
    
    public GameObject dialogueBox;
    
    [Header("Request fields")]
    public GameObject requestBox;
    public TextMeshProUGUI colorBox;
    public TextMeshProUGUI typeBox;
    public TextMeshProUGUI iconBox;

    private void Start()
    {
        SetRandomCustomer();
        animator = currentCustomer.GetComponent<Animator>();
    }

    private void SetRandomCustomer()
    {
        System.Random rnd = new();
        int index = rnd.Next(requestList.Length);
        currentCustomer.requestedShield = requestList[index];
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
            SoundManager.instance.changeVolume("Theme", 0.1f);
        }
    }

    IEnumerator DelayedDialogue(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);

        //Enable Dialogue
        customerUI.SetActive(true);
    }

    public void ShowRequestedItem()
    {
        dialogueBox.SetActive(false);
        requestBox.SetActive(true);
        Customer customer = currentCustomer.GetComponent<Customer>();
        colorBox.text = "Color: " + "#" + ColorUtility.ToHtmlStringRGB(customer.requestedShield.color); 
        typeBox.text =  "Type: " + customer.requestedShield.shieldType.name.ToString();
        iconBox.text =  "Icon: " + customer.requestedShield.icon.ToString();
    }

    public void HideUi()
    {
        customerUI.SetActive(false);
        SoundManager.instance.play("ButtonPress");
    }
}
