using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn; // Drag your prefab to this field in the Inspector
    public Transform[] spawnPos;
    public PLayersHealth player;
    private bool hasSpawned = false;


    void Start()
    {
        

    }

    private void Update()
    {
        if (player.gameON && !hasSpawned)
        {
            SpawnObject();
            hasSpawned = true;
        }
    }

    void SpawnObject()
    {
        

        // Instantiate the object at the chosen spawn position
        Instantiate(objectToSpawn, spawnPos[Random.Range(0, 7)].position, spawnPos[Random.Range(0, 7)].rotation);
    }
}
