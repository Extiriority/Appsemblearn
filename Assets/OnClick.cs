using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject UI;
    public void OnPointerDown(PointerEventData eventData)
    {
        UI.SetActive(false);
        gameObject.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 11;
    }
}
