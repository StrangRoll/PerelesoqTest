using System;
using Electric_appliances.Energy_sources;
using UnityEngine;

namespace Electric_appliances.Energy_consumers
{
    public abstract class EnergyConsumer : MonoBehaviour
    {
        [SerializeField] private EnergySource energySource;

        protected bool IsSourceWorking = false;

        private void OnEnable()
        {
            energySource.IsWorkingChanged += OnSourceIsWorkingChanged;
            DoWithParentOnEnable();
        }

        private void OnDisable()
        {
            energySource.IsWorkingChanged -= OnSourceIsWorkingChanged;
            DoWithParentOnDisable();
        }

        protected abstract void DoWithParentOnEnable();
        
        protected abstract void DoWithParentOnDisable();
        
        protected abstract void OnSourceIsWorkingChanged();

        private void OnSourceIsWorkingChanged(bool isSourceWorking)
        {
            IsSourceWorking = isSourceWorking;
            OnSourceIsWorkingChanged();
        }
    }
}