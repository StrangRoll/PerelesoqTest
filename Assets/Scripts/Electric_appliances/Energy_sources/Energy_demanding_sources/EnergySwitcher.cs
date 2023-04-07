using Electric_appliances.Interfaces;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources
{
    public class EnergySwitcher : EnergyDemandingSources, IElectricAppliances
    {
        private bool _isOn = false;

        public bool IsWorking => IsSourceWorking & _isOn;
        
        protected override void DoWithParentOnEnable()
        {
            return;
        }

        protected override void DoWithParentOnDisable()
        {
            return;
        }

        protected override void SourceIsWorkingChanged()
        {
            if (_isOn)
                OnIsWorkingChanged(IsWorking);
        }
    }
}