using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollision : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab for explosion effect

    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "ground" and hasn't collided before
        if (collision.gameObject.CompareTag("Ground") && !hasCollided)
        {
            hasCollided = true; // Prevent multiple collisions triggering multiple explosions

            // Instantiate explosionPrefab at the collision point
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Optional: Play explosion sound effect
            // Add sound component to the explosion prefab and play it here

            // Destroy the rock
            Destroy(gameObject);
        }
    }
}

