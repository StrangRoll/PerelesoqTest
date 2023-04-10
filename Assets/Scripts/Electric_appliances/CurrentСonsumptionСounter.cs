using System.Collections;
using AYellowpaper;
using Electric_appliances.Interfaces;
using ScriptableObjects.TMP_TextLinker;
using TMPro;
using UnityEngine;

namespace Electric_appliances
{
    public class CurrentСonsumptionСounter : MonoBehaviour
    {
        [RequireInterface(typeof(ICurrentConsumer))]
        [SerializeField] private GameObject[] currentConsumers;
        [SerializeField] private TMP_TextLinker consumeCountLinker;
        [SerializeField] private TMP_TextLinker consumePerSecondCountLinker;

        private float _consumeCount = 0;
        private float _previousConsumeCount = 0;
        private WaitForSeconds _waitOneSecond;
        private TMP_Text consumeCountText;
        private TMP_Text consumePerSecondCountText;

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
            consumeCountText = consumeCountLinker.TextField;
            consumePerSecondCountText = consumePerSecondCountLinker.TextField;
            _waitOneSecond = new WaitForSeconds(1);
            StartCoroutine(CountConsumePerSecond());
        }
        
        private void OnDisable()
        {
            foreach (var currentConsumer in currentConsumers)
            {
                if (currentConsumer == null)
                    return;
                
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
                var currentValue = (_consumeCount - _previousConsumeCount).ToString("F3");
                var totalValue = (_consumeCount).ToString("F3");
                
                consumePerSecondCountText.text = $"CURRENT: {currentValue}W";
                consumeCountText.text = $"TOTAL: {totalValue}W";
                _previousConsumeCount = _consumeCount;
                yield return _waitOneSecond;
            }
        }
    }
}