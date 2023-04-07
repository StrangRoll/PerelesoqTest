using Electric_appliances.Interfaces;
using UI;
using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class ConnectableСamera : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private Camera camera;

        public bool IsWorking => IsSourceWorking && _isCameraActivate;

        private bool _isCameraActivate = false;

        public void ActivateCamera()
        {
            _isCameraActivate = true;
            ChangeCameraEnabled();
        }

        public void DeactivateCamera()
        {
            _isCameraActivate = false;
            ChangeCameraEnabled();
        }

        protected override void OnSourceIsWorkingChanged()
        {
            camera.enabled = IsWorking;
            ChangeCameraEnabled();
        }

        protected override void DoWithParentOnEnable()
        {
            return;
        }

        protected override void DoWithParentOnDisable()
        {
            return;
        }

        private void ChangeCameraEnabled()
        {
            camera.gameObject.SetActive(IsWorking);
            camera.enabled = IsWorking;
        }
    }
}