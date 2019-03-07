using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float widthInUnits;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    private GameStatus gameStatus;
    private Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        AutoPlayRunning();
    }

    private void AutoPlayRunning()
    {
        if (!gameStatus.GetAutoPlay())
        {
            float width = Input.mousePosition.x / Screen.width * widthInUnits;
            Vector2 vector = new Vector2(transform.position.x, transform.position.y);
            vector.x = Mathf.Clamp(width, minX, maxX);
            transform.position = vector;
        }
        else
        {
            Vector2 v = new Vector2(ball.transform.position.x, transform.position.y);
            v.x = Mathf.Clamp(ball.transform.position.x, minX, maxX);
            transform.position = v;
        }
    }
}
