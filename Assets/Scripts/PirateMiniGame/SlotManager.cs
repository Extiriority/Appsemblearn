using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PirateMiniGame
{
    public class SlotManager : MonoBehaviour
    {
        [ItemCanBeNull] private CodeBlockSlot[] _slots;
        [ItemCanBeNull] public string[] _slotValues;
        public int AmountOfSlots = 4;
        private Canvas _canvas;
        [SerializeField] private GameObject _slotPrefab;
        public int slotHeight = 25;
        public bool IsSolved;
        [SerializeField] private TextMeshProUGUI _feedbackText;
        [SerializeField] private Animator _keyAnimator;
        [SerializeField] private Animator _chestAnimator;
        private AudioSource _audio;
        [SerializeField] private Canvas mainCanvas; 
        private void Start()
        {
            _slots = new CodeBlockSlot[AmountOfSlots];
            _slotValues = new string[AmountOfSlots];
            _canvas = GetComponentInParent<Canvas>();
            _audio = GetComponent<AudioSource>();
            StartCoroutine(SetFeedbackText("",0f));
        }

        private void FixedUpdate()
        {
            IsSolved = GetSolved();
        }
        

        private void PlaceSlots()
        {
            int _totalSlotHeight = 550;
            int topScreenPadding = 50;
            
            for (int i = 0; i < AmountOfSlots; i++)
            {
                GameObject slotGo = Instantiate(_slotPrefab, transform, false);
                slotGo.transform.SetParent(transform);
                RectTransform slotRect = slotGo.GetComponent<RectTransform>();
                slotRect.anchoredPosition = new Vector2(-750, -slotHeight * i + .4f*_canvas.GetComponent<RectTransform>().rect.height);
                slotGo.GetComponent<CodeBlockSlot>().slotIndex = i;
            }
        }

        private void RemoveSlots()
        {
            foreach (Transform child in transform)
            {
                StartCoroutine(Destroy(child.gameObject));
            }
        }

        private void OnValidate()
        {
            //if (AmountOfSlots == 0) return;
            
            //SetVars();
            //RemoveSlots();
            //PlaceSlots();
        }

        private void SetVars()
        {
            _slots = GetComponentsInChildren<CodeBlockSlot>();
            _canvas = GetComponentInParent<Canvas>();
        }
        
        IEnumerator Destroy(GameObject go)
        {
            yield return null;
            DestroyImmediate(go);
        }

        public void SetSlotContent(int slotIndex, CodeBlock content)
        {
            _slotValues[slotIndex] = content.GetValue();
        }

        private string GetContentString()
        {
            string s = "";
            for (int i = 0; i < AmountOfSlots; i++)
            {
                s += _slotValues[i];
            }

            return s;
        }

        public bool GetSolved()
        {
            return GetContentString() == "0123456789";
        }

        public void TryKey()
        {
            PlayAnimations();
            bool solved = GetSolved();
            string text = solved ? "Congratulations" : "Try again...";
            Invoke(nameof(PlayOpeningSound), 1.5f);
            StartCoroutine(SetFeedbackText(text, 2f));
            StartCoroutine(SetFeedbackText("", 4f));
            Invoke(nameof(ResetAnimations),4f);

            if (solved)
            {
               Invoke(nameof(ToMainCanvas), 4f);
            }
        }

        private IEnumerator SetFeedbackText(string text, float delay)
        {
            yield return new WaitForSeconds(delay);
            _feedbackText.text = text;
        }

        private void PlayAnimations()
        {
            _keyAnimator.SetBool("UseKey",true);
            _chestAnimator.SetBool("TurnChest", true);
        }
        private void ResetAnimations()
        {
            _keyAnimator.SetBool("UseKey",false);
            _chestAnimator.SetBool("TurnChest", false);
        }

        private void PlayOpeningSound()
        {
            _audio.Play();
        }

        private void ToMainCanvas()
        {
            mainCanvas.gameObject.SetActive(true);
        }
    }
}
