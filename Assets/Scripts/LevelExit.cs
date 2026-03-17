using UnityEngine;

public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            LevelComplete levelComplete = FindFirstObjectByType<LevelComplete>();
            if (levelComplete != null)
            {
                levelComplete.Show();
            }
        }
    }
}
