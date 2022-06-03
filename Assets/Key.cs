using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PirateMiniGame;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private int keyLayout = 11111;
    private List<KeyTooth> _teeth;
    void Start()
    {
        SetVariables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetKeyLayout()
    {
        int i = 0;
        foreach (KeyTooth t in _teeth)
        {
            t.SetKeyValue(keyLayout.ToString()[i]);
            print(keyLayout.ToString()[i]);
            i++;
        }
    }

    private void OnValidate()
    {
        SetVariables();
        SetKeyLayout();
    }

    private void SetVariables()
    {
        _teeth = GetComponentsInChildren<KeyTooth>().ToList();
    }
}
