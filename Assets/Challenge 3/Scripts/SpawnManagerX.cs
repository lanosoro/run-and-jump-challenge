using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private float minSpawnHeight = 5f;
    private float maxSpawnHeight = 15f;
    private float maxRepeatRate = 4f;
    private float minRepeatRate = 0.75f;
    private float timer;
    private float repeatRate;
    private float spawnHeight;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        repeatRate = Random.Range(minRepeatRate, maxRepeatRate);
        spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
    }
    private void Update()
    {
        timer = Time.deltaTime;
        if  (timer > repeatRate)
        {
            SpawnObjects();
            repeatRate = Random.Range(minRepeatRate, maxRepeatRate);
            spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
            timer = 0;
        }
    }
    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, spawnHeight, 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
