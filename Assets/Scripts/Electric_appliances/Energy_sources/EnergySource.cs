using UnityEngine;
using UnityEngine.Events;

namespace Electric_appliances.Energy_sources
{
    public abstract class EnergySource : MonoBehaviour
    {
        public event UnityAction<bool> IsWorkingChanged;

        protected void OnIsWorkingChanged(bool newIsWorking)
        {
            IsWorkingChanged?.Invoke(newIsWorking);
        }
    }
}