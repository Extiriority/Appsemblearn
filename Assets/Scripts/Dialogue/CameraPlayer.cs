using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable interactable { get; set; }

    private void Update()
    {
        if (DialogueUI.isOpen) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(Input.GetKeyDown(KeyCode.E));
            Debug.Log(interactable);
            interactable?.Interact(this);
        }
    }
}
