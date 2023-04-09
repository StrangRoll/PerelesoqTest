using Electric_appliances.Interfaces;
using ScriptableObjects.ToggleLinker;
using UI.ClickReaders;
using UnityEngine;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources
{
    public class EnergySwitcher : EnergyDemandingSources, IElectricAppliances
    {
        [SerializeField] private ToggleLinker toggleLinker;
        
        private bool _isOn = false;
        private ToggleClickReader _toggle = null;

        public bool IsWorking => IsSourceWorking & _isOn;

        private void Start()
        {
            if (_toggle != null) return;
            
            _toggle = toggleLinker.Toggle;
            _toggle.ToggleValueChanged += OnToggleValueChanged;
        }
        
        protected override void DoWithParentOnEnable()
        {
            if (_toggle != null)
                _toggle.ToggleValueChanged += OnToggleValueChanged;
        }

        protected override void DoWithParentOnDisable()
        {
            _toggle.ToggleValueChanged -= OnToggleValueChanged;
        }

        protected override void SourceIsWorkingChanged()
        {
            OnIsWorkingChanged(IsWorking);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            _isOn = isOn;
            OnIsWorkingChanged(IsWorking);
        }
    }
}