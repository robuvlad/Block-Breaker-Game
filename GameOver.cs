using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshScore;
    private GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ShowScore();
    }

    private void ShowScore()
    {
        textMeshScore.SetText("Your score is : " + gameStatus.GetScore().ToString());
    }
}
