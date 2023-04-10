using UnityEngine;

namespace ScriptableObjects.LightLinkers
{
    [CreateAssetMenu(fileName = "New_light_linker", menuName = "New Light Linker")]

    public class LightsLinker : ScriptableObject
    {
        [HideInInspector] public Light[] Lights;
    }
}