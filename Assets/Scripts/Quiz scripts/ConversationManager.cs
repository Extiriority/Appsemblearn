using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

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
    public bool NextQuestion()
    {
        if (!questionQueue.Any()) return false; 

        questionQueue.Dequeue();
        foreach (var t in questionList.Where(t => questionList.Count != 0)) {
            if (questionQueue.Any()) {
                var next = questionQueue.Peek();
                if (currectQuestion == next) continue;
                currectQuestion = next;
                answerHandler.BindingDataToUI();
                return true;
            }
            gameObject.SetActive(false);
            return false;
        }
        return false;
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
