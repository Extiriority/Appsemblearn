using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

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
        

        private void Start()
        {
            _slots = new CodeBlockSlot[AmountOfSlots];
            _slotValues = new string[AmountOfSlots];
            _canvas = GetComponentInParent<Canvas>();
        }

        private void FixedUpdate()
        {
            //ReadSlotContent();
            IsSolved = GetSolved();
        }

        private void ReadSlotContent()
        {
            for (int i = 0; i < AmountOfSlots; i++)
            {
                print(_slots);
                //SetSlotContent(i, _slots[i].codeBlockInSlot);
            }
        }

        private void PlaceSlots()
        {
            int _totalSlotHeight = 550;
            int topScreenPadding = 50;
            
            
            for (int i = 0; i < AmountOfSlots; i++)
            {
                GameObject slotGO = Instantiate(_slotPrefab, transform, false);
                slotGO.transform.SetParent(transform);
                RectTransform slotRect = slotGO.GetComponent<RectTransform>();
                slotRect.anchoredPosition = new Vector2(-750, -slotHeight * i + .4f*_canvas.GetComponent<RectTransform>().rect.height);
                slotGO.GetComponent<CodeBlockSlot>().slotIndex = i;
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
            if (AmountOfSlots == 0) return;
            
            SetVars();
            RemoveSlots();
            PlaceSlots();
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
    }
}
