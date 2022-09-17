using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    IFlip _playerflipmove;
    IHealth _playerHealth;

    private void Start()
    {
        _playerflipmove = GetComponentInParent<PlayerFlipMove>();
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerflipmove.HeadHitTheGround();
        _playerHealth.TakeDamage();
    }
}
