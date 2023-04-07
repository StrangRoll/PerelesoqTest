using System;
using ScriptableObjects.TMP_TextLinker;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TMP_TextFiledSender : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textField;
        [SerializeField] private TMP_TextLinker _linker;

        private void Awake()
        {
            _linker.TextField = _textField;
        }
    }
}