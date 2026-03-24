using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float distance = 2f;
    [SerializeField] GameObject gameOverScreen;

    Vector3 startPos;
    bool movingRight = true;
    bool isGameOver = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    { 
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPos.x + distance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startPos.x - distance)
                movingRight = true;
        }
 
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
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
}