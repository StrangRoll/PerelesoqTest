using Electric_appliances.Interfaces;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources
{
    public class EnergyConductor : EnergyDemandingSources, IElectricAppliances
    {
        public bool IsWorking => IsSourceWorking;

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
            OnIsWorkingChanged(IsWorking);
        }
    }
}