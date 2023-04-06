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
        }

        private void OnDisable()
        {
            energySource.IsWorkingChanged -= OnSourceIsWorkingChanged;
        }
        
        protected abstract void OnSourceIsWorkingChanged();

        private void OnSourceIsWorkingChanged(bool isSourceWorking)
        {
            IsSourceWorking = isSourceWorking;
            OnSourceIsWorkingChanged();
        }
    }
}