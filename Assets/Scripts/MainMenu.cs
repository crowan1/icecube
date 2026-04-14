using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject controlsPanel;
    public GameObject levelSelectPanel;
    public Button playButton;
    public Button controlsButton;
    public Button levelSelectButton;
    public Button backFromControlsButton;
    public Button backFromLevelsButton;

    void Start()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        playButton.onClick.AddListener(Play);
        controlsButton.onClick.AddListener(ShowControls);
        levelSelectButton.onClick.AddListener(ShowLevelSelect);
        backFromControlsButton.onClick.AddListener(BackToMenu);
        backFromLevelsButton.onClick.AddListener(BackToMenu);

        SetButtonColors(playButton);
        SetButtonColors(controlsButton);
        SetButtonColors(levelSelectButton);
        SetButtonColors(backFromControlsButton);
        SetButtonColors(backFromLevelsButton);

        playButton.Select();
        lastSelected = playButton.gameObject;
    }

    GameObject lastSelected;

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
        else if (EventSystem.current.currentSelectedGameObject != null)
        {
            lastSelected = EventSystem.current.currentSelectedGameObject;
        }
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
        backFromControlsButton.Select();
    }

    void ShowLevelSelect()
    {
        menuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    void BackToMenu()
    {
        controlsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        menuPanel.SetActive(true);
        playButton.Select();
    }
}
