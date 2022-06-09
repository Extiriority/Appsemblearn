using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Shield : ScriptableObject
{
    [SerializeField] public Mesh shieldType;
    [SerializeField] public Color color;
    [SerializeField] public GameObject icon;
}
