using System;
using ScriptableObjects.CameraChangerView;
using TMPro;
using UI.ClickReaders;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CameraChangerView : MonoBehaviour
    {
        [SerializeField] private ButtonClickReader _buttonClickReader;
        [SerializeField] private int cameraCount; 
        [SerializeField] private TMP_Text cameraNumberText; 
        [SerializeField] private CameraChangerViewLinker linker; 

        private int _currentCameraIndex = 0;

        public event UnityAction<int> CameraChanged;

        private void Awake()
        {
            linker.CameraChangerView = this;
        }

        private void OnEnable()
        {
            _buttonClickReader.ButtonClicked += OnButtonClick;
        }

        private void OnDisable()
        {
            _buttonClickReader.ButtonClicked -= OnButtonClick;
        }

        private void OnButtonClick()
        {
            _currentCameraIndex++;

            if (_currentCameraIndex >= cameraCount)
                _currentCameraIndex = 0;
            
            CameraChanged?.Invoke(_currentCameraIndex);
            cameraNumberText.text = $"Camera {_currentCameraIndex + 1}";
        }
    }
}