using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuestionManager : MonoBehaviour
{
    //Current question and answers.
    [SerializeField] Question question;
    [SerializeField] List<Question> questionList;
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
            AnswerResponse(answer);
            NextQuestion();
        }
        else
        {
            AnswerResponse(answer);
            NextQuestion();
        }
    }

    private void AnswerResponse(Answer answer)
    {
        // Gives a response based on whether the answer was correct of incorrect

        //Based on the answer define next learning steps here.
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
