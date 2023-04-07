using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class LightChanger : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private Light[] lights;
        
        public bool IsWorking => IsSourceWorking;
        
        protected override void OnSourceIsWorkingChanged()
        {
            foreach (var light in lights)
            {
                light.enabled = IsWorking;
            }
        }
    }
}