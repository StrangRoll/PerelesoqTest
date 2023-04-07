using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ButtonClickReader : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ButtonObject buttonLink;
        
        public event UnityAction ButtonClicked;

        private void OnEnable()
        {
            button.onClick.AddListener(ButtonClickListener);
            buttonLink.Button = this;
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