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
        void Start()
        {
            _cameraAnchors = GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
            _cameraPanners = GetComponentsInChildren<CameraPanner>().ToList();
            DisableAllAnchors();
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
    }
}
