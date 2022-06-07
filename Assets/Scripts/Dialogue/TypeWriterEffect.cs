using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField][Range(5, 25)] private float typeWriterSpeed = 50f;

    public bool isRunning { get; private set; }
    //Punctuation dictionary with float variable to add timer for pauses
    private readonly Dictionary<HashSet<char>, float> punctuations = new() {
        { new HashSet<char> { '.', '!', '?' }, 0.7f },
        { new HashSet<char> { ',', ';', ':' }, 0.4f }
    };

    private Coroutine typingCoroutine;
    public void run(string textToType, TMP_Text textLabel) {
        typingCoroutine = StartCoroutine(typeText(textToType, textLabel));
    }

    public void Stop() {
        StopCoroutine(typingCoroutine);
        isRunning = false;
    }
    //read the max char of a dialoguebox and add the char in steps on every waitTime
    private IEnumerator typeText(string textToType, TMP_Text textLabel) {
        isRunning = true;
        textLabel.text = string.Empty;
        
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length) {
            int lastCharIndex = charIndex;
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);
            
            for (int i = lastCharIndex; i < charIndex; i++) {
                bool isLast = i >= textToType.Length - 1;
                textLabel.text = textToType.Substring(0, i + 1);
                if (isPunctuation(textToType[i], out float waitTime) && !isLast && !isPunctuation(textToType[i + 1], out _)) {
                    yield return new WaitForSeconds(waitTime);
                }
                //If its letter -> play Sans SFX
                if (!textToType[i].Equals(' ') && !textToType[i].Equals(',') && !textToType[i].Equals('.') && !textToType[i].Equals('!') && !textToType[i].Equals('?')) {
                    SoundManager.instance.play("sans");
                }
                //If its punctuation -> play punctuation SFX
                if (textToType[i].Equals('.')) {
                    SoundManager.instance.play("punctuation");
                }
            }
            yield return null;
        }
        isRunning = false;
    }

    //Lambda finding all char in one dialogue box content for possible punctuations
    private bool isPunctuation(char character, out float waitTime) {
        foreach (var punctuationCategory in punctuations.Where(punctuationCategory => punctuationCategory.Key.Contains(character))) {
            waitTime = punctuationCategory.Value;
            return true;
        }
        waitTime = default;
        return false;
    }
}
