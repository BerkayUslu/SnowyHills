using UnityEngine;
using UnityEngine.EventSystems;


public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    PlayerMovement _playerMovement;

    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerMovement.Jump();
    }
}
