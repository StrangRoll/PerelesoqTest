using UI.ClickReaders;
using UnityEngine;

namespace ScriptableObjects.ToggleLinker
{
    [CreateAssetMenu(fileName = "New_Toggle_Linker", menuName = "Toggle Linker")]

    public class ToggleLinker : ScriptableObject
    {
        [HideInInspector] public ToggleClickReader Toggle;
    }
}