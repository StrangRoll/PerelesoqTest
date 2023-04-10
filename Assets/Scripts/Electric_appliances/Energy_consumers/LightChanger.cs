using Electric_appliances.Interfaces;
using ScriptableObjects.LightLinkers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Electric_appliances.Energy_consumers
{
    public class LightChanger : EnergyConsumer, IElectricAppliances, ICurrentConsumer
    {
        [SerializeField] private Light[] lights;
        [SerializeField] private LightsLinker lightsLinker;
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

        private void Start()
        {
            if (lightsLinker != null)
                lights = lightsLinker.Lights;
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