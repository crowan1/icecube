using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject controlsPanel;
    public Button playButton;
    public Button controlsButton;
    public Button backButton;

    void Start()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
        playButton.onClick.AddListener(Play);
        controlsButton.onClick.AddListener(ShowControls);
        backButton.onClick.AddListener(Back);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void ShowControls()
    {
        menuPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    void Back()
    {
        controlsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
