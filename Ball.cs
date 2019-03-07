using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity;
    [SerializeField] float yVelocity;

    private Vector2 diffBallPaddle;
    private Boolean hasStarted = false;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        diffBallPaddle = transform.position - paddle1.transform.position;
        rigidbody2D = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            PutBallOnPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void PutBallOnPaddle()
    {
        Vector2 vectorPaddle = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = vectorPaddle + diffBallPaddle;
    }


    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }
}
