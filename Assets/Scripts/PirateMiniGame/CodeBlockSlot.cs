using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace PirateMiniGame
{
    public class CodeBlockSlot : MonoBehaviour, IDropHandler
    {
        public int slotIndex;
        [CanBeNull] public CodeBlock codeBlockInSlot;
        private SlotManager _slotManager;

        private void Start()
        {
            _slotManager = GetComponentInParent<SlotManager>();
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) return;
            
            //snaps item to slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            
            codeBlockInSlot = eventData.pointerDrag.gameObject.GetComponent<CodeBlock>();
            _slotManager.SetSlotContent(slotIndex, codeBlockInSlot);
        }
    }
}
