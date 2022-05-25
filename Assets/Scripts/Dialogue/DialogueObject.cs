using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [Header("Outline Settings")] 

    [SerializeField] [TextArea] private string[] dialogue;
    public string[] Dialogue => dialogue;
}
