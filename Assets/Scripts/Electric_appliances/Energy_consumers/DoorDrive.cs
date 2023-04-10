using System.Collections;
using Electric_appliances.Interfaces;
using ScriptableObjects;
using UI;
using UI.ClickReaders;
using UnityEngine;
using UnityEngine.Events;

namespace Electric_appliances.Energy_consumers
{
    public class DoorDrive : EnergyConsumer, IElectricAppliances, ICurrentConsumer
    {
        [SerializeField] private float animateTime;
        [SerializeField] private float openAngle ;
        [SerializeField] private Transform door;
        [SerializeField] private ButtonClickReader _buttonClickReader;
        [SerializeField] private float _currentConsumerPerAction;
        [SerializeField] private ButtonLinker _buttonLink;

        private Quaternion _closedRotation;
        private Quaternion _openRotation;
        private bool _isOpen;
        private Coroutine _doorOpeningAnimation = null;
        private float _elapsedTime = 0;
        
        private float _speed;
        
        public bool IsWorking => IsSourceWorking && (_doorOpeningAnimation == null);
        public float CurrentConsumer => _currentConsumerPerAction;
        
        public event UnityAction<float> ConsumeCurrent;

        private void Awake()
        {
            _speed = (openAngle / animateTime);
            
            _closedRotation = door.localRotation;
            _openRotation = Quaternion.Euler(0, openAngle, 0) * _closedRotation;
            _speed = openAngle / animateTime;
        }

        private void Start()
        {
            _buttonClickReader = _buttonLink.Button;
            _buttonClickReader.ButtonClicked += OnButtonClick;
        }

        protected override void DoWithParentOnEnable()
        {
            if (_buttonLink.Button != null)
                _buttonClickReader.ButtonClicked += OnButtonClick;
        }

        protected override void DoWithParentOnDisable()
        {
            _buttonClickReader.ButtonClicked -= OnButtonClick;
        }

        protected override void OnSourceIsWorkingChanged()
        {
            if (_doorOpeningAnimation == null)
                return;
            
            if (IsSourceWorking)
            {
                StartAnimation();
            }
            else
            {
                StopCoroutine(_doorOpeningAnimation);
            }
        }

        private void OnButtonClick()
        {
            if (IsWorking == false)
                return;
            
            ConsumeCurrent?.Invoke(CurrentConsumer);
            StartAnimation();
        }

        private void StartAnimation()
        {
            var endRotation = _isOpen ? _closedRotation : _openRotation;
            var isOpening = !_isOpen;

            _doorOpeningAnimation = StartCoroutine(AnimateDoor(
                door.localRotation, endRotation, isOpening));
        }

        private IEnumerator AnimateDoor(Quaternion startRotation, Quaternion endRotation, bool isOpening)
        {
            while (door.localRotation != endRotation)
            {
                _elapsedTime += Time.deltaTime;
                door.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, _elapsedTime / animateTime);
                yield return null;
            }

            _elapsedTime = 0;
            _isOpen = isOpening;
            _doorOpeningAnimation = null;
        }
    }
}