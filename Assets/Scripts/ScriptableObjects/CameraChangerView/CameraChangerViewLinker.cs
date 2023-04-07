using UnityEngine;

namespace ScriptableObjects.CameraChangerView
{
    [CreateAssetMenu(fileName = "New_camera_changer_linker", menuName = "Camera Changer View")]
    
    public class CameraChangerViewLinker : ScriptableObject
    {
        [HideInInspector] public UI.CameraChangerView CameraChangerView;
    }
}