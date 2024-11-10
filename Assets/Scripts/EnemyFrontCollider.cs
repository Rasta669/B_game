using System;
using UnityEngine;

public class EnemyFrontCollider : MonoBehaviour
{
    // Reference to the player's Rigidbody2D for applying bounce
    GameSceneUI gameSceneUI;
    

    // This method is triggered when the "Feet" collider overlaps with another collider

    private void Start()
    {
         
         gameSceneUI = GameObject.Find("GameUI").GetComponent<GameSceneUI>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the "Feet" collider is touching has the tag "Enemy"
        if (other.CompareTag("Player"))
        {
            // Destroy the enemy on top collision
            //Destroy(other.gameObject);
            Debug.Log("! Detected", other);
            gameSceneUI.GameOver();
            
        }
    }
}
