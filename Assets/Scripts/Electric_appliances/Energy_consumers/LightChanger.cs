using Electric_appliances.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Electric_appliances.Energy_consumers
{
    public class LightChanger : EnergyConsumer, IElectricAppliances, ICurrentConsumer
    {
        [SerializeField] private Light[] lights;
        [SerializeField] private float _currentConsumerPerHour;

        private float _secondsInHour = 3600;
        
        public bool IsWorking => IsSourceWorking;
        public float CurrentConsumer => (_currentConsumerPerHour / _secondsInHour) 
                                        * Time.deltaTime;

        public event UnityAction<float> ConsumeCurrent;

        protected override void DoWithParentOnEnable()
        {
            return;
        }

        protected override void DoWithParentOnDisable()
        {
            return;
        }

        private void Update()
        {
            if (IsWorking)
                ConsumeCurrent?.Invoke(CurrentConsumer);
        }


        protected override void OnSourceIsWorkingChanged()
        {
            foreach (var light in lights)
            {
                light.enabled = IsWorking;
            }
        }
    }
}