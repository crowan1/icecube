using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
