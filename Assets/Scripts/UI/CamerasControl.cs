using System;
using Electric_appliances.Energy_consumers;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CamerasControl : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader firstCameraPlace;
        [SerializeField] private ButtonClickReader secondCameraPlace;
        [SerializeField] private ConnectableСamera[] _connectableСameras;

        private void OnEnable()
        {
            firstCameraPlace.ButtonClicked += OnFirstCameraClicked;
            secondCameraPlace.ButtonClicked += OnSecondCameraClicked;
        }

        private void OnDisable()
        {
            firstCameraPlace.ButtonClicked -= OnFirstCameraClicked;
            secondCameraPlace.ButtonClicked -= OnSecondCameraClicked;
        }

        private void OnFirstCameraClicked()
        {
            var cameraIndex = 0;
            ActivateOneCamera(cameraIndex);
        }

        private void OnSecondCameraClicked()
        {
            var cameraIndex = 1;
            ActivateOneCamera(cameraIndex);
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