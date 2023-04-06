using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public class DoorDrive : EnergyConsumer, IElectricAppliances
    {
        [SerializeField] private float animateTime;

        private bool _isOpen;
        
        public bool IsWorking => IsSourceWorking; //add second сondition (if door is not opening now)
        
        protected override void OnSourceIsWorkingChanged()
        {
            //door animate;
        }
    }
}