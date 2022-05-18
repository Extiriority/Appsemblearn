using UnityEngine;

namespace CamSystem
{
    public class CameraPanner : MonoBehaviour
    {
        [Header("Camera Settings")]
        [Tooltip("The amount of 'impact' the mouse cursor has on the view")]
        [Range(0f, 21f)]
        public float mouseCursorMultiplier = 4f;

        private Camera _cam;
        private CameraAnchor _anchor;
        private Vector3 _originalRotation;
        
        void Start()
        {
            _anchor = GetComponent<CameraAnchor>();
            _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            _originalRotation = transform.eulerAngles;
        }
        
        private void FixedUpdate()
        {
            Vector3 newRotation = (Vector3) GetMouseToScreenPosition() + _originalRotation;
            transform.rotation = Quaternion.Euler(newRotation);
        }
        
        Vector2 GetMouseToScreenPosition()
        {
            //Axis are inverted dont know why 
            Vector3 mousePos = Input.mousePosition;
            return new Vector2(-mousePos.y / _cam.pixelHeight, mousePos.x / _cam.pixelWidth ) * mouseCursorMultiplier;
        }
    }
}
