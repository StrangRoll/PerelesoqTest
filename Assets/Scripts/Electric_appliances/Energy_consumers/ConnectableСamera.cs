using Electric_appliances.Interfaces;
using UI;
using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class ConnectableСamera : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private Camera camera;
        
        public bool IsWorking => IsSourceWorking;

        public void ActivateCamera()
        {
            camera.enabled = true;
        }

        public void DeactivateCamera()
        {
            camera.enabled = false;
        }

        protected override void DoWithParentOnEnable()
        {
            return;
        }

        protected override void DoWithParentOnDisable()
        {
            return;
        }

        protected override void OnSourceIsWorkingChanged()
        {
            camera.enabled = IsWorking;
        }
    }
}