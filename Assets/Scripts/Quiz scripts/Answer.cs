using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Answer : ScriptableObject
{
    [Header("Fill in the answer here")]
    public string answerString;
    public bool isCorrect;

}
