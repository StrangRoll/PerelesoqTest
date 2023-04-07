using System;
using Electric_appliances.Energy_consumers;
using ScriptableObjects.CameraChangerView;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CamerasControl : MonoBehaviour
    {
        [SerializeField] private CameraChangerViewLinker _linker;
        [SerializeField] private ConnectableСamera[] _connectableСameras;
        
        private CameraChangerView _cameraChangerView;

        private void OnEnable()
        {
            if (_linker.CameraChangerView != null)
                _cameraChangerView.CameraChanged += OnCameraChanged;
            
            ActivateOneCamera(0);
        }

        private void Start()
        {
            _cameraChangerView = _linker.CameraChangerView;
            _cameraChangerView.CameraChanged += OnCameraChanged;
        }

        private void OnDisable()
        {
            _cameraChangerView.CameraChanged += OnCameraChanged;
        }

        private void OnCameraChanged(int index)
        {
            ActivateOneCamera(index);
        }
        
        private void ActivateOneCamera(int index)
        {
            for (var i = 0; i < _connectableСameras.Length; i++)
            {
                if (i == index)
                {
                    _connectableСameras[i].ActivateCamera();
                }
                else
                {
                    _connectableСameras[i].DeactivateCamera();
                }
            }
        }
    }
}