using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject _startSceneUI;
    [SerializeField] private GameObject _optionsUI;

    public void ShowOptionsUI()
    {
        _optionsUI.SetActive(true);
        _startSceneUI.SetActive(false);
    }
}
