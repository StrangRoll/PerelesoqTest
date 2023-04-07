using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class ConnectableСamera : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private Camera camera;
        
        public bool IsWorking => IsSourceWorking;
        
        protected override void OnSourceIsWorkingChanged()
        {
            camera.enabled = IsWorking;
        }
    }
}