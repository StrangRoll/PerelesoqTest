using Electric_appliances.Interfaces;
using ScriptableObjects.TMP_TextLinker;
using TMPro;
using UnityEngine;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources.Gate
{
    public class EnegryGate : EnergyDemandingSources, IElectricAppliances
    {
        [SerializeField] private EnergySource secondEnergySource;
        [SerializeField] private GateFormulas formula;
        [SerializeField] private TMP_TextLinker textLinker;
        
        private bool _isSecondSourceWorking = false;
        private TMP_Text _gateStateText = null;
        
        public bool IsWorking => CheckFormula();
        private string _workingText = "opened";
        private string _notWorkingText = "closed";

        protected override void DoWithParentOnEnable()
        {
            secondEnergySource.IsWorkingChanged += OnSecondSourceIsWorkingChanged;
        }

        private void Start()
        {
            if (_gateStateText == null)
                _gateStateText = textLinker.TextField;
        }

        protected override void DoWithParentOnDisable()
        {
            secondEnergySource.IsWorkingChanged += OnSecondSourceIsWorkingChanged;
        }

        protected override void SourceIsWorkingChanged()
        {
            CheckIsWorkingChanges();
        }

        private void OnSecondSourceIsWorkingChanged(bool newIsWorking)
        {
            _isSecondSourceWorking = newIsWorking;
            CheckIsWorkingChanges();
        }

        private void CheckIsWorkingChanges()
        {
            OnIsWorkingChanged(IsWorking);
            _gateStateText.text = IsWorking ? _workingText : _notWorkingText;
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