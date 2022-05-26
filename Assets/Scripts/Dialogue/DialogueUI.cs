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
    [Header("Dialogue objects")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] public DialogueObject dialogueObject;
    [SerializeField] private TMP_Text textLabel;

    [Header("Answer management")]
    [SerializeField] private AnswerHandler answerHandler;

    [Tooltip("This controller manages the showing and hiding of buttons.")]
    [SerializeField] public AnswerAnimationController answerAnimationController;

    [Tooltip("Button that allows you to hide the answerButtons.")]
    [SerializeField] public GameObject up;

    public UnityEvent onDialogueEnded;
    public bool IsOpen { get; private set; }
    private TypeWriterEffect typeWriterEffect;

    private void Start() 
    {
        answerHandler = GetComponent<AnswerHandler>();
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        ShowDialogue(dialogueObject);
    }
 
    public void ShowDialogue(DialogueObject dialogueObject) 
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject) 
    {
        //Looping through dialogue and running through it again when spacebar is clicked.
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            textLabel.text = dialogue;
            yield return RunTypingEffect(dialogue);

            if (i == dialogueObject.Dialogue.Length && dialogueObject.HasAnswers)
            {
                break;
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        //If the dialogue is a question that can be answered, activate up button and show answers
        if (dialogueObject.HasAnswers)
        {
            up.SetActive(true);

            answerAnimationController.ShowAnswers();
            answerHandler.UpdateButtons();
        }

        //This invoke calls SyncUI which makes sure that the ui is up to date with the dialogue
        onDialogueEnded.Invoke();
    }


    //Calls the typewriter effect and allows you to stop dialogue when space bar is clicked.
    private IEnumerator RunTypingEffect(string dialogue) 
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
}
 