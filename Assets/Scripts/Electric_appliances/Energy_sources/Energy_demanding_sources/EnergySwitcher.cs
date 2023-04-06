namespace Electric_appliances.Energy_sources.Energy_demanding_sources
{
    public class EnergySwitcher : EnergyDemandingSources, IElectricAppliances
    {
        private bool _isOn = false;

        public bool IsWorking => IsSourceWorking & _isOn;
        
        protected override void DoWithParentOnEnable()
        {
            throw new System.NotImplementedException();
        }

        protected override void DoWithParentOnDisable()
        {
            throw new System.NotImplementedException();
        }

        protected override void SourceIsWorkingChanged()
        {
            if (_isOn)
                OnIsWorkingChanged(IsWorking);
        }
    }
}