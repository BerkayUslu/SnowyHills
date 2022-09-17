using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score = 0;
    private IBoostManage _boost;

    private void Awake()
    {
        _boost = FindObjectOfType<PlayerSpeedBoost>();
    }

    public void UpdateScore(int score, int comboPoint)
    {
        _boost.Boost(comboPoint);
        _score += score;
    }

    public int GetScore()
    {
        return _score;
    }
}