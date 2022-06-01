using CamSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerHandler : MonoBehaviour
{
    private ConversationManager conversationManager;
    private DialogueUI dialogueUI;
    [SerializeField] private CameraAnchorManager cameraAnchorManager;

    private void Awake()
    {
        conversationManager = GetComponentInParent<ConversationManager>();
        dialogueUI = GetComponent<DialogueUI>();
    }

    /// <summary>
    /// This method sets the data for the ui elements. It fills in the textmeshes based on the scriptable objects.
    /// </summary>
    public void BindingDataToUI()
    {
        //Index to fill in numbered answer buttons.
        int i = 1;
        conversationManager.AnswerButton.Clear();

        foreach (Answer answer in conversationManager.CurrentQuestion.answers)
        {
            TextMeshProUGUI uiAnswer = GameObject.FindGameObjectWithTag("answer" + i).GetComponent<TextMeshProUGUI>();

            Button button = GameObject.FindGameObjectWithTag("button" + i).GetComponent<Button>();
            conversationManager.AnswerButton.Add(button);
            button.GetComponent<ButtonAnswer>().answer = answer;

            uiAnswer.text = answer.answerString;
            i++;
        }
    }

    public void UpdateButtons()
    {
        foreach (Button btn in conversationManager.AnswerButton)
        {
            Answer ans = btn.GetComponent<ButtonAnswer>().answer;
            btn.onClick.AddListener(delegate { OnAnswerPicked(ans); });
        }
    }

    public void OnAnswerPicked(Answer answer)
    {
        //Call animation down
        dialogueUI.answerAnimationController.HideAnswers();
        dialogueUI.up.SetActive(false);
        
        bool nextQuestionSet = conversationManager.NextQuestion();

        if (nextQuestionSet == false)
        {
            cameraAnchorManager.ActivateAnchor(2);
            return;
        }

        dialogueUI.ShowDialogue(answer.dialogueObject);
    }


}
