using ScriptableObjects.ToggleLinker;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ClickReaders
{
    public class ToggleClickReader : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private ToggleLinker toggleLinker;

        public event UnityAction<bool> ToggleValueChanged;

        private void Awake()
        {
            if (toggleLinker != null)
                toggleLinker.Toggle = this;
        }

        private void Start()
        {
            ToggleValueChanged?.Invoke(toggle.isOn);
        }

        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            ToggleValueChanged?.Invoke(isOn);
        }
    }
}