using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShieldSO : ScriptableObject
{
    [SerializeField] public GameObject shieldType;
    [SerializeField] public Color color;
    [SerializeField] public GameObject icon;
}
