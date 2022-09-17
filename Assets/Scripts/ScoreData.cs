using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ScoreData
{
    private int score;
    private string name;
    private int rank;

    public ScoreData(Account account)
    {
        score = account.GetScore();
        name = account.GetPlayerName();
    }

    public int GetScore()
    {
        return score;
    }

    public string GetName()
    {
        return name;
    }

    public void SetRank(int a)
    {
        rank = a;
    }
}
