using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuestionManager : MonoBehaviour
{
    //Current question and answers.
    [Header("First question")]
    [SerializeField] Question question;

    [Header("All questions in this scene")]
    [SerializeField] List<Question> questionList;

    //Queue that is used to move through the questions in chronological order.
    [SerializeField] Queue<Question> questionQueue;

    private void Start()
    {
        Queue<Question> _questionQueue = new Queue<Question>(questionList);
        questionQueue = _questionQueue;

        BindingDataToUI();
    }

    /// <summary>
    /// This method sets the data for the ui elements. It fills in the textmeshes based on the scriptable objects.
    /// </summary>
    private void BindingDataToUI()
    {
        TextMeshProUGUI uiQuestion = GameObject.FindGameObjectWithTag("question").GetComponent<TextMeshProUGUI>();
        uiQuestion.text = question.questionString;

        //Index to fill in numbered answer buttons.
        int i = 1;

        foreach (Answer answer in question.answers)
        {
            TextMeshProUGUI uiAnswer = GameObject.FindGameObjectWithTag("answer" + i).GetComponent<TextMeshProUGUI>();

            uiAnswer.text = answer.answerString;
            i++;
        }
    }

    /// <summary>
    /// Will check the answer and go to the next question or dialogue.
    /// </summary>
    public void CheckAnswer(Answer answer)
    {
        if (answer.isCorrect == true)
        {
            CorrectAnswer(answer);
            NextQuestion();
        }
        else
        {
            IncorrectAnswer(answer);
            NextQuestion();
        }
    }

    private void IncorrectAnswer(Answer answer)
    {
        // Correct answer message

        //Based on the answer define next learning steps here.
    }

    private void CorrectAnswer(Answer answer)
    {
        // Correct answer message


    }


    /// <summary>
    /// Sends the user to the next question in the queue.
    /// </summary>
    private void NextQuestion()
    {     
        for (int i = 0; i < questionList.Count; i++)
        {
            if (questionList.Count != 0) {
                var next = questionQueue.Peek();
                Debug.Log(next);
                if (question != next)
                {
                    question = next;
                    BindingDataToUI();
                }
            }

            questionQueue.Dequeue();
        }
    }
}
