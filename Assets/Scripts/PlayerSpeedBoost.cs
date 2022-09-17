using UnityEngine;
using System;

public class PlayerSpeedBoost : MonoBehaviour, IBoostManage
{
    IPid _pid;
    private const float BOOST_PROPORIONAL_GAIN = 60f;
    private const float BOOST_DERIVATIVE_GAIN = 20f;
    private const float BOOST_SPEED_LIMIT = 30f;
    private const float BOOST_TIME_LENGTH = 3.5f;
    private const float EXTRA_BOOST_TIME_LENGTH = 3.5f;
    private const float EXTRA_SPEED_LIM_COEFF = .5f;
    private const float EXTRA_PROPORTIONAL_COEFF = 3;
    [SerializeField] private int _accumulatedBoost = 0;
    private float _totalBoostTimeLeft;
    private float _boostEndTime = 0;
    public event Action BoostEndedAction;
    public event Action BoostStartedAction;

    private void Awake()
    {
        _pid = GetComponent<PlayerForceApplier>();
    }


    public void Boost(int comboPoint)
    {
        DecideBoostEndTimeAndAccumulatedBoost(comboPoint);
        float extraProportionalGain = EXTRA_PROPORTIONAL_COEFF * _accumulatedBoost;
        float extraSpeedLimit = EXTRA_SPEED_LIM_COEFF * _accumulatedBoost;
        _pid.SetProportionalGain(BOOST_PROPORIONAL_GAIN + extraProportionalGain);
        _pid.SetDerivativeGain(BOOST_DERIVATIVE_GAIN);
        _pid.SetSpeedLimit(BOOST_SPEED_LIMIT + extraSpeedLimit);
        BoostStartedAction.Invoke();
    }

    private void DecideBoostEndTimeAndAccumulatedBoost(int comboPoint)
    {
        if (IsBoostEnded())
        {
            float boostStartTime = Time.time;
            _boostEndTime = boostStartTime + BOOST_TIME_LENGTH * comboPoint;
            _accumulatedBoost = comboPoint;
        }
        else
        {
            float extraTime = EXTRA_BOOST_TIME_LENGTH * comboPoint;
            _boostEndTime += extraTime;
            _accumulatedBoost += comboPoint; 
        }

        _totalBoostTimeLeft = GetRemainingBoostTime();
    }

    public int GetAccumulatedMoves()
    {
        return _accumulatedBoost;
    }

    public void EndBoost()
    {
        BoostEndedAction.Invoke();
        _accumulatedBoost = 0;
        _pid.ResetPIDValues();
    }

    private void Update()
    { 
        if (IsBoostEnded())
        {
            EndBoost();
        }
    }

    public float GetTotalBoostTimeLeft()
    {
        return  _totalBoostTimeLeft;
    }

    public float GetRemainingBoostTime()
    {
        return IsBoostEnded() ? 0 : _boostEndTime - Time.time;
    }

    public bool IsBoostEnded()
    {
         return Time.time > _boostEndTime;
    }
}

interface IBoostManage
{
    void Boost(int scoreIncrease);
    int GetAccumulatedMoves();
}
