using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

namespace CamSystem
{
    public class CameraAnchorManager : MonoBehaviour
    {
        private List<CinemachineVirtualCamera> _cameraAnchors;
        private List<CameraPanner> _cameraPanners;
        public List<CameraAnchor> anchorPath;
        [SerializeField] KeyCode backButton;
        void Start()
        {
            _cameraAnchors = GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
            _cameraPanners = GetComponentsInChildren<CameraPanner>().ToList();
            DisableAllAnchors();
            ActivateFirstAnchor();
        }

        private void Update()
        {
            if (Input.GetKeyDown(backButton))
            {
                ActivatePreviousAnchor();
            }
        }

        public void DisableAllAnchors()
        {
            foreach (CinemachineVirtualCamera cam in _cameraAnchors)
            {
                cam.enabled = false;
            }

            foreach (CameraPanner panner in _cameraPanners)
            {
                panner.enabled = false;
            }
        }

        public void SetCurrentAnchor(CameraAnchor anchor)
        {
            anchorPath.Add(anchor);
        }

        public void ActivatePreviousAnchor()
        {
            DisableAllAnchors();
            if (anchorPath.Count <= 1) return;
            anchorPath.RemoveAt(anchorPath.Count-1);
            anchorPath[^1].ToggleVCam();
        }

        public void ActivateAnchor(int anchorIndex)
        {
            DisableAllAnchors();
            _cameraAnchors[anchorIndex].enabled = true;
            _cameraPanners[anchorIndex].enabled = true;
        }

        private void ActivateFirstAnchor()
        {
            ActivateAnchor(0);
        }
    }
}
