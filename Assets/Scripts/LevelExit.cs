using UnityEngine;
using System.Collections;

public class LevelExit : MonoBehaviour
{
    public float slideTime = 0.15f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            StartCoroutine(SlideAndWin(other));
        }
    }

    IEnumerator SlideAndWin(Collider2D player)
    {
        var movement = player.GetComponentInParent<PlayerMovement2D>();
        var rb = player.GetComponentInParent<Rigidbody2D>();

        if (movement != null)
            movement.enabled = false;

        if (rb != null)
        {
            Vector2 velocity = rb.linearVelocity * 0.5f;
            rb.linearVelocity = velocity;
            yield return new WaitForSeconds(slideTime);
            rb.linearVelocity = Vector2.zero;
        }

        LevelComplete levelComplete = FindFirstObjectByType<LevelComplete>();
        if (levelComplete != null)
        {
            levelComplete.Show();
        }
    }
}
