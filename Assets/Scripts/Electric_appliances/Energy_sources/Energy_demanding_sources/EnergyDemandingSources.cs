using System;
using UnityEngine;

namespace Electric_appliances.Energy_sources.Energy_demanding_sources
{
    public abstract class EnergyDemandingSources : EnergySource
    {
        [SerializeField] private EnergySource energySource;

        protected bool IsSourceWorking { get; private set; } = false;
        
        private void OnEnable()
        {
            energySource.IsWorkingChanged += OnSourceIsWorkingChanged;
            DoWithParentOnEnable();
        }

        private void OnDisable()
        { 
            energySource.IsWorkingChanged += OnSourceIsWorkingChanged;
            DoWithParentOnDisable();
        }

        protected abstract void DoWithParentOnEnable();

        protected abstract void DoWithParentOnDisable();

        protected abstract void SourceIsWorkingChanged();

        private void OnSourceIsWorkingChanged(bool sourceIsWorking)
        {
            IsSourceWorking = sourceIsWorking;
            SourceIsWorkingChanged();
        }
    }
}