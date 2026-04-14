using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] bool isVertical = false;

    bool movingPositive = true;
    bool isGameOver = false;
    float turnCooldown = 0f;

    void Update()
    { 
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return; 
        }

        if (turnCooldown > 0f)
            turnCooldown -= Time.deltaTime;

        Vector3 dir = isVertical
            ? (movingPositive ? Vector3.up : Vector3.down)
            : (movingPositive ? Vector3.right : Vector3.left);

        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (isGameOver) return; 
        print(other.tag);

        if ((other.CompareTag("Wall") || other.CompareTag("Enemy")) && turnCooldown <= 0f)
        {
            movingPositive = !movingPositive;
            turnCooldown = 0.3f;
            return;
        }

        if (other.CompareTag("player"))
        {
             isGameOver = true;
            if (gameOverScreen != null)
                gameOverScreen.SetActive(true);

            var movement = other.GetComponent<PlayerMovement2D>();
            if (movement != null)
                movement.enabled = false;

            var rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            isGameOver = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy")) && turnCooldown <= 0f)
        {
            movingPositive = !movingPositive;
            turnCooldown = 0.3f;
            print("collision");
        }
    }
}