namespace Electric_appliances.Energy_sources
{
    public class MainSource : EnergySource, IElectricAppliances
    {
        public bool IsWorking => true;

        private void Start()
        {
            OnIsWorkingChanged(IsWorking);
        }
    }
}