using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerMovement : MonoBehaviour, IPlayerSpeed
{

    Rigidbody2D _rigidbody;
    private bool _touchControlEnabled = true;
    
    private const float _torque = 600;
    private const float _jumpForce = 45000;
    private Transform _transform;
    private LayerMask _groundLayerMask;
    private float _jumpTimer;
    private bool _jumpBegan = false;
    private bool _canJump = true;

    private void Awake()
    {
        _touchControlEnabled = !Options._instance.GetUIControllerState();
        _transform = transform;
        _groundLayerMask = LayerMask.GetMask("Ground");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AdjustLinearDrag();
        IncreaseGravityOnAir();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (!_touchControlEnabled) return;
        PhoneJumpInput();
    }


    private void FixedUpdate()
    {
        Rotate(-Input.GetAxis("Horizontal"));
        
        if (!_touchControlEnabled) return;
        PhoneRotationInput();
    }

    private void PhoneJumpInput()
    {
        if (Input.touchCount < 1)
        {
            _canJump = true;
            return;
        }
        
        var touch = Input.GetTouch(0);
        if (_canJump && touch.position.x > Screen.width / 2)
        {
            _canJump = false;
            Jump();
        }
    }

    private  void PhoneRotationInput()
    {
        if (Input.touchCount < 1 || IsGrounded()) return;
        var touch = Input.GetTouch(0);
        
        if (touch.position.x < Screen.width / 2)
        {
            Rotate(1);
        }
        else if (touch.position.x > Screen.width / 2)
        {
            Rotate(-1);
        }
    }

    private float CalculateSpeedEffect(float thresholdValue, float divider)
    {
        float speed = _rigidbody.velocity.x;
        return speed > thresholdValue ? (speed - thresholdValue) / divider : 0;
    }

    private void AdjustLinearDrag()
    {
        if (_rigidbody.velocity.x > 30)
        {
            float speedEffect = CalculateSpeedEffect(30, 20);
            _rigidbody.drag = .3f + speedEffect;
        }
        else
        {
            _rigidbody.drag = 0;
        }
    }

    private void IncreaseGravityOnAir()
    {
        
        if (!IsGrounded())
        {
            float speedEffect = CalculateSpeedEffect(30, 20);
            _rigidbody.gravityScale = 4 + speedEffect;
        }
        else
        {
            _rigidbody.gravityScale = 1;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

    public void Rotate(float buttonValue)
    {
        _rigidbody.AddTorque(buttonValue * _torque);
    }

    public bool IsGrounded()
    {
        Vector2 size = new Vector2(0.3f, .6f);
        float extraHeight = .0f;
        RaycastHit2D hitGround = Physics2D.BoxCast(_transform.position - _transform.up * 1f,
            size, 0, - _transform.up, extraHeight, _groundLayerMask);        
        Color color;
        if (hitGround)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }
        Debug.DrawRay(_transform.position, -_transform.up * 1.3f, color);
        return hitGround;
    }

    public bool IsOnTHeAirMoreThanHalfSecond()
    {
        if (!IsGrounded() && !_jumpBegan)
        {
            _jumpTimer = Time.time;
            _jumpBegan = true;
        }

        if (IsGrounded())
        {
            _jumpBegan = false;
        }

        if (Time.time - _jumpTimer > .5f)
        {
            return true;
        }

        return false;
    }

    public float GetSpeed()
    {
        return _rigidbody.velocity.x;
    }

}

interface IPlayerSpeed
{
    float GetSpeed();
    bool IsGrounded();
    bool IsOnTHeAirMoreThanHalfSecond();
}