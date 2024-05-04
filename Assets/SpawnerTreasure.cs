using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn; // Drag your prefab to this field in the Inspector
    public Transform[] spawnPos;

    void Start()
    {
        SpawnObject();
    }

    void SpawnObject()
    {
        

        // Instantiate the object at the chosen spawn position
        Instantiate(objectToSpawn, spawnPos[Random.Range(0, 7)].position, spawnPos[Random.Range(0, 7)].rotation);
    }
}
