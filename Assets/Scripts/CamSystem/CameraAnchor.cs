using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace CamSystem
{
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
        
        [Header("Events")]
        [Tooltip("This event triggers when the camera blend is finished")]
        public UnityEvent onCameraTransitionEnded;
        
        [HideInInspector]
        public bool isActive;

        //private vars
        private CinemachineVirtualCamera _vCam;
        private CameraAnchorManager _anchorManager;
        private Outline _outline;
        private CameraPanner _panner;
        private CinemachineBrain _brain;

        //Event Functions
        void Start()
        {
            LoadComponents();
        }

        private void OnMouseUp()
        {
            ToggleVCam();
            InvokeEvents();
            _anchorManager.SetCurrentAnchor(this);
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
            _vCam = GetComponentInChildren<CinemachineVirtualCamera>();
            _anchorManager = GetComponentInParent<CameraAnchorManager>();
            _panner = GetComponentInChildren<CameraPanner>();
            _outline = null; 
            _brain = CinemachineCore.Instance.FindPotentialTargetBrain(_vCam);

            //adds an outline to the first childObject
            if (transform.childCount >= 1)
            {
                _outline = transform.GetComponentInChildren<MeshRenderer>().gameObject.AddComponent<Outline>();
                //_outline = transform.GetChild(0).GetChild(0).AddComponent<Outline>();
                _outline.OutlineColor = defaultOutlineColor;
                _outline.OutlineWidth = defaultOutlineWidth;
                _outline.OutlineMode = outlineMode;
            }
            
            _vCam.enabled = false;
            _panner.enabled = false;
        }

        public void ToggleVCam(float delay = 0f)
        {
            StartCoroutine(ToggleVCamDelayed(delay));
        }

        private void SetOutlineColor(Color color)
        {
            _outline.OutlineColor = color;
        }

        private void SetOutlineWidth(float width)
        {
            _outline.OutlineWidth = width;
        }

        private void InvokeEvents()
        {
            Invoke(nameof(DelayedInvoke), _brain.m_DefaultBlend.m_Time);
        }
        
        private void DelayedInvoke()
        {
            onCameraTransitionEnded.Invoke();
        }

        public void DisableAnchor()
        {
            _panner.ResetRotation();
            _vCam.enabled = false;
        }

        IEnumerator ToggleVCamDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            _anchorManager.DisableAllAnchors();
            _vCam.enabled = !_vCam.enabled;
            _panner.enabled = _vCam.enabled;
            isActive = !isActive;
        }
    }
}
