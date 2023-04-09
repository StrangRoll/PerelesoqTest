using UI;
using UI.ClickReaders;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New_button_linker", menuName = "Button Linker")]
    
    public class ButtonLinker : ScriptableObject
    {
        [HideInInspector] public ButtonClickReader Button;
    }
}