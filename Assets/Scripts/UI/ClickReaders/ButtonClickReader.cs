using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.ClickReaders
{
    public class ButtonClickReader : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ButtonLinker buttonLink = null;
        
        public event UnityAction ButtonClicked;

        private void Awake()
        {
            if (buttonLink != null)
                buttonLink.Button = this;
        }
        
        private void OnEnable()
        {
            button.onClick.AddListener(ButtonClickListener);
        }

        private void OnDisable()
        {
            button.onClick.AddListener(ButtonClickListener);
        }

        private void ButtonClickListener()
        {
            ButtonClicked?.Invoke();
        }
    }
}