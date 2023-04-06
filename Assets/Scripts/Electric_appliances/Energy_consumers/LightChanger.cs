namespace Electric_appliances.Energy_consumers
{
    public class LightChanger : EnergyConsumer, IElectricAppliances
    {
        public bool IsWorking => IsSourceWorking;
        
        protected override void OnSourceIsWorkingChanged()
        {
            //activate/deactivate light
        }
    }
}