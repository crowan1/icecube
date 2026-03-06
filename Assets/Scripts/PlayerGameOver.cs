using UnityEngine;

public class PlayerGameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);

            var movement = GetComponent<PlayerMovement2D>();
            if (movement != null)
                movement.enabled = false;

            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }
}