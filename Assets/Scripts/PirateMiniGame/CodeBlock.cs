using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PirateMiniGame
{
    public class CodeBlock : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        private TextMeshProUGUI _textMeshPro;
        public string text = "Test";
        public string value = "";
        private AudioSource _audio;
        [SerializeField] private AudioClip PickUpSound;
        [SerializeField] private AudioClip DropSound;
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            _audio = GetComponent<AudioSource>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _audio.clip = PickUpSound;
            _audio.Play();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _audio.clip = DropSound;
            _audio.Play();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        private void OnValidate()
        {
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
            SetText();
        }

        private void SetText()
        {
            _textMeshPro.text = text;
        }

        public string GetText()
        {
            return _textMeshPro.text;
        }

        public string GetValue()
        {
            return value;
        }
    }
}
