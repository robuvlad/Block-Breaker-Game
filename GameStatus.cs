using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;
    [SerializeField] int pointsToAdd = 15;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool AutoPlay;

    private List<Vector2> list;
    [SerializeField] BallException ballException;

    private void Awake()
    {
        list = new List<Vector2>();

        int currentGameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (currentGameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

            ballException.SetGameObjectActive();
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        SetTextScore();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;

        if (FindObjectOfType<Ball>().GetHasStarted() == true)
        {
            ShowBallWhenLoop();
        }
    }

    public void AddPointsToScore()
    {
        currentScore += pointsToAdd;
        SetTextScore();
    }

    private void SetTextScore()
    {
        scoreText.SetText(currentScore.ToString());
    }

    public bool GetAutoPlay()
    {
        return AutoPlay;
    }

    public int GetScore()
    {
        return currentScore;
    }

    
    private void ShowBallWhenLoop()
    {
        Vector2 currentBallVector = new Vector2(FindObjectOfType<Ball>().transform.position.x, FindObjectOfType<Ball>().transform.position.y);
        Debug.Log(list.Count + " " + currentBallVector.x + " " + currentBallVector.y);
        if (list.Count != 10)
        {
            list.Add(currentBallVector);
        } else
        {
            if (CheckIfEqual(list))
            {
                ballException.ShowBallException(currentBallVector);
            }

            list.Remove(list[0]);
            list.Add(currentBallVector);
        }
    }

    private bool CheckIfEqual(List<Vector2> l)
    {
        bool isEqual = true;
        for(int i=0; i<l.Count-1; i++)
        {
            for(int j=i+1; j<l.Count; j++)
            {
                if (l[i].x == l[j].x)
                {
                    isEqual = false;
                }
            }
        }
        return isEqual;
    }
}
