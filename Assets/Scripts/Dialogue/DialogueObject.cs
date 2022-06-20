using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    [SerializeField] private Question[] questions;

    [SerializeField]
    public Question question;

    public string[] Dialogue
    {
        get => dialogue;
        set => dialogue = value;
    }

    public bool HasAnswers => Questions != null && Questions.Length > 0;
    public Question[] Questions => questions;    
}
