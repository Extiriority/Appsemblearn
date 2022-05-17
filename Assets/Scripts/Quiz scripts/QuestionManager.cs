using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    //Current question and answers.
    [SerializeField] Question question;
    [SerializeField] List<Answer> answers;

    // UI elements
    List<GameObject> uiAnswers; 

    private void Start()
    {  
        //Ensures that the correct answers are displayed and are matched to the current question.
        foreach (Answer answer in question.answers)
        {
            answers.Add(answer);
        } 
        
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

        foreach (Answer answer in answers)
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
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("Incorrect");
        }
    }
}
