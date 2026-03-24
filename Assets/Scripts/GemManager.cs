using UnityEngine;

public class GemManager : MonoBehaviour
{
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

        if (collectedGems >= totalGems)
        {
            LevelComplete levelComplete = FindFirstObjectByType<LevelComplete>();
            if (levelComplete != null)
            {
                levelComplete.Show();
            }
        }
    }
}
