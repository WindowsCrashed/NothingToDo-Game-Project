using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [Header("Mark distance")]
    [SerializeField] float perfectMark;
    [SerializeField] float goodMark;
    [SerializeField] float badMark;
    [SerializeField] float missMark;

    [Header("Points per mark")]
    [SerializeField] int perfectPoints;
    [SerializeField] int goodPoints;
    [SerializeField] int badPoints;
    [SerializeField] int missPoints;

    [Header("Limits")]
    [SerializeField] int maxScore;

    int score = 0;
    int highScore = 0;
    string status;

    void Awake()
    {
        ManageSingleton();
    }

    void UpdateScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, maxScore);
    }

    int CalculateScore(float distance)
    {
        if (distance >= missMark)
        {
            status = "Miss";
            return missPoints;
        }
        else if (distance >= badMark)
        {
            status = "Bad";
            return badPoints;
        }
        else if (distance >= goodMark)
        {
            status = "Good";
            return goodPoints;
        }
        else if (distance >= perfectMark)
        {
            status = "Perfect";
            return perfectPoints;
        } else
        {
            status = "???";
            return 0;
        }

        //Debug.Log(distance);
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;

        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }
    
    public int GetHighScore()
    {
        return highScore;
    }

    public string GetStatus()
    {
        return status;
    }

    public void SetScore(float distance)
    {
        int points = CalculateScore(distance);

        UpdateScore(points);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
