using UnityEngine;

public class GemScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            GemManager manager = FindFirstObjectByType<GemManager>();
            if (manager != null)
            {
                manager.GemCollected();
            }
            Destroy(gameObject);
        }
    }
}
