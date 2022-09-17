using UnityEngine;

public class Account : MonoBehaviour
{
    public static Account _instance; 

    [SerializeField] private string _playerName;
    [SerializeField] private int _playerScore;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        _playerName = name;
    }
    
    public string GetPlayerName()
    {
        return _playerName;
    }
    
    public int GetScore()
    {
        return _playerScore;
    }

    public void SetScore(int a)
    {
        _playerScore = a;
    }
}
