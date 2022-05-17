using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    
    [SerializeField] Question question;
    [SerializeField] List<Answer> answers;

    // UI elements
    List<GameObject> uiAnswers; 

    private void Start()
    {
        TextMeshProUGUI uiQuestion = GameObject.FindGameObjectWithTag("question").GetComponent<TextMeshProUGUI>();
        uiQuestion.text = question.questionString;

        foreach (Answer answer in question.answers)
        {
            answers.Add(answer);
        }
    }
}
