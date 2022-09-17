using UnityEngine;

public class PlayerForceApplier: MonoBehaviour, IPid
{ 
    const float PROPORTIONAL_GAIN = 30f;
    const float DERIVATIVE_GAIN = 10f;
    const float SPEED_LIMIT = 25f;

    Rigidbody2D _rigidbody;
    private LayerMask _groundLayerMask;
    private float _velocityError = 0f;
    private float _previousVelocityError = 0f;
    private float _proportionalGain;
    private float _derivativeGain;
    private float _speedLimit;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _groundLayerMask = LayerMask.GetMask("Ground");
        _proportionalGain = PROPORTIONAL_GAIN;
        _derivativeGain = DERIVATIVE_GAIN;
        _speedLimit = SPEED_LIMIT;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!IsGrounded()) return;
        PID();
    }

    private void PID()
    {
        _velocityError = _speedLimit - _rigidbody.velocity.x;
        float changeRateOfError = (_velocityError - _previousVelocityError) / Time.deltaTime;
        float P = _velocityError * _proportionalGain;
        float D = _derivativeGain * changeRateOfError;
        _previousVelocityError = _velocityError;
        _rigidbody.AddForce(new Vector2(P + D, 0));
    }


    private bool IsGrounded()
    {
        Vector2 size = new Vector2(1, 1);
        float extraHeight = .6f;
        RaycastHit2D hitGround = Physics2D.BoxCast(_transform.position,
                        size, 0, - _transform.up, extraHeight, _groundLayerMask);
        return hitGround;
    }

    public void ResetPIDValues()
    {
        _proportionalGain = PROPORTIONAL_GAIN;
        _derivativeGain = DERIVATIVE_GAIN;
        _speedLimit = SPEED_LIMIT;
    }

    public void SetProportionalGain(float a)
    {
        _proportionalGain = a;
    }

    public void SetDerivativeGain(float a)
    {
        _derivativeGain = a;
    }

    public void SetSpeedLimit(float a)
    {
        _speedLimit = a;
    }
}

interface IPid
{
    void SetProportionalGain(float a);
    void SetDerivativeGain(float a);
    void SetSpeedLimit(float a);
    void ResetPIDValues();
}