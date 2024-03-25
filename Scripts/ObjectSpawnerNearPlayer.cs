using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerAbovePlayer : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab of the falling object
    public float spawnRadius = 10f; // Radius around the player where objects will be spawned
    public float spawnInterval = 2f; // Interval between object spawns
    public float spawnHeight = 20f; // Height above the player where objects will be spawned

    private Transform playerTransform;

    void Start()
    {
        // Find the player GameObject by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            // Invoke repeating function to spawn objects every spawnInterval seconds
            InvokeRepeating("SpawnObject", 1f, spawnInterval);
        }
        else
        {
            Debug.LogError("No GameObject with tag 'Player' found!");
        }
    }

    void SpawnObject()
    {
        // Random position within a circle around the player (on the same height as the player)
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(randomCircle.x, spawnHeight, randomCircle.y);

        // Instantiate objectPrefab at spawnPosition with default rotation
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}