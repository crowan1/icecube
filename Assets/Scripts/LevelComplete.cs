using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI levelText;

    bool isShowing = false;
    bool isLastLevel = false;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (isShowing && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            OnNextPressed();
        }
    }

    public void Show()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        isLastLevel = nextSceneIndex >= SceneManager.sceneCountInBuildSettings;

        LevelProgress.UnlockLevel(nextSceneIndex);

        if (isLastLevel)
        {
            levelText.text = "BRAVO ! Tous les niveaux sont réussis !";
        }
        else
        {
            levelText.text = "NIVEAU " + levelNumber + " TERMINÉ";
        }
        if (SFXManager.instance != null)
        {
            if (isLastLevel)
                SFXManager.instance.PlayFinalVictory();
            else
                SFXManager.instance.PlayVictory();
        }
        panel.SetActive(true);
        isShowing = true;
        Time.timeScale = 0f;
    }

    void OnNextPressed()
    {
        Time.timeScale = 1f;

        if (isLastLevel)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
