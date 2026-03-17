using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI levelText;
    public Button nextButton;

    void Start()
    {
        panel.SetActive(false);
        nextButton.onClick.AddListener(LoadNextLevel);
    }

    public void Show()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = "Niveau " + levelNumber + " termine";
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
