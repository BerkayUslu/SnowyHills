using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _playerHealth = 3;
    private IHealthUI _healthUI;
    private const float UNTOUCHABLE_TIME = 2;
    [SerializeField]private bool _isUntouchable = false;


    private void Awake()
    {
        _healthUI = FindObjectOfType<HealthUI>();
    }

    private void Start()
    {
        _healthUI.UpdateHealthUI(_playerHealth);
    }

    public void GainHealth(int a)
    {
        _playerHealth += a;
        _healthUI.UpdateHealthUI(_playerHealth);
    }

    public void TakeDamage()
    {
        if (_isUntouchable) return;
        --_playerHealth;

        if(_playerHealth == 0)
        {
            GameManager._instance.EndGame();
        }
        _healthUI.UpdateHealthUI(_playerHealth);
        _isUntouchable = true;
        StartCoroutine("Untouchable");
    }

    IEnumerator Untouchable()
    {
        yield return new WaitForSeconds(UNTOUCHABLE_TIME);
        _isUntouchable = false;
    }

    public int GetHealth()
    {
        return _playerHealth;
    }
}

interface IHealth
{
    void GainHealth(int a);
    void TakeDamage();
}
