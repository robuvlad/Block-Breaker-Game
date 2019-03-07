using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int numberOfBlocks;
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncreaseNumberOfBlocks()
    {
        numberOfBlocks += 1;
    }

    public void DecreaseNumberOfBlocks()
    {
        numberOfBlocks -= 1;
        if (numberOfBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
