using UnityEngine;

public class GemParentScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            print("Gagné !");
            LevelComplete levelComplete = FindFirstObjectByType<LevelComplete>();
            print(levelComplete);
            if (levelComplete != null)
            {
                levelComplete.Show();
            }
        }
    }
}
