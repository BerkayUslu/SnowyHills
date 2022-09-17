using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class ControllerOptionsToggle : MonoBehaviour
{
    [SerializeField] private RawImage _barImage;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _toggleDot;
    private const float _alphaOn = 1f;
    private const float _alphaOff = .5f;
    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener((a) =>ChangeControllerType());
    }

    private void Start()
    {
        if (Options._instance.GetUIControllerState())
        {
            SetAlphaAndEnableDot(_alphaOn, true);
        }
        else
        {
            SetAlphaAndEnableDot(_alphaOff, false);
        }
    }

    private void ChangeControllerType()
    {
        Options._instance.TurnUIControllerOn(_toggle.isOn);
        if (_toggle.isOn)
        {
            SetAlphaAndEnableDot(_alphaOn, true);
        }
        else
        {
            SetAlphaAndEnableDot(_alphaOff, false);
        }
    }

    private void SetAlphaAndEnableDot(float a, bool b)
    {
        Color color = _text.material.color;
        color.a = a;
        _text.color = color;
        _barImage.color = color;
        
        _toggleDot.SetActive(b);
    }
}
