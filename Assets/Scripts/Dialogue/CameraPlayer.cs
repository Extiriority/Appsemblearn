using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable interactable { get; set; }

    private void Update() {
        if (DialogueUI.IsOpen) return;
        interactable?.Interact(this);
    }
}
