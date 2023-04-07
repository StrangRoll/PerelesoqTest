using TMPro;
using UnityEngine;

namespace ScriptableObjects.TMP_TextLinker
{
    [CreateAssetMenu(fileName = "New_TMP_Text_Linker", menuName = "TMP Text Linker")]
    
    public class TMP_TextLinker : ScriptableObject
    {
        [HideInInspector] public TMP_Text TextField;
    }
}