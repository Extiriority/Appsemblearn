using System;
using System.Collections;
using UnityEngine;
using TMPro;
public class DialogueUI : MonoBehaviour
{
    [Header("Dialogue UI settings")]
    [Tooltip("Reference your dialogue box here")]
    [SerializeField] private GameObject dialogueBox;
    [Tooltip("Reference your Text (TMP here)")]
    [SerializeField] private TMP_Text textLabel;
    
    public bool isOpen { get; private set; }
    
    private TypeWriterEffect typeWriterEffect;
    private void Start() {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        closeDialogueBox();
    }
 
    public void showDialogue(DialogueObject dialogueObject) {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(stepThroughDialogue(dialogueObject));
    }

    private IEnumerator stepThroughDialogue(DialogueObject dialogueObject) {
        foreach (string dialogue in dialogueObject.Dialogue) {
            yield return runTypingEffect(dialogue);
            textLabel.text = dialogue;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        closeDialogueBox();
    }

    private IEnumerator runTypingEffect(string dialogue) {
        typeWriterEffect.run(dialogue, textLabel);
        while (typeWriterEffect.isRunning) {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space)) {
                typeWriterEffect.Stop();
            }
        }
    }
    
    private void closeDialogueBox() {
        isOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
 