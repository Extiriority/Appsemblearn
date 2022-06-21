using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject leftUI;
    [SerializeField] GameObject rightUI;


    public void OnPointerDown(PointerEventData eventData)
    {

        leftUI.SetActive(false);
        rightUI.SetActive(false);
        gameObject.GetComponentInChildren<CinemachineVirtualCamera>().Priority = 11;
    }
}
