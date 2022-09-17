using System;
using UnityEngine;
using UnityEngine.UI;

public class BoostTimeUIBar : MonoBehaviour
{
    private Image _barImage;
    [SerializeField]
    private PlayerSpeedBoost _playerBoost;
    [SerializeField] private GameObject[] _childrens;
    private bool _boostOn = false;
    

    private void Awake()
    {
        _barImage = GetComponentInChildren<Image>();
        _playerBoost.BoostEndedAction += HideBar;
        _playerBoost.BoostStartedAction += ShowBar;
    }

    private void Update()
    {
        if (!_boostOn) return;
        _barImage.fillAmount =  _playerBoost.GetRemainingBoostTime() / _playerBoost.GetTotalBoostTimeLeft();
    }
    
    private void ShowBar()
    {
        _boostOn = true;
        foreach (GameObject children in _childrens)
        {
            children.SetActive(true);
        }
    }

    private void HideBar()
    {
        _boostOn = false;
        foreach (GameObject children in _childrens)
        {
            children.SetActive(false);
        }
    }
}
