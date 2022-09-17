using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    IPlayerSpeed _playerRigidbody;
    Text _text;

    void Start()
    {
        _playerRigidbody = FindObjectOfType<PlayerMovement>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "SPEED: " + Mathf.Floor(_playerRigidbody.GetSpeed());
    }
}
