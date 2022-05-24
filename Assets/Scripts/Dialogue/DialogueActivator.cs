using System;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && other.TryGetComponent(out CameraPlayer cameraPlayer))
        {
            Debug.Log("works");
            cameraPlayer.interactable = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") && other.TryGetComponent(out CameraPlayer cameraPlayer))
        {
            if (cameraPlayer.interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                Debug.Log("Null");
                cameraPlayer.interactable = null;
            }
        }
    }

    public void Interact(CameraPlayer cameraplayer)
    {
        cameraplayer.DialogueUI.showDialogue(dialogueObject);
    }
}
