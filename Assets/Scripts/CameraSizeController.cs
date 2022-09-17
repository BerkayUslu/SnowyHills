using System;
using UnityEngine;
using Cinemachine;

public class CameraSizeController : MonoBehaviour
{
    private IPlayerSpeed _playerSpeed;
    [SerializeField] private CinemachineVirtualCamera _slowCamera;
    [SerializeField] private CinemachineVirtualCamera _fastCamera;
    [SerializeField] private CinemachineVirtualCamera _onAirCamera;
    private IPlayerSpeed _playerMovement;
    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (!_playerMovement.IsGrounded())
        {
            EnableOnAirCamera();
        }
        else if (_playerMovement.GetSpeed() < 18)
        {
            EnableSlowCam();
        }
        else
        {
            EnableFastCam();
        }
    }
    
    private void EnableSlowCam()
    {
        _slowCamera.enabled = true;
        _fastCamera.enabled = false;
        _onAirCamera.enabled = false;
    }

    private void EnableFastCam()
    {
        _slowCamera.enabled = false;
        _fastCamera.enabled = true;
        _onAirCamera.enabled = false;
    }

    private void EnableOnAirCamera()
    {
        _onAirCamera.enabled = true;
        _slowCamera.enabled = false;
        _fastCamera.enabled = false;
    }
    
}

