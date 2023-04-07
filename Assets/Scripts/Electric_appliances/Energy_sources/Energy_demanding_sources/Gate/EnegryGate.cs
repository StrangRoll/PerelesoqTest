using Electric_appliances.Interfaces;
using UnityEngine;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources.Gate
{
    public class EnegryGate : EnergyDemandingSources, IElectricAppliances
    {
        [SerializeField] private EnergySource secondEnergySource;
        [SerializeField] private GateFormulas formula;
        
        private bool _isSecondSourceWorking = false;
        
        public bool IsWorking => CheckFormula();

        protected override void DoWithParentOnEnable()
        {
            secondEnergySource.IsWorkingChanged += OnSecondSourceIsWorkingChanged;
        }

        protected override void DoWithParentOnDisable()
        {
            secondEnergySource.IsWorkingChanged += OnSecondSourceIsWorkingChanged;
        }

        protected override void SourceIsWorkingChanged()
        {
            OnIsWorkingChanged(IsWorking);
        }

        private void OnSecondSourceIsWorkingChanged(bool newIsWorking)
        {
            _isSecondSourceWorking = newIsWorking;
            OnIsWorkingChanged(IsWorking);
        }

        private bool CheckFormula()
        {
            switch (formula)
            {
                case GateFormulas.And:
                    return IsSourceWorking && _isSecondSourceWorking;
                case GateFormulas.Or:
                    return IsSourceWorking || _isSecondSourceWorking;
                default:
                    Debug.Log("Needed formula is not found");
                    return false;
            }
        }
    }
}