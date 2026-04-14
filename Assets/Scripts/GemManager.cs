using UnityEngine;
using System.Collections;

public class GemManager : MonoBehaviour
{
    public float slideTime = 0.15f;
    int totalGems;
    int collectedGems;

    void Start()
    {
        totalGems = FindObjectsByType<GemScript>(FindObjectsSortMode.None).Length;
        collectedGems = 0;
        Debug.Log("Total gems dans le niveau: " + totalGems);
    }

    public void GemCollected()
    {
        collectedGems++;
        Debug.Log("Gem collectee: " + collectedGems + "/" + totalGems);

        if (SFXManager.instance != null)
            SFXManager.instance.PlayGemCollect(collectedGems, totalGems);

        if (collectedGems >= totalGems)
        {
            StartCoroutine(SlideAndWin());
        }
    }

    IEnumerator SlideAndWin()
    {
        var player = FindFirstObjectByType<PlayerMovement2D>();
        if (player != null)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            player.enabled = false;

            if (rb != null)
            {
                Vector2 velocity = rb.linearVelocity * 0.5f;
                rb.linearVelocity = velocity;
                yield return new WaitForSeconds(slideTime);
                rb.linearVelocity = Vector2.zero;
            }
        }

        LevelComplete levelComplete = FindFirstObjectByType<LevelComplete>();
        if (levelComplete != null)
        {
            levelComplete.Show();
        }
    }
}
