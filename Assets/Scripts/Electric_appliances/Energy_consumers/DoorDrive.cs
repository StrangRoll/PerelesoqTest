using System.Collections;
using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class DoorDrive : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private float animateTime;
        [SerializeField] private float openAngle ;
        [SerializeField] private Transform door;

        private Quaternion _closedRotation;
        private Quaternion _openRotation;
        private bool _isOpen;
        private Coroutine _doorOpeningAnimation = null;
        private float _speed;

        public bool IsWorking => IsSourceWorking && (_doorOpeningAnimation != null);

        private void Awake()
        {
            _closedRotation = door.localRotation;
            _openRotation = Quaternion.Euler(0, openAngle, 0) * _closedRotation;
            _speed = openAngle / animateTime;
        }
        
        protected override void OnSourceIsWorkingChanged()
        {
            if (_doorOpeningAnimation == null)
                return;
            
            if (IsSourceWorking)
            {
                var endRotation = _isOpen ? _closedRotation : _openRotation;
                var isOpening = !_isOpen;

                _doorOpeningAnimation = StartCoroutine(AnimateDoor(
                    door.localRotation, endRotation, isOpening));
            }
            else
            {
                StopCoroutine(_doorOpeningAnimation);
            }
        }

        private IEnumerator AnimateDoor(Quaternion startRotation, Quaternion endRotation, bool isOpening)
        {
            while (door.localRotation != endRotation)
            {
                transform.localRotation = Quaternion.Slerp(startRotation, endRotation, _speed);
                yield return null;
            }
            
            _isOpen = isOpening;
            _doorOpeningAnimation = null;
        }
    }
}