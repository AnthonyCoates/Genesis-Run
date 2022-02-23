using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public Transform itemHolder;

    private const float spawnOffsetX = 22f;
    private const float spawnOffsetY = 0.5f;
    private const float spawnInterval = 2f;

    private float spawnTimer;

    private float groundHeight;

    void Start()
    {
        groundHeight = GetComponent<PlayerMovement>().GetGroundHeight();

        spawnTimer = Time.time + spawnInterval;
    }

    void Update()
    {
        SpawnItemAfterInterval();
    }

    private void SpawnItemAfterInterval()
    {
        if (Time.time > spawnTimer)
        {
            spawnTimer += spawnInterval;

            SpawnRandomItem();
        }
    }

    private void SpawnRandomItem()
    {
        int rnd = Random.Range(1, 100);
        
        if (rnd >= 1 && rnd <= 40)
        {
            Instantiate(items[0],
            new Vector3(transform.position.x + spawnOffsetX, groundHeight - spawnOffsetY, 0f),
            Quaternion.identity, itemHolder);
        }
        else if (rnd >= 41 && rnd <= 80)
        {
            Instantiate(items[1],
            new Vector3(transform.position.x + spawnOffsetX, groundHeight - spawnOffsetY, 0f),
            Quaternion.identity, itemHolder);
        }
    }
}
