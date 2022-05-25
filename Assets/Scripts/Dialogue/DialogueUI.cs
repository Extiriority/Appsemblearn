using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Events;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] public DialogueObject dialogueObject;
    [SerializeField] private TMP_Text textLabel;
    
    public UnityEvent onDialogueEnded;
    
    public bool isOpen { get; private set; }
    
    private TypeWriterEffect typeWriterEffect;
    private void Start() {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        //closeDialogueBox();
        showDialogue(dialogueObject);
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
        onDialogueEnded.Invoke();
        //closeDialogueBox();
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
 