using System.Collections;
using AYellowpaper;
using Electric_appliances.Interfaces;
using TMPro;
using UnityEngine;

namespace Electric_appliances
{
    public class CurrentСonsumptionСounter : MonoBehaviour
    {
        [RequireInterface(typeof(ICurrentConsumer))]
        [SerializeField] private GameObject[] currentConsumers;
        [SerializeField] private TMP_Text consumeCountText;
        [SerializeField] private TMP_Text consumePerSecondCountText;

        private float _consumeCount = 0;
        private float _previousConsumeCount = 0;
        private WaitForSeconds _waitOneSecond;

        private void OnEnable()
        {
            foreach (var currentConsumer in currentConsumers)
            {
                if (currentConsumer.TryGetComponent<ICurrentConsumer>(out var consumer))
                    consumer.ConsumeCurrent += OnConsumeCurrent;
            }
        }

        private void Start()
        {
            _waitOneSecond = new WaitForSeconds(1);
            StartCoroutine(CountConsumePerSecond());
        }
        
        private void OnDisable()
        {
            foreach (var currentConsumer in currentConsumers)
            {
                if (currentConsumer.TryGetComponent<ICurrentConsumer>(out var consumer))
                    consumer.ConsumeCurrent += OnConsumeCurrent;
            }
        }

        private void OnConsumeCurrent(float consumeCount)
        {
            _consumeCount += consumeCount;
        }

        private IEnumerator CountConsumePerSecond()
        {
            while (true)
            {
                consumePerSecondCountText.text = $"{_consumeCount - _previousConsumeCount}W";
                consumeCountText.text = $"{_consumeCount}W";
                _previousConsumeCount = _consumeCount;
                yield return _waitOneSecond;
            }
        }
    }
}