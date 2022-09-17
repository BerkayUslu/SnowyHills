using UnityEngine;
using UnityEngine.U2D;


public class ProceduralTerrarian : MonoBehaviour
{
    SpriteShapeController _spriteShape;

    private int _terrarianWidth = 4600;
    private int _terrarianLength = 200;
    private int _numberOfBreakPoints = 169;
    private int _distanceBtwSplines = 27;
    private float _leftTangent = 9;
    private float _rightTangent = 9;
    private float _RandomGain = 25;
    private Spline _spline;

    private void Awake()
    {
        _spriteShape = GetComponent<SpriteShapeController>();
        _spline = _spriteShape.spline;
        SetTerrarianSize();
        CreateStartingGround();
        InsertSplines();
        SetTangent();
        SetColliderSettings();
    }

    private void CreateStartingGround()
    {
        Vector3 splinePosition = _spriteShape.spline.GetPosition(1);
        _spline.InsertPointAt(2, new Vector3(splinePosition.x + 40, splinePosition.y, splinePosition.z));
        _spline.SetTangentMode(2, ShapeTangentMode.Linear);
        _spline.SetTangentMode(1, ShapeTangentMode.Linear);
        _spline.SetPosition(1, new Vector3(0,0,0));
        _spline.SetPosition(2, new Vector3(_spline.GetPosition(2).x,0,0));
    }

    private void SetColliderSettings()
    {
        _spriteShape.BakeCollider();
    }

    private void SetTangent()
    {
        for (int i = 0; i < _numberOfBreakPoints; i++)
        {
            _spline.SetTangentMode(i + 2, ShapeTangentMode.Continuous);
            _spline.SetRightTangent(i + 2, new Vector3(_rightTangent, 0, 0));
            _spline.SetLeftTangent(i + 2, new Vector3(-_leftTangent, 0, 0));
        }
    }

    private void InsertSplines()
    {
        for (int i = 1; i < _numberOfBreakPoints; i++)
        {
            Vector3 splinePosition = _spriteShape.spline.GetPosition(i + 1);
            _spline.InsertPointAt(i + 2, new Vector3(splinePosition.x + _distanceBtwSplines, Mathf.Lerp(-_RandomGain, _RandomGain, Mathf.PerlinNoise(i * .5f,0)), 0f));
        }
        _spline.SetPosition(171, new Vector3(_spriteShape.spline.GetPosition(171).x, 0, 0));
        _spline.SetPosition(170, new Vector3(_spriteShape.spline.GetPosition(170).x, 0, 0));
    }

    private void SetTerrarianSize()
    {
        _spline.SetPosition(0, _spriteShape.spline.GetPosition(0) + Vector3.down * _terrarianLength);
        _spline.SetPosition(2, _spriteShape.spline.GetPosition(1) + Vector3.right * _terrarianWidth);
        _spline.SetPosition(3, _spriteShape.spline.GetPosition(0) + Vector3.right * _terrarianWidth);
    }
}
