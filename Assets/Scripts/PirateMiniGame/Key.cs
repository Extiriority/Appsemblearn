using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PirateMiniGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class Key : MonoBehaviour
{
    [Range(10000f, 99999f)][SerializeField] private int keyLayout;
    private List<KeyTooth> _teeth;

    [SerializeField] private bool test;
    void Start()
    {
        SetVariables();
    }


    private void SetKeyLayout()
    {
        int i = 0;
        int j = 0;
        foreach (KeyTooth t in _teeth)
        {
            t.SetToothValue(keyLayout.ToString()[i]);
            t.SetToothIndex(j);
            i++;
            j++;
        }
    }

    private void OnValidate()
    {
        SetVariables();
        SetRandomCode();
        SetKeyLayout();
        test = false;
    }

    private void SetVariables()
    {
        _teeth = GetComponentsInChildren<KeyTooth>().ToList();
        
    }

    private void SetRandomCode()
    {
        keyLayout = Random.Range(10000, 99999);
    }
}
