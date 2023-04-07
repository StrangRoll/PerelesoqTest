using UnityEngine.Events;

namespace Electric_appliances.Interfaces
{
    public interface ICurrentConsumer
    {
        public float CurrentConsumer { get; }

        public event UnityAction<float> ConsumeCurrent;
    }
}