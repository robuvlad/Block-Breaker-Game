using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    private Level level;
    private GameStatus gameStatus;
    [SerializeField] GameObject objectVFX;

    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] blocksSprites;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();

        if (tag == "Breakable")
        {
            level.IncreaseNumberOfBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            IncreaseBlockHits();
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            } else
            {
                NextBreakableBlock();
            }
        }
    }

    private void NextBreakableBlock()
    {
        int indexSprite = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = blocksSprites[indexSprite];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);

        level.DecreaseNumberOfBlocks();
        gameStatus.AddPointsToScore();

        ShowVFX();
    }

    private void ShowVFX()
    {
        GameObject gameObjectVFX = Instantiate(objectVFX, transform.position, transform.rotation);
        Object.Destroy(gameObjectVFX, 2.0f);
    }

    private void IncreaseBlockHits()
    {
        timesHit += 1;
    }
}
