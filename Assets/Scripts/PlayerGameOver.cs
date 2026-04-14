using UnityEngine;
using UnityEngine.SceneManagement;  

public class PlayerGameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    bool isGameOver = false;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (SFXManager.instance != null)
                SFXManager.instance.PlayDeath();
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);

            var movement = GetComponent<PlayerMovement2D>();
            if (movement != null)
                movement.enabled = false;

            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            isGameOver = true;    
        }
    }
}