using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class ButtonClickReader : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        public event UnityAction ButtonClicked;

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