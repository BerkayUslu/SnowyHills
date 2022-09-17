using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; 
    [SerializeField] private TextMeshProUGUI _placeHolder; 
    private void Awake()
    {
    }

    public void SendName()
    {
        bool isInputFieldEmpty = _text.text.Length < 2;
        if (isInputFieldEmpty)
        {
            Account._instance.SetPlayerName(_placeHolder.text);
        }
        else
        {
            Account._instance.SetPlayerName(_text.text);
        }
    }

    private void Update()
    {
        bool isInputFieldEmpty = _text.text.Length < 2;
        bool isThereSavedName = Account._instance.GetPlayerName().Length > 1;
        if (isInputFieldEmpty && isThereSavedName)
        {
            _placeHolder.text = Account._instance.GetPlayerName();
        }
    }
}
