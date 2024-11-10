using TMPro;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    // Reference to the player's Rigidbody2D for applying bounce
    [SerializeField] int gameScore = 0;
    [SerializeField] int mScore = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    public Rigidbody2D playerRigidbody;
    [SerializeField] Spawn spawn;

    // This method is triggered when the "Feet" collider overlaps with another collider
    private void Start()
    {
        spawn = GameObject.Find("spawn1").GetComponent<Spawn>();
        scoreText.gameObject.SetActive(true);
        UpdateScore(gameScore);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object the "Feet" collider is touching has the tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy on top collision
            Destroy(other.gameObject);
            spawn.RemoveEnemy(other.gameObject);
            UpdateScore(mScore);

            // Add a small bounce effect to the player after landing
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 4f);
        }
    }

    public void UpdateScore(int score)
    {
        gameScore += score;
        scoreText.text = "Score:" + gameScore;
    }
}
