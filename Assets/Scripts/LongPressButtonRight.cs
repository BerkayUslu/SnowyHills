using UnityEngine;
using UnityEngine.EventSystems;

public class LongPressButtonRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    PlayerMovement _playerMovement;
    bool pressed = false;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    private void FixedUpdate()
    {
        if (pressed)
        {
            _playerMovement.Rotate(-1);
        }
    }
}
