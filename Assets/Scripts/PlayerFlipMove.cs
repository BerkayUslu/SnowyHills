using UnityEngine;

public class PlayerFlipMove : MonoBehaviour, IFlip
{
    private const int FLIP_BASE_SCORE = 100;
    private const int FLIP_COMBO_POINT = 1;
    private LayerMask _groundLayerMask;
    private PlayerScore _playerScore;
    private float _accumilatedDegree;
    private int _prwFlipCount = 0;
    private int _flipCount = 0;
    private Quaternion _previousRotation;
    private Quaternion _currentRotation;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _previousRotation = _transform.rotation;
        _groundLayerMask = LayerMask.GetMask("Ground");
        _playerScore = FindObjectOfType<PlayerScore>();
    }

    private void Update()
    {
        float angleBetweenTwoRotationAngles = FindTheAngleBtwRotations();

        float differenceBetweenAngles = _previousRotation.eulerAngles.z - _currentRotation.eulerAngles.z;
        _accumilatedDegree += Mathf.Sign(differenceBetweenAngles) * angleBetweenTwoRotationAngles;

        if (Mathf.Abs(_accumilatedDegree) > 290)
        {
            _accumilatedDegree = 0;
            _flipCount++;
        }

        if (IsGrounded())
        {
            int flipCountDifference = _flipCount - _prwFlipCount;
            if (flipCountDifference != 0)
            {
                int score = FLIP_BASE_SCORE * flipCountDifference;
                _playerScore.UpdateScore(score, flipCountDifference * FLIP_COMBO_POINT);
            }
            _accumilatedDegree = 0;
            _prwFlipCount = _flipCount;
        }


    }
    public void HeadHitTheGround()
    {
        _flipCount = _prwFlipCount;
        _accumilatedDegree = 0;
    }

    private float FindTheAngleBtwRotations()
    {
        _currentRotation = _transform.rotation;
        float angleBetween = Quaternion.Angle(_previousRotation, _currentRotation);
        _previousRotation = _currentRotation;
        return angleBetween;
    }

    private bool IsGrounded()
    {
        Vector2 size = new Vector2(1, 1);
        float extraHeight = .6f;
        RaycastHit2D hitGround = Physics2D.BoxCast(_transform.position,
            size, 0, - _transform.up, extraHeight, _groundLayerMask);
        return hitGround;
    }
}

interface IFlip
{
    void HeadHitTheGround();
}