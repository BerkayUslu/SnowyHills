using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    
    [SerializeField] private const int _frameRate = 30;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<GameManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetFrameRate(_frameRate);
    }

    private void SetFrameRate(int frameRate)
    {
        Application.targetFrameRate = frameRate;
    }
    
    public void EndGame()
    {
        Account._instance.SetScore(FindObjectOfType<PlayerScore>().GetScore());
        SceneManager.LoadScene("GameOverScene");
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void PauseGame(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
    }

}






