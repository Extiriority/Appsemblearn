using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [Header("Fill in the question here")]
    public string questionString;

    [Header("Add answers to the question here")]
    public List<Answer> answers;

}
