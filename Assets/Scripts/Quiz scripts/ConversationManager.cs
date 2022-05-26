using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConversationManager : MonoBehaviour
{
    //Current question and answers.
    [Header("First question")]
    [SerializeField] private Question question;
    
    [Header("Current question")]
    [SerializeField] private Question currectQuestion;

    [Header("All questions in this scene")]
    [SerializeField] List<Question> questionList;

    [SerializeField] private Queue<Question> questionQueue;

    [SerializeField] List<Button> answerButtons;

    [SerializeField] private AnswerHandler answerHandler;

    public List<Button> AnswerButton => answerButtons;
    public Question CurrentQuestion => currectQuestion; 



    private void Start()
    {
        currectQuestion = question;
        Queue<Question> _questionQueue = new Queue<Question>(questionList);
        questionQueue = _questionQueue;

        answerHandler = GetComponentInChildren<AnswerHandler>();

        answerHandler.BindingDataToUI();
        //answerHandler.UpdateButtons();
    }
 
    /// <summary>
    /// Sends the user to the next question in the queue.
    /// </summary>
    public void NextQuestion()
    {
        questionQueue.Dequeue();
        for (int i = 0; i < questionList.Count; i++)
        {
            if (questionList.Count != 0) {
                var next = questionQueue.Peek();
                if (currectQuestion != next)
                {
                    currectQuestion = next;
                    answerHandler.BindingDataToUI();
                }
            } 
        }
    }

    /// <summary>
    /// Is called in a OnEventEnded
    /// </summary>
    public void SyncUI()
    {
        GetComponentInChildren<DialogueUI>().dialogueObject.question = currectQuestion;
        TextMeshProUGUI uiQuestion = GameObject.FindGameObjectWithTag("question").GetComponent<TextMeshProUGUI>();
        uiQuestion.text = GetComponentInChildren<DialogueUI>().dialogueObject.question.questionString;
    }
}
