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
    public Button playFromControlsButton;
    public Button backFromControlsButton;
    public Button backFromLevelsButton;

    public Button musicOnButton;
    public Button musicOffButton;
    public Button sfxOnButton;
    public Button sfxOffButton;

    void Start()
    {
        menuPanel.SetActive(true);
        controlsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        playButton.onClick.AddListener(Play);
        controlsButton.onClick.AddListener(ShowControls);
        levelSelectButton.onClick.AddListener(ShowLevelSelect);
        playFromControlsButton.onClick.AddListener(StartGame);
        backFromControlsButton.onClick.AddListener(BackToMenu);
        backFromLevelsButton.onClick.AddListener(BackToMenu);

        musicOnButton.onClick.AddListener(MuteMusic);
        musicOffButton.onClick.AddListener(UnmuteMusic);
        sfxOnButton.onClick.AddListener(MuteSFX);
        sfxOffButton.onClick.AddListener(UnmuteSFX);

        SetButtonColors(playButton);
        SetButtonColors(controlsButton);
        SetButtonColors(levelSelectButton);
        SetButtonColors(playFromControlsButton);
        SetButtonColors(backFromControlsButton);
        SetButtonColors(backFromLevelsButton);

        UpdateMusicButtons();
        UpdateSFXButtons();

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
        menuPanel.SetActive(false);
        controlsPanel.SetActive(true);
        playFromControlsButton.Select();
    }

    void StartGame()
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

    void MuteMusic()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.ToggleMusic();
        UpdateMusicButtons();
        musicOffButton.Select();
    }

    void UnmuteMusic()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.ToggleMusic();
        UpdateMusicButtons();
        musicOnButton.Select();
    }

    void MuteSFX()
    {
        if (SFXManager.instance != null)
            SFXManager.instance.ToggleSFX();
        UpdateSFXButtons();
        sfxOffButton.Select();
    }

    void UnmuteSFX()
    {
        if (SFXManager.instance != null)
            SFXManager.instance.ToggleSFX();
        UpdateSFXButtons();
        sfxOnButton.Select();
    }

    void UpdateMusicButtons()
    {
        bool muted = AudioManager.instance != null && AudioManager.instance.IsMuted();
        musicOnButton.gameObject.SetActive(!muted);
        musicOffButton.gameObject.SetActive(muted);
    }

    void UpdateSFXButtons()
    {
        bool muted = SFXManager.instance != null && SFXManager.instance.IsMuted();
        sfxOnButton.gameObject.SetActive(!muted);
        sfxOffButton.gameObject.SetActive(muted);
    }
}
