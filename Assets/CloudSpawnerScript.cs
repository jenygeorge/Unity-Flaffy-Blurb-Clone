using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject cloudPrefab;

    [Header("Spawn settings")]
    public float spawnRate = 1.5f-2f;      // seconds between spawns
    public float startX = 12f;        // right edge spawn X
    public float minY = 2f;           // vertical range
    public float maxY = 5f;

    [Header("Cloud variation")]
    public float minSpeed = 0.2f;     // slow high clouds
    public float maxSpeed = 0.6f;     // faster low clouds
    public float minScale = 1.0f;
    public float maxScale = 2.0f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    void SpawnCloud()
    {
        float yPos = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(startX, yPos, 0);

        GameObject cloud = Instantiate(cloudPrefab, spawnPos, Quaternion.identity);

        // Randomize scale
        float scale = Random.Range(minScale, maxScale);
        cloud.transform.localScale = new Vector3(scale, scale, 1f);

        // Randomize speed (assign to drift script)
        Cloud01Script drift = cloud.GetComponent<Cloud01Script>();
        if (drift == null) drift = cloud.AddComponent<Cloud01Script>();
        drift.speed = Random.Range(minSpeed, maxSpeed);
    }

}
