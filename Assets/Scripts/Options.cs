using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options _instance; 
    [SerializeField] private bool _uiControllerOn = false;
    [SerializeField] private bool _touchControllerOn = true;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void TurnUIControllerOn(bool isOn)
    {
        _uiControllerOn = isOn;
        _touchControllerOn = !isOn;
    }

    public bool GetUIControllerState()
    {
        return _uiControllerOn;
    }

}

