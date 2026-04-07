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
        SetButtonColors(playButton);
        SetButtonColors(controlsButton);
        SetButtonColors(backButton);
        playButton.Select();
    }

    void SetButtonColors(Button button)
    {
        ColorBlock colors = button.colors;
        colors.highlightedColor = new Color(0.145f, 0.886f, 0.298f, 1f);
        colors.selectedColor = new Color(0.145f, 0.886f, 0.298f, 1f);
        button.colors = colors;
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }

    void ShowControls()
    {
        menuPanel.SetActive(false);
        controlsPanel.SetActive(true);
        backButton.Select();
    }

    void Back()
    {
        controlsPanel.SetActive(false);
        menuPanel.SetActive(true);
        playButton.Select();
    }
}
