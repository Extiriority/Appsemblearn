using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.Playables;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] public DialogueObject dialogueObject;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private AnswerHandler answerHandler;
    [SerializeField] public AnswerAnimationController answerAnimationController;
    [SerializeField] public GameObject up;


    public UnityEvent onDialogueEnded;
    
    public bool isOpen { get; private set; }
    
    private TypeWriterEffect typeWriterEffect;
    private void Start() 
    {
        answerHandler = GetComponent<AnswerHandler>();
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        //closeDialogueBox();
        showDialogue(dialogueObject);
    }
 
    public void showDialogue(DialogueObject dialogueObject) 
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(stepThroughDialogue(dialogueObject));
    }

    private IEnumerator stepThroughDialogue(DialogueObject dialogueObject) 
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            textLabel.text = dialogue;
            yield return runTypingEffect(dialogue);
            if (i == dialogueObject.Dialogue.Length && dialogueObject.HasAnswers)
            {
                break;
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogueObject.HasAnswers)
        {
            up.SetActive(true);

            answerAnimationController.ShowAnswers();
            answerHandler.UpdateButtons();
        }
        else
        {
            closeDialogueBox();
        }

        onDialogueEnded.Invoke();
    }

    private IEnumerator runTypingEffect(string dialogue) 
    {
        typeWriterEffect.run(dialogue, textLabel);
        while (typeWriterEffect.isRunning) 
        {
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
 