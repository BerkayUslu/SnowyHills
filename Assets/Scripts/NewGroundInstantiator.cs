using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGroundInstantiator : MonoBehaviour
{
    bool IsCreated = false;
    private MapManager _gamemanager;
    private Vector3 _parentPosition;

    private void Awake()
    {
        _gamemanager = FindObjectOfType<MapManager>();
        _parentPosition = GetComponentInParent<Transform>().position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Head") && !IsCreated)
        {
            _gamemanager.InstantiateGround(_parentPosition);
            IsCreated = true;
        }
    }

    public void DestroyGround()
    {
        Destroy(gameObject);
    }

}
