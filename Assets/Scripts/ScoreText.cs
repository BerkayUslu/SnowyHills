using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    PlayerScore _score;
    Text _text;

    void Start()
    {
        _score = FindObjectOfType<PlayerScore>();
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "SCORE: " + _score.GetScore();
    }
}
