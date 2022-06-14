using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    [Header("Dialogue objects")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject customer;
    [SerializeField] public DialogueObject dialogueObject;
    [SerializeField] private TMP_Text textLabel;
    public bool IsOpen { get; private set; }
    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
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
            customer.GetComponent<Animator>().SetBool("Talking", true);
            string dialogue = dialogueObject.Dialogue[i];
            textLabel.text = dialogue;
            yield return RunTypingEffect(dialogue);
            customer.GetComponent<Animator>().SetBool("Talking", false);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

    }


    //Calls the typewriter effect and allows you to stop dialogue when space bar is clicked.
    private IEnumerator RunTypingEffect(string dialogue)
    {
        typeWriterEffect.run(dialogue, textLabel);
        while (typeWriterEffect.isRunning)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                typeWriterEffect.Stop();
            }
        }
    }
}
