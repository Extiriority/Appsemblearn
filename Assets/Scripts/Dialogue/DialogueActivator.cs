using System.Collections;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [Header("Dialogue Settings")]
    [Tooltip("Choose a dialogue script for this specific camera when panned to")]
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter(Collider other) {
        StartCoroutine(waitTilPan(other));
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("MainCamera") || !other.TryGetComponent(out CameraPlayer cameraPlayer)) return;
        if (cameraPlayer.interactable is DialogueActivator dialogueActivator && dialogueActivator == this) {
            cameraPlayer.interactable = null;
        }
    }

    public void Interact(CameraPlayer cameraPlayer) {
        cameraPlayer.DialogueUI.showDialogue(dialogueObject);
    }
    
    private IEnumerator waitTilPan(Collider other) {
        yield return new WaitForSeconds(1f);
        if (other.CompareTag("MainCamera") && other.TryGetComponent(out CameraPlayer cameraPlayer)) {
            cameraPlayer.interactable = this;
        }
    }
}
