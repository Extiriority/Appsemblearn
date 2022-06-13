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
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
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
