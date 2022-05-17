using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Answer : ScriptableObject
{
    [SerializeField] string answerString;
    [SerializeField] bool isCorrect;
}
