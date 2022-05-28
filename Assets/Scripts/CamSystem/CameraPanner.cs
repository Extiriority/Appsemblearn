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
        private Vector3 _startingRotation;
        
        void Start()
        {
            _anchor = GetComponent<CameraAnchor>();
            _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            _startingRotation = transform.localEulerAngles;
            print(_startingRotation);
        }
        
        private void FixedUpdate()
        {
            Vector3 newRotation = (Vector3) GetMouseToScreenPosition() + _startingRotation;
            transform.SetPositionAndRotation(transform.position,Quaternion.Euler(newRotation)); ;
        }
        
        Vector2 GetMouseToScreenPosition()
        {
            //Axis are inverted dont know why 
            Vector3 mousePos = Input.mousePosition;
            return new Vector2(-mousePos.y / _cam.pixelHeight, mousePos.x / _cam.pixelWidth) * mouseCursorMultiplier;
        }

        public void ResetRotation()
        {
            transform.rotation = Quaternion.Euler(_startingRotation);
        }
    }
}
