using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

namespace CamSystem
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    [RequireComponent(typeof(CameraPanner))]
    public class CameraAnchor : MonoBehaviour
    {
        //Public vars
        [Header("Outline Settings")] 
        
        [Tooltip("The default width of the outline of the model")]
        [Range(0f,10f)]
        public float defaultOutlineWidth = 1f;

        [Tooltip("The width of the outline of the model when hovered over with the cursor")]
        [Range(0f,10f)]
        public float onHoverOutlineWidth = 1f;
        
        [Tooltip("The default color of the outline")] 
        public Color defaultOutlineColor = Color.red;

        [Tooltip("The color of the outline when hovered over with the cursor")]
        public Color onHoverOutlineColor = Color.green;

        [Tooltip("Outline mode")] 
        public Outline.Mode outlineMode = Outline.Mode.OutlineAll;
        

        public bool isActive;

        //private vars
        private CinemachineVirtualCamera _vCam;
        private CameraAnchorManager _anchorManager;
        private Outline _outline;
        private CameraPanner _panner;

        //Event Functions
        void Start()
        {
            LoadComponents();
        }

        private void OnMouseUp()
        {
            ToggleVCam();
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

        
        //Helper Functions
        private void LoadComponents()
        {
            _vCam = GetComponent<CinemachineVirtualCamera>();
            _anchorManager = GetComponentInParent<CameraAnchorManager>();
            _panner = GetComponent<CameraPanner>();
            _outline = null;
            
            //adds an outline to the first childObject
            if (transform.childCount >= 1)
            {
                _outline = transform.GetChild(0).AddComponent<Outline>();
                _outline.OutlineColor = defaultOutlineColor;
                _outline.OutlineWidth = defaultOutlineWidth;
                _outline.OutlineMode = outlineMode;
            }
            
            _vCam.enabled = false;
            _panner.enabled = false;
        }

        private void ToggleVCam()
        {
            _anchorManager.DisableAllAnchors();
            _vCam.enabled = !_vCam.enabled;
            _panner.enabled = _vCam.enabled;
            isActive = !isActive;
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
}
