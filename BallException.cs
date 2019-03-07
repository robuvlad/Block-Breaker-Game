using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallException : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetGameObjectActive();
    }

    public void ShowBallException(Vector2 vector)
    {
        gameObject.transform.position = vector;
        gameObject.SetActive(true);
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(false);
    }
}
