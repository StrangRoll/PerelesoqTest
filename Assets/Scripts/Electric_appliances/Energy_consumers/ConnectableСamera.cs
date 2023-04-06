namespace Electric_appliances.Energy_consumers
{
    public class ConnectableСamera : EnergyConsumer, IElectricAppliances
    {
        public bool IsWorking => IsSourceWorking;
        
        protected override void OnSourceIsWorkingChanged()
        {
            //camera changer
        }
    }
}