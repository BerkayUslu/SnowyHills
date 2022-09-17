using System.Collections;
using System.Linq;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject _scoreElementPrefab;
    [SerializeField] private GameObject _scrollContentObject;
    private Transform _transformScrollContentObject;
    void Awake()
    {
        _transformScrollContentObject = _scrollContentObject.transform;
        ScoreData playerScore = new ScoreData(Account._instance); 
        if (FileReadWrite.IsThereSaveFile())
        {
            List<ScoreData> previousScoreList = FileReadWrite.GetScoreData();
            previousScoreList.Add(playerScore);
            List<ScoreData> newScoreList = SortByScoreUsingLinq(previousScoreList);
            FileReadWrite.SaveScore(newScoreList);
        }
        else
        {
            List<ScoreData> scoreList = new List<ScoreData>();
            scoreList.Add(playerScore);
            FileReadWrite.SaveScore(scoreList);
        }
    }

    void Start()
    {
        List<ScoreData> scoreDataList = FileReadWrite.GetScoreData();
        int rank = 1; 
        foreach (ScoreData scoreData in scoreDataList)
        {
            if (rank > 10) return;
            CreateHighScoreElement(rank, scoreData.GetName(), scoreData.GetScore());
            rank++;
        }
        
    }

    private void CreateHighScoreElement(int rank, string name, int score)
    {
        GameObject instance = Instantiate(_scoreElementPrefab, _transformScrollContentObject.position + new Vector3(0, -5 - 110 * (rank - 1)), Quaternion.identity,
            _transformScrollContentObject);
        TextMeshProUGUI[] texts = instance.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = rank + "-";
        texts[1].text = name;
        texts[2].text = score.ToString();
    }
    
    private List<ScoreData> SortByScoreUsingLinq(List<ScoreData> originalList)
    {
        return originalList.OrderBy(x => -x.GetScore()).ToList();
    }
}
