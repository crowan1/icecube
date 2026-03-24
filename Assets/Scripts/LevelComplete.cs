using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelComplete : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI levelText;
    public Button nextButton;

    bool isShowing = false;
    bool isLastLevel = false;

    void Start()
    {
        panel.SetActive(false);
        nextButton.onClick.AddListener(OnNextPressed);
    }

    void Update()
    {
        if (isShowing && Input.GetKeyDown(KeyCode.Return))
        {
            OnNextPressed();
        }
        if (isShowing && Input.GetKeyDown(KeyCode.Space))
        {
            RestartLevel();
        }
    }

    public void Show()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex + 1;
        levelText.text = "Niveau " + levelNumber + " termin�";

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        isLastLevel = nextSceneIndex >= SceneManager.sceneCountInBuildSettings;

        if (isLastLevel)
        {
            levelText.text = "Bravo ! Tous les niveaux sont termines !";
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Menu";
        }
        else
        {
            levelText.text = "Niveau " + levelNumber + " termine";
        }
        panel.SetActive(true);
        isShowing = true;
        Time.timeScale = 0f;
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
