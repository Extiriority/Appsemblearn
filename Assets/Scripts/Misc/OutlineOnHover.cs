using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutlineOnHover : MonoBehaviour
{
    [Header("Outline Settings")]
    
    [Tooltip("The default width of the outline of the model")]
    [Range(0f,10f)]public float defaultOutlineWidth = 1f;
    
    [Tooltip("The width of the outline of the model when hovered over with the cursor")]
    [Range(0f,10f)]public float onHoverOutlineWidth = 1f;
    
    [Tooltip("The default color of the outline")]
    public Color defaultOutlineColor = Color.red;
    
    [Tooltip("The color of the outline when hovered over with the cursor")] 
    public Color onHoverOutlineColor = Color.green;
    
    [Tooltip("Outline mode")] 
    public Outline.Mode outlineMode = Outline.Mode.OutlineAll;
    
    private Outline _outline;

    private void Start()
    {
        _outline = transform.AddComponent<Outline>();
        _outline.OutlineColor = defaultOutlineColor;
        _outline.OutlineWidth = defaultOutlineWidth;
        _outline.OutlineMode = outlineMode;
    }
    
    private void OnMouseEnter()
    {
        SetOutlineColor(onHoverOutlineColor);
        SetOutlineWidth(onHoverOutlineWidth);
    }

    private void OnMouseExit()
    {
        SetOutlineColor(defaultOutlineColor);
        SetOutlineWidth(defaultOutlineWidth);
    }
    
    private void SetOutlineColor(Color color)
    {
        _outline.OutlineColor = color;
    }

    private void SetOutlineWidth(float width)
    {
        _outline.OutlineWidth = width;
    }
}
