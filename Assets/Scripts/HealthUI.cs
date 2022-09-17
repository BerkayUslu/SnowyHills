using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour, IHealthUI
{
    [SerializeField] private GameObject _heartPrefab;

    private List<GameObject> _heartsList = new List<GameObject>();
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void UpdateHealthUI(int health)
    {
        int oldHealth = _heartsList.Count;
        if (oldHealth > health && _heartsList.Count > 0)
        {
            _heartsList[oldHealth - 1].GetComponent<Heart>().DestroyHeart();
            _heartsList.Remove(_heartsList[oldHealth - 1]);
        }
        else
        {
            for(var i = 0; i < health - oldHealth; i++)
            {
                GameObject heart = Instantiate(_heartPrefab, new Vector3( 0, 0, 0), Quaternion.identity, _transform);
                heart.transform.localPosition = new Vector3(60 * _heartsList.Count, 0, 0);
                _heartsList.Add(heart);

            }
        }
    }
}

interface IHealthUI
{
    void UpdateHealthUI(int health);
}