using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerGameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    public float slideTime = 0.15f;
    bool isGameOver = false;

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isGameOver)
        {
            isGameOver = true;
            if (SFXManager.instance != null)
                SFXManager.instance.PlayDeath();
            StartCoroutine(SlideAndDie());
        }
    }

    IEnumerator SlideAndDie()
    {
        var rb = GetComponent<Rigidbody2D>();
        var movement = GetComponent<PlayerMovement2D>();
        Vector2 velocity = rb != null ? rb.linearVelocity * 0.5f : Vector2.zero;

        if (movement != null)
            movement.enabled = false;

        if (rb != null)
        {
            rb.linearVelocity = velocity;
            yield return new WaitForSeconds(slideTime);
            rb.linearVelocity = Vector2.zero;
        }

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
    }
}