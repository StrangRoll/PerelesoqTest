using UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Button Link", menuName = "Button Links")]
    
    public class ButtonObject : ScriptableObject
    {
        public ButtonClickReader Button;
    }
}