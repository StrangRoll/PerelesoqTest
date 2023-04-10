using ScriptableObjects.LightLinkers;
using UnityEngine;

namespace UI
{
    public class LightsSender : MonoBehaviour
    { 
        [SerializeField] private Light[] lights;
        [SerializeField] private LightsLinker lightsLinker;

        private void Awake()
        {
            lightsLinker.Lights = lights;
        }
    }
}