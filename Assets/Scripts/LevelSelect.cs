using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;
    public Color lockedColor = new Color(0.3f, 0.3f, 0.3f, 1f);
    public Color unlockedColor = Color.white;

    void OnEnable()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;
            Button button = levelButtons[i];
            bool unlocked = LevelProgress.IsLevelUnlocked(levelIndex);

            button.interactable = unlocked;

            ColorBlock colors = button.colors;
            colors.highlightedColor = new Color(0.145f, 0.886f, 0.298f, 1f);
            colors.selectedColor = new Color(0.145f, 0.886f, 0.298f, 1f);
            colors.disabledColor = lockedColor;
            button.colors = colors;

            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = unlocked ? (levelIndex).ToString() : "X";
            }

            button.onClick.RemoveAllListeners();
            if (unlocked)
            {
                int index = levelIndex;
                button.onClick.AddListener(() => SceneManager.LoadScene(index));
            }
        }

        // Select first unlocked button
        for (int i = levelButtons.Length - 1; i >= 0; i--)
        {
            if (levelButtons[i].interactable)
            {
                levelButtons[i].Select();
                break;
            }
        }
    }
}
